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

namespace fyp.SIM
{
    public partial class mgmtapplicants : System.Web.UI.Page
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
            string query = "SELECT ja.applicationID, ja.applicantID, ja.submit_date, j.jobID, j.positionName, u.fName, u.lName, u.email, u.contact " +
                           "FROM job_application as ja INNER JOIN job_posting as jp ON ja.postingID = jp.postingID " +
                           "INNER JOIN job_position as j ON jp.jobID = j.jobID " +
                           "INNER JOIN applicant as a ON ja.applicantID = a.applicantID " +
                           "INNER JOIN user as u ON a.userID = u.userID " +
                           "WHERE ja.interviewed = 'Yes' AND ja.application_status = 'Pending'";
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

        protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer; // To get the selected row

                if (e.CommandName == "Approve")
                {
                    if (row != null)
                    {
                        MySqlConnection databaseConnection = new MySqlConnection(connectionString);

                        MySqlCommand cmd = new MySqlCommand("UPDATE job_application SET application_status = 'Approved'");
                        cmd.Connection = databaseConnection;
                        databaseConnection.Open();
                        cmd.ExecuteNonQuery();
                        databaseConnection.Close();

                        BindGrid();
                    }

                    string script = "alert(\"Applicant has been approved\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                else if (e.CommandName == "Reject")
                {                   
                    if (row != null)
                    {
                        MySqlConnection databaseConnection1 = new MySqlConnection(connectionString);

                        MySqlCommand cmd1 = new MySqlCommand("UPDATE job_application SET application_status = 'Rejected'");
                        cmd1.Connection = databaseConnection1;
                        databaseConnection1.Open();
                        cmd1.ExecuteNonQuery();
                        databaseConnection1.Close();

                        BindGrid();
                    }
                    string script = "alert(\"Applicant has been rejected\");";
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