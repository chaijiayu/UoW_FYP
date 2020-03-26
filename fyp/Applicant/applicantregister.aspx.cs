using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace fyp.Applicant
{
    public partial class applicantregister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // To check if there is an email already used
            if (IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                databaseConnection.Open();
                string checkuser = "select count(*) from user where email='" + TextBox3.Text + "'";
                MySqlCommand commandDatabase = new MySqlCommand(checkuser, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                int temp = Convert.ToInt32(commandDatabase.ExecuteScalar().ToString());

                if (temp == 1)
                {
                    Response.Write("Email Already Used");
                }

                databaseConnection.Close();
            }
        }

        protected void Register_Button(object sender, EventArgs e)
        {
            InsertDB();
            
        }

        private bool ValidatePassword(string password)
        {
            var input = password;

            if (string.IsNullOrWhiteSpace(input))
            {
                passwordvaliate.Text = "Password should not be empty";
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                passwordvaliate.Text = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                passwordvaliate.Text = "Password should contain At least one upper case letter";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                passwordvaliate.Text = "Password should not be less than or greater than 12 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                passwordvaliate.Text = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                passwordvaliate.Text = "Password should contain At least one special case characters";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void InsertDB()
        {
            // Insert created user into database
            string cvFileName = null;
            string password = TextBox4.Text;
            try
            {
                if (FileUploadControl.HasFile)
                {
                    string extension = (Path.GetExtension(FileUploadControl.FileName));
                    if (Path.GetExtension(FileUploadControl.FileName) != ".pdf")
                    {
                        string errorScript = "alert(\"Please upload only PDF files!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", errorScript, true);
                    }
                    else
                    {
                        cvFileName = Path.GetFileName(FileUploadControl.FileName);
                        FileUploadControl.SaveAs(Server.MapPath("~/CVFolder/") + cvFileName);

                        string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
                        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                        databaseConnection.Open();

                        string usertype = "ap";
                        string status = "active";

                        if (ValidatePassword(password))
                        {
                            // Query to insert values into the database
                            string insertQuery = "insert into user(fName,lName,email,password,DOB,gender,contact,userType,status,cvName)values (@fname,@lname,@email,@password,@dob,@gender,@contact,@usertype,@status,@cvName)";

                            MySqlCommand commandDatabase = new MySqlCommand(insertQuery, databaseConnection);
                            commandDatabase.CommandTimeout = 60;

                            commandDatabase.Parameters.AddWithValue("@fname", TextBox1.Text);
                            commandDatabase.Parameters.AddWithValue("@lname", TextBox2.Text);
                            commandDatabase.Parameters.AddWithValue("@email", TextBox3.Text);
                            commandDatabase.Parameters.AddWithValue("@password", password);
                            commandDatabase.Parameters.AddWithValue("@dob", TextBox5.Text);
                            commandDatabase.Parameters.AddWithValue("@gender", TextBox6.Text);
                            commandDatabase.Parameters.AddWithValue("@contact", TextBox7.Text);
                            commandDatabase.Parameters.AddWithValue("@usertype", usertype);
                            commandDatabase.Parameters.AddWithValue("@status", status);
                            commandDatabase.Parameters.AddWithValue("@cvName", cvFileName);
                            commandDatabase.ExecuteNonQuery();

                            commandDatabase.CommandText = ("select Last_insert_id()"); // To get userID of just created applicant
                            var id = commandDatabase.ExecuteScalar();
                            string imageName = "blank.jpg";

                            string applicantAdd = "INSERT INTO applicant(userID) VALUES (@last_id_in_user)"; // Insert the userID into applicant table
                            string profileAdd = "INSERT INTO profile(userID, imageName) VALUES (@last_id_in_user, @ImageName)";
                            MySqlCommand cmd = new MySqlCommand(applicantAdd, databaseConnection);
                            MySqlCommand cmd1 = new MySqlCommand(profileAdd, databaseConnection);

                            cmd.Parameters.AddWithValue("@last_id_in_user", id);
                            cmd1.Parameters.AddWithValue("@last_id_in_user", id);
                            cmd1.Parameters.AddWithValue("@ImageName", imageName);
                            cmd.ExecuteNonQuery();
                            cmd1.ExecuteNonQuery();

                            string script = "alert('Account created!'); window.location='" + Request.ApplicationPath + "Main.aspx'";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);

                            databaseConnection.Close();
                        }
                       

                       

                    }
                }
                else
                {
                    passwordvaliate.Text = "Please upload a file.";
                }

            }
            catch (Exception ex)
            {
                string script = "alert(\"Error!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }

        protected void Logout_click(object sender, EventArgs e)
        {

        }
    }
}