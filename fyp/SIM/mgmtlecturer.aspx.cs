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

namespace fyp.SIM
{
    public partial class mgmtlecturer : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid() // Function to bind the table data to gridview
        {
            // Connecting to database
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();

            // Query string to display all user accounts
            string query = "SELECT sa.subjectApplicationID, sa.subjectID, sa.lecturerID, sa.subjectApp_status, sa.subjectApp_submit_date, " +
                           "sd.subject_Code, sd.subject_Name, sd.subject_Venue, sd.subject_Date, sd.subject_StartTime, sd.subject_EndTime, sd.university, " +
                           "u.fName, u.lName, u.email, u.contact " +
                           "FROM subject_application AS sa " +
                           "INNER JOIN subject_details AS sd ON sa.subjectID = sd.subjectID " +
                           "INNER JOIN lecturer AS l ON sa.lecturerID = l.lecturerID " +
                           "INNER JOIN user AS u ON l.userID = u.userID " +
                           "WHERE sa.subjectApp_status = 'Pending'";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataAdapter da = new MySqlDataAdapter(commandDatabase);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ViewState["dt"] = dt;
            GridView1.DataSource = ViewState["dt"] as DataTable;
            GridView1.DataBind();
        }

        protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            string emailAddress = System.Configuration.ConfigurationManager.AppSettings["emailAddress"];
            string emailPass = System.Configuration.ConfigurationManager.AppSettings["emailPassword"];
            try
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer; // To get the selected row

                if (e.CommandName == "Approve")
                {
                    if (row != null)
                    {

                        string subjectAppId = row.Cells[0].Text;
                        int subjectId = Convert.ToInt32(row.Cells[1].Text);
                        int lecturerId = Convert.ToInt32(row.Cells[2].Text);
                        string lecturerEmail = row.Cells[5].Text;
                        string fullName = row.Cells[4].Text + " " + row.Cells[3].Text;
                        string subjectname = row.Cells[7].Text;
                        string university = row.Cells[8].Text;


                        MySqlConnection databaseConnection = new MySqlConnection(connectionString);

                        MySqlCommand cmd = new MySqlCommand("UPDATE subject_application SET subjectApp_status = 'Approved' WHERE subjectApplicationID = @SubjectApplicationId");
                        //MySqlCommand cmd1 = new MySqlCommand("INSERT INTO lesson (subjectID, lecturerID) VALUES (@SubjectId, @LecturerId)");
                        cmd.Connection = databaseConnection;
                        //cmd1.Connection = databaseConnection;
                        databaseConnection.Open();
                        cmd.Parameters.AddWithValue("@SubjectApplicationId", subjectAppId);
                        //cmd1.Parameters.AddWithValue("@SubjectId", subjectId);
                        //cmd1.Parameters.AddWithValue("@LecturerId", lecturerId);
                        cmd.ExecuteNonQuery();
                        //cmd1.ExecuteNonQuery();
                        databaseConnection.Close();


                        BindGrid();

                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.Credentials = new System.Net.NetworkCredential(emailAddress, emailPass);
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress(emailAddress, "SIM Portal");
                        mailMessage.To.Add(lecturerEmail);
                        mailMessage.Body = "<html><p>Dear " + fullName + "</p><p>Your subject application result details for the application are as follows: <br/> Subject Name: " + subjectname + "<br/>University: " + university + "<br/>Status: Approved" + ".</p><p>Congratulations</p><p>SIM Portal System</p></html>";
                        mailMessage.Subject = "SIM Portal - Subject application result";
                        mailMessage.IsBodyHtml = true;
                        client.EnableSsl = true;
                        client.Send(mailMessage);
                        client.Dispose();
                    }

                    string script = "alert(\"Lesson has been approved\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                else if (e.CommandName == "Reject")
                {
                    if (row != null)
                    {
                        string subjectAppId = row.Cells[0].Text;
                        string lecturerEmail = row.Cells[5].Text;
                        string fullName = row.Cells[4].Text + " " + row.Cells[3].Text;
                        string subjectname = row.Cells[7].Text;

                        string university = row.Cells[12].Text;


                        MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);

                        MySqlCommand cmdR = new MySqlCommand("UPDATE subject_application SET subjectApp_status = 'Rejected' WHERE subjectApplicationID = @SubjectApplicationId");
                        cmdR.Connection = databaseConnection1;
                        databaseConnection1.Open();
                        cmdR.Parameters.AddWithValue("@SubjectApplicationId", subjectAppId);
                        cmdR.ExecuteNonQuery();
                        databaseConnection1.Close();

                        BindGrid();

                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.Credentials = new System.Net.NetworkCredential(emailAddress, emailPass);
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress(emailAddress, "SIM Portal");
                        mailMessage.To.Add(lecturerEmail);
                        mailMessage.Body = "<html><p>Dear " + fullName + "</p><p>Your subject application result details for the application are as follows: <br/> Subject Name: " + subjectname + "<br/>University: " + university + "<br/>Status: Rejected " + ".</p><p>We will look forward for your application again.</p><p>SIM Portal System</p></html>";
                        mailMessage.Subject = "SIM Portal - Subject application result";
                        mailMessage.IsBodyHtml = true;
                        client.EnableSsl = true;
                        client.Send(mailMessage);
                        client.Dispose();
                    }
                    string script = "alert(\"Subject has been rejected\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
            }
            catch(Exception ex)
            {
                string script = "alert(\"Error!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }
    }
}