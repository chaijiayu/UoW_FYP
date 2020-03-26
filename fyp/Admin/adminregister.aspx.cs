using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace fyp.Admin
{
    public partial class adminregister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // To check if there is an email already used
            if (IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                databaseConnection.Open();
                string checkuser = "select count(*) from user where email='" + TextBox3.Text + "'";
                MySqlCommand commandDatabase = new MySqlCommand(checkuser, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                int temp = Convert.ToInt32(commandDatabase.ExecuteScalar().ToString());

                if (temp == 1)
                {
                    Response.Write("Email Already Used");
                }

                databaseConnection.Close();
            }
        }

        protected void Register_Button(object sender, EventArgs e)
        {
            InsertDB();

            string message = "Manager account has been created!";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += Request.Url.AbsoluteUri;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        }

        private void InsertDB()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                databaseConnection.Open();
                string usertype = "m";

                // Query string to insert the values into the database
                string insertQuery = "insert into user(fName,lName,email,password,DOB,gender,contact,userType,status)values (@fname,@lname,@email,@password,@dob,@gender,@contact,@usertype,@status)";

                MySqlCommand commandDatabase = new MySqlCommand(insertQuery, databaseConnection);   
                commandDatabase.CommandTimeout = 60;

                commandDatabase.Parameters.AddWithValue("@fname", TextBox1.Text);
                commandDatabase.Parameters.AddWithValue("@lname", TextBox2.Text);
                commandDatabase.Parameters.AddWithValue("@email", TextBox3.Text);
                commandDatabase.Parameters.AddWithValue("@password", TextBox4.Text);
                commandDatabase.Parameters.AddWithValue("@dob", TextBox5.Text);
                commandDatabase.Parameters.AddWithValue("@gender", TextBox6.Text);
                commandDatabase.Parameters.AddWithValue("@contact", TextBox7.Text);
                commandDatabase.Parameters.AddWithValue("@usertype", usertype);
                commandDatabase.Parameters.AddWithValue("@status", TextBox9.Text);
                commandDatabase.ExecuteNonQuery();

                commandDatabase.CommandText = ("select Last_insert_id()");
                var id = commandDatabase.ExecuteScalar();

                string lecturerAdd = "INSERT INTO management(userID) VALUES (@last_id_in_user)";
                MySqlCommand cmd = new MySqlCommand(lecturerAdd, databaseConnection);

                cmd.Parameters.AddWithValue("@last_id_in_user", id);
                cmd.ExecuteNonQuery();

                databaseConnection.Close();               
            }
            catch (Exception ex)
            {
                // Error Message
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