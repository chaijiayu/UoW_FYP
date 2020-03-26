using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Net.Mail;


namespace fyp
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void changePwd_Click(object sender, EventArgs e)
        {

            string emailAddress = System.Configuration.ConfigurationManager.AppSettings["emailAddress"];
            string emailPass = System.Configuration.ConfigurationManager.AppSettings["emailPassword"];
            string fullName = null;

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand("SELECT * FROM user WHERE email = @email");
            commandDatabase.Parameters.AddWithValue("@email", email.Text);
            commandDatabase.Connection = databaseConnection;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        fullName = reader.GetString(1) + " " + reader.GetString(2);
                    }

                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[8];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    var finalString = new String(stringChars);

                    reader.Close();

                    string query2 = "UPDATE user SET password = @newpassword WHERE email = @email";
                    MySqlConnection dbCon = new MySqlConnection(connectionString);
                    MySqlCommand cmd = new MySqlCommand(query2, dbCon);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@newpassword", finalString);
                    cmd.Connection = databaseConnection;
                    dbCon.Open();
                    cmd.ExecuteNonQuery();
                    dbCon.Close();
                    try
                    {
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.Credentials = new System.Net.NetworkCredential(emailAddress, emailPass);
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress(emailAddress, "SIM Portal");
                        mailMessage.To.Add(email.Text);
                        mailMessage.Body = "<html><body><p>Dear " + fullName + ",</p> <p>Your password has been successfully resetted! Your new password is <a style='color:red;'>" + finalString + "</a>.</p><p>SIM Portal System</p></body></html>";
                        mailMessage.Subject = "SIM Portal - Request for reset of password";
                        mailMessage.IsBodyHtml = true;
                        client.EnableSsl = true;
                        client.Send(mailMessage);
                        client.Dispose();
                        string script = "alert('Password has been resetted! Please check your email!'); window.location='" + Request.ApplicationPath + "Main.aspx'";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }
                else
                {
                    errorLabel.Text = "Email Address is not valid.";

                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }

        }
    }
}