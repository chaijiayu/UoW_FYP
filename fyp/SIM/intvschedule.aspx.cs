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
    public partial class intvschedule : System.Web.UI.Page
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
            // Get the application id from the previous page
            int id = Convert.ToInt32(Session["applicationId"]);

            // Connecting to database
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();

            // Query string to display applicants that is selected to be interviewed
            string query = "SELECT ja.applicationID, ja.applicantID, ja.submit_date, j.jobID, j.positionName, u.fName, u.lName, u.email, u.contact " +
                           "FROM job_application as ja INNER JOIN job_posting as jp ON ja.postingID = jp.postingID " +
                           "INNER JOIN job_position as j ON jp.jobID = j.jobID " +
                           "INNER JOIN applicant as a ON ja.applicantID = a.applicantID " +
                           "INNER JOIN user as u ON a.userID = u.userID " +
                           "WHERE ja.applicationID = @ApplicationId";

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.Parameters.AddWithValue("@ApplicationId", id);
            commandDatabase.ExecuteNonQuery();
            MySqlDataAdapter da = new MySqlDataAdapter(commandDatabase);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ViewState["dt"] = dt;
            GridView1.DataSource = ViewState["dt"] as DataTable;
            GridView1.DataBind();
        }

        protected void AddInterview(object sender, EventArgs e)
        {
            string emailAddress = System.Configuration.ConfigurationManager.AppSettings["emailAddress"];
            string emailPass = System.Configuration.ConfigurationManager.AppSettings["emailPassword"];
            try
            {
                // Get the application id from the previous page
                
                GridViewRow row = GridView1.Rows[0];
                int applicationId = Convert.ToInt32(Session["applicationId"]);
                int managementId = Convert.ToInt32(Session["managementId"]);
                int applicantId = Convert.ToInt32(Session["applicantId"]);
                string applicantEmail = row.Cells[7].Text;
                string fullName = row.Cells[5].Text + " " + row.Cells[6].Text;
                string intvenue = TextBox2.Text;
                string intdate = TextBox1.Text;
                string inttime = ddl3.Text;

                // Connecting to database
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                databaseConnection.Open();

                // Query string to add the details to the table
                string query = "INSERT INTO job_interview (applicationID, applicantID, managementID, interviewDate, interviewVenue, startTime)" +
                               "VALUES (@ApplicationId, @ApplicantId, @ManagementId, @InterviewDate, @InterviewVenue, @StartTime)";

                string query1 = "UPDATE job_application SET interviewed = 'Yes' WHERE applicationID = @ApplicationId";

                MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
                MySqlCommand cmd1 = new MySqlCommand(query1, databaseConnection);
                cmd.Parameters.AddWithValue("@ApplicationId", applicationId);
                cmd.Parameters.AddWithValue("@ApplicantId", applicantId);
                cmd.Parameters.AddWithValue("@ManagementId", managementId);
                cmd.Parameters.AddWithValue("@InterviewDate", TextBox1.Text);
                cmd.Parameters.AddWithValue("@InterviewVenue", TextBox2.Text);
                cmd.Parameters.AddWithValue("@StartTime", ddl3.Text);
                cmd1.Parameters.AddWithValue("@ApplicationId", applicationId);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();

                /*string script = "alert(\"Interview scheduled!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);*/     

                databaseConnection.Close();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new System.Net.NetworkCredential(emailAddress, emailPass);
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(emailAddress, "SIM Portal");
                mailMessage.To.Add(applicantEmail);
                mailMessage.Body = "<html><p>Dear " + fullName + "</p><p>You have been shortlisted for interview. The details for the interview are as follows: <br/> Venue: " + intvenue + "<br/>Date: "  + intdate + "<br/>Time: "+ inttime + ".</p><p>Congratulations</p><p>SIM Portal System</p></html>";
                mailMessage.Subject = "SIM Portal - Job Interview Scheduled";
                mailMessage.IsBodyHtml = true;
                client.EnableSsl = true;
                client.Send(mailMessage);
                client.Dispose();

                ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Interview scheduled!');window.location ='mgmtinterview.aspx';",
                    true);
            }

            catch (Exception ex)
            {
                string script = "alert(\"Error!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }          
        }
    }
}