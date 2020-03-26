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

namespace fyp.Admin
{
    public partial class viewrepo : System.Web.UI.Page
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
            string query = "SELECT * FROM user";
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlDataReader dr = cmd.ExecuteReader();

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
            int userID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            try 
            {
                using (MySqlConnection databaseConnection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM user WHERE userID = @UserID"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@UserID", userID);
                            cmd.Connection = databaseConnection;
                            databaseConnection.Open();
                            cmd.ExecuteNonQuery();
                            databaseConnection.Close();
                        }
                    }
                }
                BindGrid();
            }
            catch(Exception ex)
            {
                string script = "alert(\"Admin accounts cannot be removed. Please refer to your windows machine.\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }

            
        }

        protected void OnRowSelected(object sender, EventArgs e)
        {
            try
            {
                // Get the datakey id as a session to be used on the redirected editing page
                GridViewRow row = GridView1.SelectedRow;
                int userAccId = Convert.ToInt32(row.Cells[0].Text);
                Session["userAccId"] = userAccId;

                Response.Redirect("viewrepoedit.aspx");
            }
            catch (Exception ex)
            {
                string script = "alert(\"Error!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }

        protected void Search()
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE (fName LIKE @tbSearch) OR (lName LIKE @tbSearch) OR (email LIKE @tbSearch)");
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

        protected void Logout_click(object sender, EventArgs e)
        {

        }
    }
}