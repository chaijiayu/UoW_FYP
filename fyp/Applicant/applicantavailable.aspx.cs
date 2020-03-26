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
using System.Web.Services;

namespace fyp.Applicant
{
    public partial class applicantavailable : System.Web.UI.Page
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
            string query = "SELECT jp.postingID, jp.jobID, jp.qualification, jp.description, jp.status, j.positionName FROM job_posting as jp INNER JOIN job_position as j ON jp.jobID = j.jobID WHERE status = 'Available'";
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                int postingID = Int32.Parse(Server.HtmlDecode(row.Cells[0].Text));
                Session["PostingId"] = postingID;

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM job_posting WHERE postingID = @PostingId");
                cmd.Parameters.AddWithValue("@PostingId", postingID);
                cmd.Connection = databaseConnection;
                databaseConnection.Open();
                int? temp = (int)cmd.ExecuteScalar();
                if (temp != null)
                {
                    MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                    MySqlCommand cmd2 = new MySqlCommand("UPDATE job_posting SET status = 'Unavailable' WHERE postingID = @PostingId");
                    cmd2.Parameters.AddWithValue("@PostingId", postingID);
                    cmd2.Connection = databaseConnection2;
                    databaseConnection2.Open();
                    cmd2.ExecuteNonQuery();
                    databaseConnection2.Close();
                    DateTime now = DateTime.Now;
                    insertApplication(postingID, Int32.Parse(Session["applicantId"].ToString()), "Pending", now);
                }

                // Inserting current session date and time
                //DateTime now = DateTime.Now;

                // Now we have the variables, let's insert the details into the table
                //insertApplication(postingID, Int32.Parse(Session["applicantId"].ToString()), "Pending", now);
 
                databaseConnection.Close();


                BindGrid();
            }
        }

        protected void insertApplication(int postingID, int applicantID, string appStatus, DateTime submitDate)
        {
            string no = "No";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO job_application (postingID, applicantID, application_status, submit_date, interviewed) VALUES (@PostingId, @ApplicantId, @AppStatus, @SubmitDate, @Interviewed)");
            
            cmd.Parameters.AddWithValue("@PostingId", postingID);
            cmd.Parameters.AddWithValue("@ApplicantId", applicantID);
            cmd.Parameters.AddWithValue("@AppStatus", appStatus);
            cmd.Parameters.AddWithValue("@SubmitDate", submitDate);
            cmd.Parameters.AddWithValue("@Interviewed", no);
            cmd.Connection = databaseConnection;
            databaseConnection.Open();
            int result = cmd.ExecuteNonQuery();
            databaseConnection.Close();
        }

        protected void Search()
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM job_posting AS jp INNER JOIN job_position AS j ON jp.jobID = j.jobID WHERE (jp.status = 'Available' AND j.positionName LIKE @tbSearch)");
            String tbSearchVal = "%" + tbSearch.Text + "%";
            cmd.Parameters.AddWithValue("@tbSearch", tbSearchVal);
            cmd.Connection = databaseConnection;
            databaseConnection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            reader.Close();
            databaseConnection.Close();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }
    }
}