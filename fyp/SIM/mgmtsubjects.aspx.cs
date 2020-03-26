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
    public partial class mgmtsubjects : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // For page reload when a row command is executed
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid() // Function to bind the table data to gridview
        {
            // Connecting to database
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();

            int mgmtID = Convert.ToInt32(Session["managementId"]);

            // Query string to display all user accounts
            string query = "SELECT * FROM subject_details WHERE managementID = @ManagementId";
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int subjectID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            try // To display an error message box if there is an constraint with the row
            {
                string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
                using (MySqlConnection databaseConnection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM subject_details WHERE subjectID = @SubjectID"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                            cmd.Connection = databaseConnection;
                            databaseConnection.Open();
                            cmd.ExecuteNonQuery();
                            databaseConnection.Close();
                        }
                    }
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                string script = "alert(\"You can't remove this as there is a lecturer that is applied to this subject\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }

        protected void Add(object sender, EventArgs e)
        {
            Response.Redirect("mgmtaddsubjects.aspx");
        }

        protected void subjectSearch()
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM subject_details WHERE (subject_Code LIKE @tbSearch) OR (subject_Name LIKE @tbSearch) OR (subject_Venue LIKE @tbSearch) ");
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
            this.subjectSearch();
        }
    }
}