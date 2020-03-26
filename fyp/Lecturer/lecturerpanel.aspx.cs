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
    public partial class lecturerpanel : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {           
            int userID = Convert.ToInt32(Session["UserID"]);

            string query = "SELECT fName FROM user WHERE userID = @UserId";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
            cmd.Parameters.AddWithValue("@UserId", userID);
            cmd.Connection = databaseConnection;
            databaseConnection.Open();
            string name = (string)cmd.ExecuteScalar();

            Leftcolumn();
            displayProfile();
        }

        protected void Leftcolumn()
        {
            int lecturerID = Convert.ToInt32(Session["lecturerId"]);

            string query = "SELECT u.fName, u.lName, u.email, u.contact FROM user AS u INNER JOIN lecturer as l ON u.userID = l.userID WHERE l.lecturerID = @LecturerId";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
            cmd.Parameters.AddWithValue("@LecturerId", lecturerID);
            cmd.Connection = databaseConnection;
            databaseConnection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblfName.Text = dr["fName"].ToString();
                lbllName.Text = dr["lName"].ToString();
                lblEmail.Text = dr["email"].ToString();
                lblPhone.Text = dr["contact"].ToString();
            }
            databaseConnection.Close();
        }

        public void displayProfile()
        {
            int userID = Convert.ToInt32(Session["UserID"]);

            string query = "SELECT imageName, workExp, education FROM profile where userID = @UserId";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
            cmd.Parameters.AddWithValue("@UserId", userID);
            cmd.Connection = databaseConnection;
            databaseConnection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                profpic.ImageUrl = "~/Images/profpic/" + dr["imageName"].ToString();
                lblWork.Text = dr["workExp"].ToString();
                lblEdu.Text = dr["education"].ToString();
            }
        }

        protected void Logout_click()
        {

        }
    }
}