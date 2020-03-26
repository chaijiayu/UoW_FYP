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

namespace fyp
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Button(object sender, EventArgs e)
        {
            DBConnection();
        }

        // This is to connect to the database
        private void DBConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
            string user = ddl1.Text;
            string uid = TextBox1.Text;
            string pass = TextBox2.Text;

            if (user == "ad")
            {
                // The string query to specify which conditions to apply to the database and table
                string query = "SELECT * FROM user WHERE email='" + uid + "' AND password='" + pass + "' AND userType='ad'";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    // Opening the database
                    databaseConnection.Open();

                    // Execute the query
                    reader = commandDatabase.ExecuteReader();

                    // IMPORTANT:
                    // If the query returns the result, execute the if statement, else.

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Session["userID"] = reader["userID"].ToString();
                            Response.Redirect("Admin/adminpanel.aspx");
                        }
                    }
                    else
                    {
                        MsgBox("Username or Password incorrect", this.Page, this);
                    }

                    while (reader.Read())
                    {
                        // GetString(id), id is the column in your database. Using libraryTest as an example, 0 is id, 1 is name.
                        string name = reader.GetString(0);
                    }

                    // Finally close the connection
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("error" + ex.ToString());
                }
            }

            else if (user == "ap")
            {
                // The string query to specify which conditions to apply to the database and table.
                // this allows us to parse the id from both tables to the session variable
                string query = "SELECT u.*, a.applicantID FROM user as u INNER JOIN applicant as a on u.userID = a.userID WHERE email='" + uid + "' AND password='" + pass + "' AND userType='ap'";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    // Opening the database
                    databaseConnection.Open();

                    // Execute the query
                    reader = commandDatabase.ExecuteReader();

                    // All succesfully executed, now do something

                    // IMPORTANT :
                    // If the query returns the result, execute the if statement, else.

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Session["applicantId"] = reader["applicantID"].ToString();
                            Session["userID"] = reader["userID"].ToString();
                            Response.Redirect("Applicant/applicantpanel.aspx");
                        }
                    }
                    else
                    {
                        MsgBox("Username or Password incorrect", this.Page, this);
                    }

                    while (reader.Read())
                    {
                        // GetString(id), id is the column in your database. Using libraryTest as an example, 0 is id, 1 is name.
                        string name = reader.GetString(0);
                    }

                    // Finally close the connection
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    // Show error message
                    Response.Write("error" + ex.ToString());
                }
            }

            else if (user == "l")
            {
                // Your query, change your query to select from the correct table.
                // this allows us to parse the id from both tables to the session variable
                string query = "SELECT u.*, l.lecturerID FROM user as u INNER JOIN lecturer as l on u.userID = l.userID WHERE email='" + uid + "' AND password='" + pass + "' AND userType='l'";

                // Prepare the connection
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    // Open the database
                    databaseConnection.Open();

                    // Execute the query
                    reader = commandDatabase.ExecuteReader();

                    // All succesfully executed, now do something

                    // IMPORTANT : 
                    // If your query returns result, use the following processor :

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Session["lecturerId"] = reader["lecturerID"].ToString();
                            Session["userID"] = reader["userID"].ToString();
                            Response.Redirect("Lecturer/lecturerpanel.aspx");
                        }
                    }
                    else
                    {
                        MsgBox("Username or Password incorrect", this.Page, this);
                    }

                    while (reader.Read())
                    {
                        //GetString(id), id is the column in your database. Using libraryTest as an example, 0 is id, 1 is name.
                        string name = reader.GetString(0);
                    }

                    // Finally close the connection
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    Response.Write("error" + ex.ToString());
                }
            }

            else if (user == "m")
            {
                // The string query to specify which conditions to apply to the database and table
                // this allows us to parse the id from both tables to the session variable
                string query = "SELECT u.*, m.managementID FROM user as u INNER JOIN management as m on u.userID = m.userID WHERE email='" + uid + "' AND password='" + pass + "' AND userType='m'";

                // Prepare the connection
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    // Opening the database
                    databaseConnection.Open();

                    // Execute the query
                    reader = commandDatabase.ExecuteReader();

                    // All succesfully executed, now do something

                    // IMPORTANT :
                    // If the query returns the result, execute the if statement, else.

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Session["managementId"] = reader["managementID"].ToString();
                            Session["userID"] = reader["userID"].ToString();
                            Response.Redirect("SIM/mgmtjobs.aspx");
                        }
                    }
                    else
                    {
                        MsgBox("Username or Password incorrect", this.Page, this);
                    }

                    while (reader.Read())
                    {
                        //GetString(id), id is the column in your database. Using libraryTest as an example, 0 is id, 1 is name.
                        string name = reader.GetString(0);
                    }

                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("error" + ex.ToString());
                }
            }
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}