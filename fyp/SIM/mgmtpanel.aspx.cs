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
    public partial class mgmtpanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;

            int userID = Convert.ToInt32(Session["UserID"]);

            string query = "SELECT fName FROM user WHERE userID = @UserId";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
            cmd.Parameters.AddWithValue("@UserId", userID);
            cmd.Connection = databaseConnection;
            databaseConnection.Open();
            string name = (string)cmd.ExecuteScalar();

            displayUser.Text = "<h1>" + "Welcome  "
                        + name + "!</h1>";
        }

        protected void Logout_click(object sender, EventArgs e)
        {

        }
    }
}