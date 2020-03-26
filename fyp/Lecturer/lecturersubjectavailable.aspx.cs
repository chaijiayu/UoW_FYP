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

namespace fyp.Lecturer
{
    public partial class lecturersubjectavailable : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.subjectSearch();
                BindGrid();
            }
        }
        protected void BindGrid() // Function to bind the table data to gridview
        {
            // Connecting to database
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();

            // Query string to display subjects that are available to apply
            string query = "SELECT * FROM subject_details WHERE status = 'Available'";
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                int subjectID = Int32.Parse(Server.HtmlDecode(row.Cells[0].Text));
                Session["subjectId"] = subjectID;

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM subject_details WHERE subjectID = @SubjectId");
                cmd.Parameters.AddWithValue("@SubjectId", subjectID);
                cmd.Connection = databaseConnection;
                databaseConnection.Open();
                int? temp = (int)cmd.ExecuteScalar();
                if (temp != null)
                {
                    MySqlConnection databaseConnection2 = new MySqlConnection(connectionString);
                    MySqlCommand cmd2 = new MySqlCommand("UPDATE subject_details SET status = 'Unavailable' WHERE subjectID = @SubjectId");
                    cmd2.Parameters.AddWithValue("@SubjectId", subjectID);
                    cmd2.Connection = databaseConnection2;
                    databaseConnection2.Open();
                    cmd2.ExecuteNonQuery();
                    databaseConnection2.Close();
                    DateTime now = DateTime.Now;
                    insertApplication(subjectID, Int32.Parse(Session["lecturerId"].ToString()), "Pending", now);

                }
                databaseConnection.Close();


                BindGrid();
            }
        }

        protected void insertApplication(int subjectID, int lecturerID, string appStatus, DateTime submitDate)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO subject_application (subjectID, lecturerID, subjectApp_status, subjectApp_submit_date) VALUES (@SubjectId, @LecturerId, @AppStatus, @SubmitDate)");
            cmd.Parameters.AddWithValue("@SubjectId", subjectID);
            cmd.Parameters.AddWithValue("@LecturerId", lecturerID);
            cmd.Parameters.AddWithValue("@AppStatus", appStatus);
            cmd.Parameters.AddWithValue("@SubmitDate", submitDate);
            cmd.Connection = databaseConnection;
            databaseConnection.Open();
            int result = cmd.ExecuteNonQuery();
            databaseConnection.Close();
        }

        protected void subjectSearch()
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM subject_details WHERE (status = 'Available' AND subject_Name LIKE @tbSearch) OR (subject_Venue LIKE @tbSearch) OR (subject_Code LIKE @tbSearch)");
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