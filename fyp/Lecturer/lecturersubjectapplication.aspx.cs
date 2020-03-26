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

namespace fyp.Lecturer
{
    public partial class lecturersubjectapplication : System.Web.UI.Page
    {
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
            string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();

            // Query string to display the lecturer's applied subjects
            string query = "SELECT sa.subjectApplicationID, sa.subjectApp_status, sa.subjectApp_submit_date, s.subject_Code, s.subject_Name, s.subject_Venue, s.subject_Date, s.subject_StartTime, s.subject_EndTime, s.university FROM subject_application as sa INNER JOIN subject_details as s ON sa.subjectID = s.subjectID WHERE lecturerID = '" + Session["lecturerID"] + "'";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataAdapter da = new MySqlDataAdapter(commandDatabase);
            MySqlDataReader dr = commandDatabase.ExecuteReader();
            
            if(dr.HasRows)
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
    }
}