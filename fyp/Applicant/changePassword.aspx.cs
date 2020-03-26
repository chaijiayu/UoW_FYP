using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace fyp.Applicant
{
    public partial class changePassword : System.Web.UI.Page
    {
        //string connectionString = "datasource=localhost;port=3306;username=root;password=;database=fyp;convert zero datetime=True";
        string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
        string oldPass;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string getOldPassword()
        {
            string query = "SELECT * FROM user WHERE userID = '" + Session["userID"] + "'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        oldPass = reader["password"].ToString();

                    }
                }
                else
                {
                    oldPass = null;
                    Response.Write("Password not found, please ensure you have logged in.");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }

            return oldPass;


        }

        protected void changePwd_Click(object sender, EventArgs e)
        {
            string pwdChecker = getOldPassword();

            if (oldPwd.Text != pwdChecker)
            {
                MsgBox("Old password is incorrect!", this.Page, this);
            }
            else
            {
                if (newPwd.Text != cfmNewPwd.Text)
                {
                    MsgBox("New passwords does not match! Please key in matching passwords", this.Page, this);
                }
                else
                {
                    MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                    MySqlCommand cmd2 = new MySqlCommand("UPDATE user SET password = '" + newPwd.Text + "' WHERE userID =  @userID");
                    cmd2.Parameters.AddWithValue("@userID", Session["userID"]);
                    cmd2.Connection = databaseConnection2;
                    databaseConnection2.Open();
                    cmd2.ExecuteNonQuery();
                    databaseConnection2.Close();
                    MsgBox("You have sucessfully updated your password", this.Page, this);
                }
            }
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void update_Click(object sender, EventArgs e)
        {
            oldPwd.Text = "";
            newPwd.Text = "";
            cfmNewPwd.Text = "";
        }
    }
}