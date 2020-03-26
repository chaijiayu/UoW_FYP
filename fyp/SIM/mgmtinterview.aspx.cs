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
    public partial class mgmtinterview : System.Web.UI.Page
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
            int currentuser = Convert.ToInt32(Session["managementId"]);

            // Connecting to database
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();

            // Query string to display all user accounts
            string query = "SELECT ja.applicationID, ja.applicantID, ja.submit_date, j.jobID, j.positionName, u.fName, u.lName, u.email, u.contact, u.cvName " +
                           "FROM job_application as ja INNER JOIN job_posting as jp ON ja.postingID = jp.postingID " +
                           "INNER JOIN job_position as j ON jp.jobID = j.jobID " +
                           "INNER JOIN applicant as a ON ja.applicantID = a.applicantID " +
                           "INNER JOIN user as u ON a.userID = u.userID " +
                           "WHERE ja.interviewed = 'No'";

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

        protected void OnRowSelected(object sender, EventArgs e)
        {
            try
            {
                // Get the datakey id as a session to be used on the redirected scheduling page
                GridViewRow row = GridView1.SelectedRow;
                int applicationId = Convert.ToInt32(row.Cells[0].Text);
                int applicantId = Convert.ToInt32(row.Cells[1].Text);
                Session["applicationId"] = applicationId;
                Session["applicantId"] = applicantId;
                Response.Redirect("intvschedule.aspx");             
            }
            catch (Exception ex)
            {
                string script = "alert(\"Error!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }           
        }

        protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CVDownload")
            {
                string cv = e.CommandArgument.ToString();
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + cv);
                Response.TransmitFile(Server.MapPath("~/CVFolder/") + cv);
                Response.End();
                
            }
        }
    }
}   