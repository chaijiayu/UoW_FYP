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
    public partial class mgmtaddsubjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // To check if there is a job already added
            if (IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                databaseConnection.Open();
                string checksubject = "select count(*) from subject_details where subjectID='" + TextBox1.Text + "'";
                MySqlCommand commandDatabase = new MySqlCommand(checksubject, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                int temp = Convert.ToInt32(commandDatabase.ExecuteScalar().ToString());

                if (temp == 1)
                {
                    Response.Write("Subject already added");
                }

                databaseConnection.Close();
            }
        }

        protected void AddSubject_Button(object sender, EventArgs e)
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

                // Query to insert the values into the database
                string insertQuery = "INSERT INTO subject_details (managementID, subject_Code, subject_Name, subject_Venue, subject_Date, subject_StartTime, subject_EndTime, university, status) VALUES (@ManagementId, @Subject_Code, @Subject_Name, @Subject_Venue, @Subject_Date, @Subject_StartTime, @Subject_EndTime, @University, @Status)";

                MySqlCommand commandDatabase = new MySqlCommand(insertQuery, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                commandDatabase.Parameters.AddWithValue("@ManagementId", currentuser);
                commandDatabase.Parameters.AddWithValue("@Subject_Code", subjectCode.Text);
                commandDatabase.Parameters.AddWithValue("@Subject_Name", TextBox1.Text);
                commandDatabase.Parameters.AddWithValue("@Subject_Venue", TextBox2.Text);
                commandDatabase.Parameters.AddWithValue("@Subject_Date", TextBox3.Text);
                commandDatabase.Parameters.AddWithValue("@Subject_StartTime", ddl4.Text);
                commandDatabase.Parameters.AddWithValue("@Subject_EndTime", ddl5.Text);
                commandDatabase.Parameters.AddWithValue("@University", uni_ddl.Text);
                commandDatabase.Parameters.AddWithValue("@Status", TextBox6.Text);
                commandDatabase.ExecuteNonQuery();

                string script = "alert('Subject created!'); window.location='" + Request.ApplicationPath + "SIM/mgmtsubjects.aspx'";
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