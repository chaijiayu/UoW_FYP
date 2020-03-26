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

namespace fyp.SIM
{
    public partial class mgmtjobs : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // For page reload when a row command is executed
            if (!IsPostBack)
            {
                BindGridJobPosting();
            }
        }

        protected void BindGridJobPosting() // Function to bind the table data to gridview
        {
            // Connecting to database
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();

            int mgmtID = Convert.ToInt32(Session["managementId"]);

            // Query string to display all user accounts
            string query = "SELECT jp.postingID, jp.jobID, jp.qualification, jp.description, jp.status, j.positionName FROM job_posting as jp INNER JOIN job_position as j ON jp.jobID = j.jobID WHERE jp.managementID = @ManagementId";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataAdapter da = new MySqlDataAdapter(commandDatabase);
            commandDatabase.Parameters.AddWithValue("@ManagementId", mgmtID);
            MySqlDataReader dr = commandDatabase.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Close();
                DataTable dt = new DataTable();
                da.Fill(dt);

                ViewState["dt"] = dt;
                GridView2.DataSource = ViewState["dt"] as DataTable;
                GridView2.DataBind();
            }
            else
            {
                //Empty DataTable to execute the “else-condition”  
                dr.Close();
                DataTable dte = new DataTable();
                GridView2.DataSource = dte;
                GridView2.DataBind();
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            int postingID = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
            int jobID = Convert.ToInt32(GridView2.Rows[e.RowIndex].Cells[1].Text);

            try // To display an error message box if there is an constraint with the row
            {
                string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
                using (MySqlConnection databaseConnection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM job_posting WHERE postingID = @PostingId; DELETE FROM job_position WHERE jobID = @JobID"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@PostingId", postingID);
                            cmd.Parameters.AddWithValue("@JobID", jobID);
                            cmd.Connection = databaseConnection;
                            databaseConnection.Open();
                            cmd.ExecuteNonQuery();
                            databaseConnection.Close();
                        }
                    }
                }
                BindGridJobPosting();
            }
            catch (Exception ex)
            {
                string script = "alert(\"You can't remove this as there is an applicant that is applied to this position\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }

        protected void Addposting(object sender, EventArgs e)
        {
            Response.Redirect("mgmtaddjobpostings.aspx");
        }

        protected void Search2()
        {
            int mgmtID = Convert.ToInt32(Session["managementId"]);
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM job_posting AS jp INNER JOIN job_position AS j ON jp.jobID = j.jobID WHERE (j.positionName LIKE @tbSearch) AND jp.managementID = @ManagementID");
            String tbSearchVal = "%" + tbSearch2.Text + "%";
            cmd.Parameters.AddWithValue("@tbSearch", tbSearchVal);
            cmd.Parameters.AddWithValue("@ManagementID", mgmtID);
            cmd.Connection = databaseConnection;
            databaseConnection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            GridView2.DataSource = dt;
            GridView2.DataBind();
            reader.Close();
            databaseConnection.Close();
        }

        protected void btnSearch_Click2(object sender, EventArgs e)
        {
            this.Search2();
        }
    }
}