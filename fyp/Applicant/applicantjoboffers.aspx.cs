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

namespace fyp.Applicant
{
    public partial class applicantjoboffers : System.Web.UI.Page
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
            int id = Convert.ToInt32(Session["applicantId"]);

            // Connecting to database
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();

            // Query string to display all user accounts
            string query = "SELECT ja.applicationID, ja.submit_date, ja.application_status, j.jobID, j.positionName " +
                           "FROM job_application as ja INNER JOIN job_posting as jp ON ja.postingID = jp.postingID " +
                           "INNER JOIN job_position as j ON jp.jobID = j.jobID " +
                           "INNER JOIN applicant as a ON ja.applicantID = a.applicantID " +
                           "INNER JOIN user as u ON a.userID = u.userID " +
                           "WHERE ja.interviewed = 'Yes' AND ja.application_status = 'Approved' AND ja.applicantID = @ApplicantId AND ja.response IS NULL";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.Parameters.AddWithValue("@ApplicantId", id);
            commandDatabase.ExecuteNonQuery();
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

        protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer; // To get the selected row

                if (e.CommandName == "Approve")
                {
                    if (row != null)
                    {
                        int id = Convert.ToInt32(Session["applicantId"]);

                        MySqlConnection databaseConnection = new MySqlConnection(connectionString);

                        MySqlCommand cmd = new MySqlCommand("UPDATE job_application SET response = 'Accepted' WHERE applicantID = @ApplicantId");
                        cmd.Connection = databaseConnection;
                        cmd.Parameters.AddWithValue("@ApplicantId", id);
                        databaseConnection.Open();
                        cmd.ExecuteNonQuery();
                        databaseConnection.Close();

                        BindGrid();
                    }

                    string script = "alert(\"You have accepted the job offer! We will get back to you shortly.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                else if (e.CommandName == "Reject")
                {
                    if (row != null)
                    {
                        int id = Convert.ToInt32(Session["applicantId"]);

                        MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);

                        MySqlCommand cmd1 = new MySqlCommand("UPDATE job_application SET response = 'Rejected' WHERE applicantID = @ApplicantId");
                        cmd1.Connection = databaseConnection1;
                        cmd1.Parameters.AddWithValue("@ApplicantId", id);
                        databaseConnection1.Open();
                        cmd1.ExecuteNonQuery();
                        databaseConnection1.Close();

                        BindGrid();
                    }
                    string script = "alert(\"You have rejected the job offer.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
            }
            catch
            {
                string script = "alert(\"Error!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }
    }
}