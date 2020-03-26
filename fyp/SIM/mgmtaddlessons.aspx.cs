using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.UI;

namespace fyp.SIM
{
    public partial class AddLessons : System.Web.UI.Page
    {
        int UserID=0;
        int SubjectID;
        string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddLesson_Button(object sender, EventArgs e)
        {
            AddLessonPlanToDB();
        }

        protected void subjectCode_TextChanged(object sender, EventArgs e)
        {
            MySqlDataReader rdr = null;

            //Create connection
            MySqlConnection conn = new MySqlConnection(connectionString);

            //Search query
            string searchQuery = "SELECT fName, lName, userID FROM user WHERE userID = (SELECT userID from lecturer where lecturerID = " +
                            "(SELECT lecturerID FROM subject_application WHERE subjectID = (SELECT subjectID from subject_details WHERE subject_Code = '" + subjectCode.Text + "') AND subjectApp_status = 'Approved')) ";

            MySqlCommand cmd = new MySqlCommand(searchQuery, conn);

            try
            {
                //Open the connection
                conn.Open();

                // 1. get an instance of the SqlDataReader
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    // get the results of each column
                    string fName = (string)rdr["fName"];
                    string lName = (string)rdr["lName"];
                    string name = fName + " " + lName;
                    UserID = (int)rdr["userID"];
                    Session["lecturerUserID"] = (int)rdr["userID"];
                    lecturer.Text = name;
                }
            }
            finally
            {
                // 3. close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void AddLessonPlanToDB()
        {
            // Insert created job posting into database
            int lecturerID = FindLecturerID();
            string subjectName = FindSubjectDetails();
            if(CheckIfExist() == 0)
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    databaseConnection.Open();

                    // Query to insert the values into the database
                    string insertQuery = "INSERT INTO subject_lessons (subjectID, subject_Code, lecturerID, university, subject_Name, subject_Venue, subject_Date, subject_StartTime, subject_EndTime) VALUES" +
                        " (@SubjectID, @Subject_Code, @LecturerID, @university, @Subject_Name, @Subject_Venue, @Subject_Date, @Subject_StartTime, @Subject_EndTime)";

                    MySqlCommand commandDatabase = new MySqlCommand(insertQuery, databaseConnection);
                    commandDatabase.CommandTimeout = 60;

                    commandDatabase.Parameters.AddWithValue("@SubjectID", SubjectID);
                    commandDatabase.Parameters.AddWithValue("@Subject_Code", subjectCode.Text);
                    commandDatabase.Parameters.AddWithValue("@LecturerID", lecturerID);
                    commandDatabase.Parameters.AddWithValue("@university", uni_ddl.Text);
                    commandDatabase.Parameters.AddWithValue("@Subject_Name", subjectName);
                    commandDatabase.Parameters.AddWithValue("@Subject_Venue", subjectVenue.Text);
                    commandDatabase.Parameters.AddWithValue("@Subject_Date", subjectDate.Text);
                    commandDatabase.Parameters.AddWithValue("@Subject_StartTime", ddl4.Text);
                    commandDatabase.Parameters.AddWithValue("@Subject_EndTime", ddl5.Text);
                    commandDatabase.ExecuteNonQuery();

                    string script = "alert('Subject created!'); window.location='" + Request.ApplicationPath + "SIM/mgmtaddlessons.aspx'";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);

                    databaseConnection.Close();

                }
                catch (Exception ex)
                {
                    string script = "alert(\"Error!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
            }
            else
            {
                string script = "alert(\"Duplicate Detected!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }
        
        public int CheckIfExist()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();

            string query = "SELECT COUNT(*) from subject_lessons where subject_Code like @Subject_Code AND subject_Date like @Subject_Date and subject_StartTime like @Subject_StartTime and subject_EndTime like @Subject_EndTime";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.Parameters.AddWithValue("@Subject_Code", subjectCode.Text);
            commandDatabase.Parameters.AddWithValue("@Subject_Date", subjectDate.Text);
            commandDatabase.Parameters.AddWithValue("@Subject_StartTime", ddl4.Text);
            commandDatabase.Parameters.AddWithValue("@Subject_EndTime", ddl5.Text);
            int exist = int.Parse(commandDatabase.ExecuteScalar().ToString()); 
            return exist;
        }
        public int FindLecturerID()
        {
            int lecturerID=0;
            MySqlDataReader rdr = null;

            //Create connection
            MySqlConnection conn = new MySqlConnection(connectionString);

            //Search query
            string searchQuery = "SELECT lecturerID FROM lecturer WHERE userID = " + Session["lecturerUserID"];

            MySqlCommand cmd = new MySqlCommand(searchQuery, conn);

            try
            {
                //Open the connection
                conn.Open();

                // 1. get an instance of the SqlDataReader
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    // get the results of each column
                    lecturerID = (int)rdr["lecturerID"];
                }
            }
            finally
            {
                // 3. close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return lecturerID;
        }

        public string FindSubjectDetails()
        {
            string subjectName = "";
            MySqlDataReader rdr = null;

            //Create connection
            MySqlConnection conn = new MySqlConnection(connectionString);

            //Search query
            string searchQuery = "SELECT subjectID, subject_Name FROM subject_details WHERE subject_Code = '" + subjectCode.Text + "'";

            MySqlCommand cmd = new MySqlCommand(searchQuery, conn);

            try
            {
                //Open the connection
                conn.Open();

                // 1. get an instance of the SqlDataReader
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    // get the results of each column
                    subjectName = (string)rdr["subject_Name"];
                    SubjectID = (int)rdr["subjectID"];
                }
            }
            finally
            {
                // 3. close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return subjectName;
        }
    }
}