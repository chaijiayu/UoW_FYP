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

namespace fyp
{
    public partial class Jobpostviewing : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            // For page reload when a row command is executed
            if (!IsPostBack)
            {

                BindGridJobviewing();
            }
        }
        protected void BindGridJobviewing() // Function to bind the table data to gridview
        {
            // Connecting to database
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();



            // Query string to display all user accounts
            string query = "SELECT jp.postingID, jp.jobID, jp.qualification, jp.description, jp.status, j.positionName FROM job_posting as jp INNER JOIN job_position as j ON jp.jobID = j.jobID WHERE jp.status = 'Available'";
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

        protected void Search()
        {
            int mgmtID = Convert.ToInt32(Session["managementId"]);
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM job_posting AS jp INNER JOIN job_position AS j ON jp.jobID = j.jobID WHERE (j.positionName LIKE @tbSearch) AND jp.status = 'Available'");
            String tbSearchVal = "%" + tbSearch.Text + "%";
            cmd.Parameters.AddWithValue("@tbSearch", tbSearchVal);
            cmd.Parameters.AddWithValue("@ManagementID", mgmtID);
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