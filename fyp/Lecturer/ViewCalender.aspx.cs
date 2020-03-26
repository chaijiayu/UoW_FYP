using System;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace fyp.Lecturer
{
    public partial class ViewCalender : System.Web.UI.Page
    {
        Dictionary<string, List<string>> scheduleList = new Dictionary<string, List<string>>();
        string connectionString = ConfigurationManager.ConnectionStrings["fypConnectionString"].ConnectionString;
        String temp;

        protected void Page_Load(object sender, EventArgs e)
        {
            scheduleList = Getschedule();
            Calendar1.FirstDayOfWeek = FirstDayOfWeek.Sunday;
            Calendar1.NextPrevFormat = NextPrevFormat.ShortMonth;
            Calendar1.TitleFormat = TitleFormat.Month;
            Calendar1.ShowGridLines = true;
            Calendar1.DayStyle.Height = new Unit(100);
            Calendar1.DayStyle.Width = new Unit(200);
            Calendar1.DayStyle.HorizontalAlign = HorizontalAlign.Center;
            Calendar1.DayStyle.VerticalAlign = VerticalAlign.Middle;
            Calendar1.OtherMonthDayStyle.BackColor = System.Drawing.Color.AliceBlue;
        }

        private Dictionary<string, List<string>> Getschedule()
        {
            Dictionary<string, List<string>> schedule = new Dictionary<string, List<string>>();

            MySqlDataReader rdr = null;

            //Create connection
            MySqlConnection conn = new MySqlConnection(connectionString);

            //Search query
            string query = "SELECT * FROM subject_lessons WHERE lecturerID =(SELECT lecturerID FROM lecturer WHERE userID =  " + Session["userID"] + ")";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                //Open the connection
                conn.Open();

                // 1. get an instance of the SqlDataReader
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    // get the results of each column
                    string subjectName = (string)rdr["subject_Name"];
                    string subjectDate = (string)rdr["subject_Date"].ToString();
                    string subjectStartTime = (string)rdr["subject_StartTime"].ToString();
                    string subjectEndTime = (string)rdr["subject_EndTime"].ToString();
                    string subjectVenue = (string)rdr["subject_Venue"].ToString();
                    string subjectCode = (string)rdr["subject_Code"].ToString();
                    subjectStartTime = subjectStartTime.Substring(0, subjectStartTime.Length - 3);
                    subjectEndTime = subjectEndTime.Substring(0, subjectEndTime.Length - 3);
                    string lessonOutput = subjectName + " " + subjectCode  + "<br/>" + subjectVenue + "<br />" + subjectStartTime + " - " + subjectEndTime;
                    AddValueToDict(schedule, subjectDate, lessonOutput);
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

            return schedule;
        }

        //Method to add values to the dictionary.
        public void AddValueToDict(Dictionary<string, List<string>> internalDictionary, string key, string value)
        {
            if (internalDictionary.ContainsKey(key))
            {
                List<string> list = internalDictionary[key];
                if (list.Contains(value) == false)
                {
                    list.Add(value);
                }
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(value);
                internalDictionary.Add(key, list);
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            //iterate through each key in the dictionary
            foreach (KeyValuePair<string, List<string>> item in scheduleList)
            {
                //if the key (date) is the same date
                if (item.Key == e.Day.Date.ToString())
                {
                    // concatenates all the lessons into a temporary string
                    foreach (var lesson in item.Value)
                    {
                        temp += lesson;
                        temp += "<br/>";
                    }
                    Literal literal1 = new Literal();
                    literal1.Text = "<br/>";    
                    e.Cell.Controls.Add(literal1);  
                    Label label1 = new Label();
                    label1.Text = temp;
                    label1.Font.Size = new FontUnit(FontSize.Smaller);
                    e.Cell.Controls.Add(label1);
                    e.Cell.BackColor = System.Drawing.Color.LightSkyBlue;
                    e.Cell.ToolTip = 
                    temp = "";
                }
            }
        }
    }
}