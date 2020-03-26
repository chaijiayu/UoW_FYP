using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net;
using System.IO;


namespace fyp.Applicant
{
    public partial class applicantprofile : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayapplicantInfo();
                displayImage();
            }
        }

        public void displayImage()
        {
            int userID = Convert.ToInt32(Session["UserID"]);

            string query = "SELECT imageName FROM profile where userID = @UserId";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
            cmd.Parameters.AddWithValue("@UserId", userID);
            cmd.Connection = databaseConnection;
            databaseConnection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                profpic.ImageUrl = "~/Images/profpic/" + dr["imageName"].ToString();
            }
        }

        public void displayapplicantInfo()
        {
            string query = "SELECT * FROM user WHERE userID = '" + Session["userID"] + "'";
            string query1 = "SELECT workExp, education FROM profile WHERE userID = '" + Session["userID"] + "'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlCommand cmd = new MySqlCommand(query1, databaseConnection);
            MySqlDataReader reader, reader1;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        fsName.Text = reader["fName"].ToString();
                        lsName.Text = reader["lName"].ToString();
                        gender.Text = reader["gender"].ToString();
                        if (reader["gender"].ToString().Equals("f"))
                        {
                            gender.Text = "Female";
                        }
                        else
                        {
                            gender.Text = "Male";
                        }
                        DateTime date = Convert.ToDateTime(reader["DOB"].ToString());
                        dob.Text = date.ToShortDateString();
                        phoneNum.Text = reader["contact"].ToString();
                        email.Text = reader["email"].ToString();
                        cv.Text = reader["cvName"].ToString();
                    }
                }
                else
                {
                    Response.Write("Profile not available, please ensure you have logged in.");
                }
                reader.Close();

                reader1 = cmd.ExecuteReader();
                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        work.Text = reader1["workExp"].ToString();
                        edu.Text = reader1["education"].ToString();
                    }
                }
                else
                {
                    Response.Write("Profile not available, please ensure you have logged in.");
                }
                reader.Close();

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);

            int userID = Convert.ToInt32(Session["UserID"]);
            string newGender;
            string profpicFileName;

            if (FileUploadControl.HasFile)
            {
                profpicFileName = Path.GetFileName(FileUploadControl.FileName);
                FileUploadControl.SaveAs(Server.MapPath("~/Images/profpic/") + profpicFileName);
            }
            else
            {
                profpicFileName = "blank.jpg";
            }

            if (gender.Text == "Male")
            {
                newGender = "m";
            }
            else
            {
                newGender = "f";
            }

            string query = "UPDATE profile SET imageName = @ImageName, workExp = '" + work.Text + "', education = '" + edu.Text + "' WHERE userID = @userId";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection2);
            MySqlCommand cmd2 = new MySqlCommand("UPDATE user SET fName = '" + fsName.Text + "', lName = '" + lsName.Text + "', gender = '" + newGender + "', DOB = '" + dob.Text + "', contact = '" + phoneNum.Text + "', email = '" + email.Text + "' WHERE userID = '" + Session["userID"] + "'");
            cmd2.Connection = databaseConnection2;
            databaseConnection2.Open();
            commandDatabase.Parameters.AddWithValue("@UserId", userID);
            commandDatabase.Parameters.AddWithValue("@ImageName", profpicFileName);
            commandDatabase.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            databaseConnection2.Close();
            MsgBox("You have sucessfully updated your profile", this.Page, this);
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = cv.Text;
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + name);
                Response.TransmitFile(Server.MapPath("~/CVFolder/") + name);
                Response.End();
            }
            catch (Exception ex)
            {
            }
        }

        protected void pwdChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("changePassword.aspx");
        }
    }
}
