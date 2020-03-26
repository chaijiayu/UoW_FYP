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

namespace fyp.Admin
{
    public partial class adminconvert : System.Web.UI.Page
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
            string query = "SELECT ja.applicationID, ja.applicantID, u.userID, ja.submit_date, ja.application_status, ja.response, j.jobID, j.positionName, u.fName, u.lName, u.email, u.contact " +
                           "FROM job_application as ja INNER JOIN job_posting as jp ON ja.postingID = jp.postingID " +
                           "INNER JOIN job_position as j ON jp.jobID = j.jobID " +
                           "INNER JOIN applicant as a ON ja.applicantID = a.applicantID " +
                           "INNER JOIN user as u ON a.userID = u.userID " +
                           "WHERE ja.interviewed = 'Yes' AND ja.application_status = 'Approved' AND ja.response = 'Accepted' AND u.userType = 'ap'";

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataAdapter da = new MySqlDataAdapter(commandDatabase);
            MySqlDataReader dr = commandDatabase.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Close();
                DataTable dt = new DataTable();
                da.Fill(dt);

                ViewState["dt"] = dt;
                GridView1.DataSource = ViewState["dt"] as DataTable;
                GridView1.DataBind();
            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                dr.Close();
                DataTable dte = new DataTable();
                GridView1.DataSource = dte;
                GridView1.DataBind();
            }
        }

        protected void OnRowSelected(object sender, EventArgs e)
        {
            string emailAddress = System.Configuration.ConfigurationManager.AppSettings["emailAddress"];
            string emailPass = System.Configuration.ConfigurationManager.AppSettings["emailPassword"];

            try
            {
                // Convert the applicant account to lecturer account
                GridViewRow row = GridView1.SelectedRow;
                int applicantId = Convert.ToInt32(row.Cells[0].Text);
                int userId = Convert.ToInt32(row.Cells[1].Text);
                int jobId = Convert.ToInt32(row.Cells[2].Text);
                string applicantEmail = row.Cells[7].Text;
                string fullName = row.Cells[5].Text + " " + row.Cells[6].Text;
                string jobName = row.Cells[3].Text;


                string query = "UPDATE user u INNER JOIN applicant a on u.userID = a.userID SET u.userType = 'l' WHERE a.applicantID = @ApplicantID";
                string query1 = "INSERT INTO lecturer (userID, jobID) VALUES (@UserId, @JobId)";
                string delQuery = "DELETE FROM job_application WHERE applicantID = @ApplicantID";
                string delQuery2 = "DELETE FROM job_interview WHERE applicantID = @ApplicantID";
                string query2 = "DELETE FROM applicant WHERE applicantID = @ApplicantId"; 

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
                MySqlCommand cmd1 = new MySqlCommand(query1, databaseConnection);
                MySqlCommand delcmd = new MySqlCommand(delQuery, databaseConnection);
                MySqlCommand delcmd2 = new MySqlCommand(delQuery2, databaseConnection);
                MySqlCommand cmd2 = new MySqlCommand(query2, databaseConnection);
                cmd.Parameters.AddWithValue("@ApplicantId", applicantId);
                cmd1.Parameters.AddWithValue("@userId", userId);
                cmd1.Parameters.AddWithValue("@JobId", jobId);
                delcmd.Parameters.AddWithValue("@ApplicantID", applicantId);
                delcmd2.Parameters.AddWithValue("@ApplicantID", applicantId);
                cmd2.Parameters.AddWithValue("@ApplicantId", applicantId);
                cmd.Connection = databaseConnection;
                databaseConnection.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                delcmd2.ExecuteNonQuery();
                delcmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                databaseConnection.Close();
                MsgBox("Applicant account has been converted to Lecturer", this.Page, this);
                BindGrid();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new System.Net.NetworkCredential(emailAddress, emailPass);
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(emailAddress, "SIM Portal");
                mailMessage.To.Add(applicantEmail);
                mailMessage.Body = "<html><p>Dear " + fullName + "</p><p>You have been converted to a lecturer for the job " + jobName + ".</p><p>Congratulations</p><p>SIM Portal System</p></html>";
                mailMessage.Subject = "SIM Portal - Job Application Status";
                mailMessage.IsBodyHtml = true;
                client.EnableSsl = true;
                client.Send(mailMessage);
                client.Dispose();
            }
            catch (Exception ex)
            {
                string script = "alert(\"Error!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
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