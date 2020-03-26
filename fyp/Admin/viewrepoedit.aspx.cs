using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.IO;

namespace fyp.Admin
{
    public partial class viewrepoedit : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            displayAccInfo();
            displayImage();
        }

        public void displayImage()
        {
            // Get the application id from the previous page
            int userID = Convert.ToInt32(Session["userAccId"]);

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

        public void displayAccInfo()
        {
            // Get the application id from the previous page
            int userID = Convert.ToInt32(Session["userAccId"]);

            string query = "SELECT * FROM user WHERE userID = @UserId";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                commandDatabase.Parameters.AddWithValue("@UserId", userID);
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
                        password.Text = reader["password"].ToString();

                        userType.Text = reader["userType"].ToString();
                        if (reader["userType"].ToString().Equals("ap"))
                        {
                            userType.Text = "Applicant";
                        }
                        else if(reader["userType"].ToString().Equals("l"))
                        {
                            userType.Text = "Lecturer";
                        }
                        else if (reader["userType"].ToString().Equals("m"))
                        {
                            userType.Text = "Manager";
                        }

                        status.Text = reader["status"].ToString();
                        if (reader["status"].ToString().Equals("active"))
                        {
                            status.Text = "Active";
                        }
                        else if (reader["status"].ToString().Equals("inactive"))
                        {
                            status.Text = "Inactive";
                        }
                    }
                }
                else
                {
                    Response.Write("Profile not available.");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            // Get the application id from the previous page
            int userID = Convert.ToInt32(Session["userAccId"]);

            string profpicFileName = "blank.jpg";

            if (FileUploadControl.HasFile)
            {
                profpicFileName = Path.GetFileName(FileUploadControl.FileName);
                FileUploadControl.SaveAs(Server.MapPath("~/Images/profpic/") + profpicFileName);
            }

            string query = "UPDATE profile SET imageName = @ImageName WHERE userID = @userId";          
            string query1 = "UPDATE user SET fName = @Fname, lName = @Lname, gender = @Gender, DOB = @Dob, contact = @Contact, email = @Email, password = @Password, userType = @UserType, status = @Status WHERE userID = @UserId";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlCommand cmd = new MySqlCommand(query1, databaseConnection);
            databaseConnection.Open();

            commandDatabase.Parameters.AddWithValue("@UserId", userID);
            commandDatabase.Parameters.AddWithValue("@ImageName", profpicFileName);
            cmd.Parameters.AddWithValue("@Fname", fsName.Text);
            cmd.Parameters.AddWithValue("@Lname", lsName.Text);
            cmd.Parameters.AddWithValue("@Gender", gender.Text);
            cmd.Parameters.AddWithValue("@Dob", dob.Text);
            cmd.Parameters.AddWithValue("@Contact", phoneNum.Text);
            cmd.Parameters.AddWithValue("@Email", email.Text);
            cmd.Parameters.AddWithValue("@Password", password.Text);
            cmd.Parameters.AddWithValue("@UserType", userType.Text);            
            cmd.Parameters.AddWithValue("@Status", status.Text);
            cmd.Parameters.AddWithValue("@UserId", userID);
            commandDatabase.ExecuteNonQuery();
            cmd.ExecuteNonQuery();

            databaseConnection.Close();
            MsgBox("You have sucessfully updated this account", this.Page, this);
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}