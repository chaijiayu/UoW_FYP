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
    public partial class mgmtaddjobpostings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void AddJobPost_Button(object sender, EventArgs e)
        {
            InsertDB();
        }

        private void InsertDB()
        {
            // Insert created job posting into database
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                databaseConnection.Open();

                int currentuser = Convert.ToInt32(Session["managementId"]); // Get session id

                //Query to insert job position into job table
                string jobinsertQuery = "INSERT INTO job_position (positionName, managementID) VALUES (@PositionName, @ManagementID)";

                MySqlCommand commandDatabase = new MySqlCommand(jobinsertQuery, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                commandDatabase.Parameters.AddWithValue("@PositionName", jpTB.Text);
                commandDatabase.Parameters.AddWithValue("@ManagementID", currentuser);
                commandDatabase.ExecuteNonQuery();

                //Query to retrieve ID.
                string jobIdRetrieval = "SELECT jobID FROM job_position WHERE positionName = @PositionName";
                commandDatabase = new MySqlCommand(jobIdRetrieval, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@PositionName", jpTB.Text);
                MySqlDataReader reader = commandDatabase.ExecuteReader();
                int jobID = 0;
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        jobID = (int)reader["jobID"];
                    }
                }

                reader.Close();
          

                // Query to insert the values into the database
                string insertQuery = "INSERT INTO job_posting (jobID, managementID, qualification, description, status) VALUES (@JobId, @ManagementId, @Qualification, @Description, @Status)";

                commandDatabase = new MySqlCommand(insertQuery, databaseConnection);
                commandDatabase.CommandTimeout = 60;


                commandDatabase.Parameters.AddWithValue("@JobId", jobID);
                commandDatabase.Parameters.AddWithValue("@ManagementId", currentuser);
                commandDatabase.Parameters.AddWithValue("@Qualification", TextBox2.Text);
                commandDatabase.Parameters.AddWithValue("@Description", TextBox3.Text);
                commandDatabase.Parameters.AddWithValue("@Status", TextBox4.Text);
                commandDatabase.ExecuteNonQuery();

                string script = "alert('Job posting added!'); window.location='" + Request.ApplicationPath + "SIM/mgmtjobs.aspx'";

                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);

                databaseConnection.Close();

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