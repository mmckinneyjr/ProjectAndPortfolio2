using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace TimerTracker
{
    class ViewTracked
    {

        public static void ByDate(int usersID) {
            Headers.ViewTrackerByDate();

            bool isRunning = true;
            while (isRunning) {

                //CONNECTION STRING
                string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
            MySqlConnection conn = null;

                try  {
                    //SQL STATEMENTS
                    string selectionCount = "SELECT Count(*) FROM tracked_calendar_dates;";
                    string stm1 = "SELECT calendar_date_id, calendar_date FROM tracked_calendar_dates; ";
                    string stm2 = "SELECT tracked_calendar_days.calendar_numerical_day, tracked_calendar_dates.calendar_date, days_of_week.day_name, activity_categories.category_description, activity_descriptions.activity_description, activity_times.time_spent_on_activity from activity_log join time_tracker_users on time_tracker_users.user_id = activity_log.user_id join tracked_calendar_days on tracked_calendar_days.calendar_day_id = activity_log.calendar_day join tracked_calendar_dates on tracked_calendar_dates.calendar_date_id = activity_log.calendar_date join activity_categories on activity_categories.activity_category_id = activity_log.category_description join activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description join activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity join days_of_week on days_of_week.day_id = activity_log.day_name where tracked_calendar_dates.calendar_date_id = @selectDate and activity_log.user_id = @userID;";
                    string stm3 = "SELECT SUM(activity_times.time_spent_on_activity) as SumActivity, tracked_calendar_dates.calendar_date FROM activity_log JOIN tracked_calendar_dates on tracked_calendar_dates.calendar_date_id = activity_log.calendar_date JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE tracked_calendar_dates.calendar_date_id = @selectedDate and activity_log.user_id = @users_Id GROUP BY tracked_calendar_dates.calendar_date; ";

                    conn = new MySqlConnection(cs);
                    conn.Open();
                    MySqlDataReader rdr = null;

                    //DISPLAY OPTIONS
                    MySqlCommand cmd1 = new MySqlCommand(stm1, conn);
                    rdr = cmd1.ExecuteReader();
                    while (rdr.Read())  {
                        DateTime date = Convert.ToDateTime(rdr["calendar_date"]);
                        string dateString = date.ToString("dd MMMM yyyy");
                        Console.Write($" {$"[{rdr["calendar_date_id"].ToString()}]",4} ");
                        Console.WriteLine($"{dateString}");
                    }
                    rdr.Close();

                    //PROMPT USER TO SELECT A DATE
                    MySqlCommand selectionCountCmd = new MySqlCommand(selectionCount, conn);
                    rdr = selectionCountCmd.ExecuteReader();
                    rdr.Read();

                    Headers.LineBreak();
                    int itemId = Validation.ValidateInt(0, Convert.ToInt32(rdr["Count(*)"]), " Select Date: ");
                    if (itemId == 0)  {
                        Headers.MainMenu();
                        break;
                    }
                    rdr.Close();

                    MySqlCommand cmd2 = new MySqlCommand(stm2, conn);
                    cmd2.Parameters.AddWithValue("@userID", usersID);
                    cmd2.Parameters.AddWithValue("@selectDate", itemId);
                    rdr = cmd2.ExecuteReader();

                    Headers.ViewTracked();
                    rdr.Read();
                    if (!(rdr.HasRows)) {

                        Console.WriteLine($" There is not activity to display for that date\r\n");
                    }

                    else  {
                        DateTime dob_datetime = Convert.ToDateTime(rdr["calendar_date"]);
                        string dateString2 = dob_datetime.ToString("dd MMMM yyyy");

                        Console.WriteLine($" {rdr["day_name"].ToString().ToUpper()} {dateString2.ToUpper()}:\r\n");
                        Console.WriteLine("  #  Category                 Activity                                Time Spent");
                        Headers.LineBreak2();
                        rdr.Close();
                        rdr = cmd2.ExecuteReader();

                        //ACTIVITY DISPLAYED
                        int counter = 1;
                        while (rdr.Read()) {
                            Console.Write($" [{counter++}] ");
                            Console.Write($"{rdr["category_description"].ToString(),-25}");
                            Console.Write($"{rdr["activity_description"].ToString(),-40}");
                            Console.WriteLine($"{rdr["time_spent_on_activity"].ToString()}");
                        }
                        rdr.Close();

                        MySqlCommand cmd3 = new MySqlCommand(stm3, conn);

                        cmd3.Parameters.AddWithValue("@users_Id", usersID);
                        cmd3.Parameters.AddWithValue("@selectedDate", itemId);
                        rdr = cmd3.ExecuteReader();
                        rdr.Read();

                        Headers.LineBreak2();

                        if (!rdr.HasRows)
                        {
                            Console.WriteLine($" There is not activity to display that date\r\n");
                        }

                        else
                        {
                            Console.WriteLine($" Activity Time Tracked: {rdr["SumActivity"].ToString()} hours");
                            Console.WriteLine($" Activity Time Untracked: {(24 - Convert.ToDouble(rdr["SumActivity"])).ToString()} hours");
                        }
                        Headers.LineBreak();
                    }
                }
                catch (MySqlException ex) {
                    Console.WriteLine("Error: {0}", ex.ToString());
                }
                finally {
                    if (conn != null) {
                        conn.Close();
                    }
                }
            conn.Close();
            break;
        }
    }

        public static void ByCategory(int usersID) {
            Headers.ViewTrackerByCategory();

            bool isRunning = true;
            while (isRunning)  {

                // MySQL Database Connection String
                string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";

                // Declare a MySQL Connection
                MySqlConnection conn = null;

                try {
                    string stm1 = "SELECT activity_category_id, category_description FROM activity_categories;";
                    string stm2 = "SELECT tracked_calendar_days.calendar_numerical_day, tracked_calendar_dates.calendar_date, days_of_week.day_name, activity_categories.category_description, activity_descriptions.activity_description, activity_times.time_spent_on_activity from activity_log join time_tracker_users on time_tracker_users.user_id = activity_log.user_id join tracked_calendar_days on tracked_calendar_days.calendar_day_id = activity_log.calendar_day join tracked_calendar_dates on tracked_calendar_dates.calendar_date_id = activity_log.calendar_date join activity_categories on activity_categories.activity_category_id = activity_log.category_description join activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description join activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity join days_of_week on days_of_week.day_id = activity_log.day_name where activity_categories.activity_category_id = @selectCategory and activity_log.user_id = @userID;";
                    string stm3 = "SELECT SUM(activity_times.time_spent_on_activity) as SumActivity, activity_categories.category_description FROM activity_log JOIN activity_categories on activity_categories.activity_category_id = activity_log.category_description JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_categories.activity_category_id = @selectedCategory and activity_log.user_id = @userID GROUP BY activity_categories.category_description ;";
                    string CategoryCount = "SELECT Count(*) FROM activity_categories;";


                    conn = new MySqlConnection(cs);
                    conn.Open();
                    MySqlDataReader rdr = null;

                    //DISPLAY CATEGORIES
                    MySqlCommand cmd1 = new MySqlCommand(stm1, conn);
                    rdr = cmd1.ExecuteReader();
                        while (rdr.Read())  {
                            Console.Write($" {$"[{rdr["activity_category_id"].ToString()}]",4} ");
                            Console.WriteLine($"{rdr["category_description"]}");
                        }                 
                    rdr.Close();

                    //PROMPT USER TO SELECT A CATEGORY
                    MySqlCommand selectionCountCmd = new MySqlCommand(CategoryCount, conn);
                    rdr = selectionCountCmd.ExecuteReader();
                    rdr.Read();

                    Headers.LineBreak();
                    int categoryId = Validation.ValidateInt(0, Convert.ToInt32(rdr["Count(*)"]), " Select Date: ");
                    if (categoryId == 0) {
                        Headers.MainMenu();
                        break;
                    }
                    rdr.Close();

                    Headers.ViewTracked();
                    MySqlCommand cmd2 = new MySqlCommand(stm2, conn);

                    cmd2.Parameters.AddWithValue("@userID", usersID);
                    cmd2.Parameters.AddWithValue("@selectCategory", categoryId);
                    rdr = cmd2.ExecuteReader();
                    rdr.Read();

                    if (!rdr.HasRows)
                    {
                        Console.WriteLine($" There is not activity to display for that date");

                    }

                    else
                    {

                        Console.WriteLine($" CATEGORY: {rdr["category_description"].ToString().ToUpper()}:\r\n");
                    Console.WriteLine("  #  Date                Category       Activity                               Time Spent");
                    Headers.LineBreak2();
                    rdr.Close();
                    rdr = cmd2.ExecuteReader();



                        //ACTIVITY DISPLAYED
                        int counter = 1;
                        while (rdr.Read())
                        {
                            Console.Write($" [{counter++}] ");
                            DateTime date = Convert.ToDateTime(rdr["calendar_date"]);
                            string dateString = date.ToString("dd MMMM yyyy");

                            Console.Write($"{dateString,-20}");
                            Console.Write($"{rdr["category_description"].ToString(),-15}");
                            Console.Write($"{rdr["activity_description"].ToString(),-39}");
                            Console.WriteLine($"{rdr["time_spent_on_activity"].ToString()}");

                        }
                        rdr.Close();

                        MySqlCommand cmd3 = new MySqlCommand(stm3, conn);
                        cmd3.Parameters.AddWithValue("@userID", usersID);
                        cmd3.Parameters.AddWithValue("@selectedCategory", categoryId);
                        rdr = cmd3.ExecuteReader();
                        rdr.Read();


                        Console.WriteLine($"\r\n Category {rdr["category_description"].ToString()} Total: {rdr["SumActivity"].ToString()} hours");
                    }
                    rdr.Close();
                    Headers.LineBreak();
                }


                catch (MySqlException ex)  {
                    Console.WriteLine("Error: {0}", ex.ToString());
                }

                finally  {
                    if (conn != null) {
                        conn.Close();
                    }
                }

                conn.Close();
                break;
            }
        }

        public static void ByDescription(int usersID) {
            Headers.ViewTrackerByDescription();

            bool isRunning = true;
            while (isRunning)  {

                // MySQL Database Connection String
                string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";

                // Declare a MySQL Connection
                MySqlConnection conn = null;

                try {
                    string stm1 = "SELECT activity_description_id, activity_description FROM activity_descriptions;";
                    string stm2 = "SELECT tracked_calendar_days.calendar_numerical_day, tracked_calendar_dates.calendar_date, days_of_week.day_name, activity_categories.category_description, activity_descriptions.activity_description, activity_times.time_spent_on_activity from activity_log join time_tracker_users on time_tracker_users.user_id = activity_log.user_id join tracked_calendar_days on tracked_calendar_days.calendar_day_id = activity_log.calendar_day join tracked_calendar_dates on tracked_calendar_dates.calendar_date_id = activity_log.calendar_date join activity_categories on activity_categories.activity_category_id = activity_log.category_description join activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description join activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity join days_of_week on days_of_week.day_id = activity_log.day_name where activity_descriptions.activity_description_id = @selectDescription and activity_log.user_id = @userID;";
                    string DescriptionCounts = "SELECT Count(*) FROM activity_descriptions;";

                    conn = new MySqlConnection(cs);
                    conn.Open();
                    MySqlDataReader rdr = null;

                    MySqlCommand cmd1 = new MySqlCommand(stm1, conn);
                    rdr = cmd1.ExecuteReader();
                    while (rdr.Read())
                    {
                        Console.Write($" {$"[{rdr["activity_description_id"].ToString()}]",4} ");
                        Console.WriteLine($"{rdr["activity_description"]}");
                    }

                    rdr.Close();

                    //PROMPT USER TO SELECT A DATE
                    MySqlCommand selectionCountCmd = new MySqlCommand(DescriptionCounts, conn);
                    rdr = selectionCountCmd.ExecuteReader();
                    rdr.Read();

                    Headers.LineBreak();
                    int descriptionId = Validation.ValidateInt(0, Convert.ToInt32(rdr["Count(*)"]), " Select Date: ");
                    if (descriptionId == 0)  {
                        Headers.MainMenu();

                        break;
                    }
                    rdr.Close();

                    Headers.ViewTracked();
                    MySqlCommand cmd2 = new MySqlCommand(stm2, conn);
                    cmd2.Parameters.AddWithValue("@userID", usersID);
                    cmd2.Parameters.AddWithValue("@selectDescription", descriptionId);
                    rdr = cmd2.ExecuteReader();
                    rdr.Read();

                    if (!rdr.HasRows)  {
                        Console.WriteLine($" There is not activity to display for that date");
                        Headers.LineBreak();
                    }

                    else
                    {

                        Console.WriteLine($" CATEGORY: {rdr["activity_description"].ToString().ToUpper()}:\r\n");
                    Console.WriteLine("  #  Date                Activity Description                     Time Spent");
                    Headers.LineBreak2();
                    rdr.Close();
                    rdr = cmd2.ExecuteReader();



                        //ACTIVITY DISPLAYED
                        int counter = 1;
                        while (rdr.Read())
                        {
                            Console.Write($" [{counter++}] ");
                            DateTime date = Convert.ToDateTime(rdr["calendar_date"]);
                            string dateString = date.ToString("dd MMMM yyyy");

                            Console.Write($"{dateString,-20}");
                            Console.Write($"{rdr["activity_description"].ToString(),-39}");
                            Console.WriteLine($"{rdr["time_spent_on_activity"].ToString()}");
                        }
                        rdr.Close();
                        Headers.LineBreak();
                    }
                }

                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: {0}", ex.ToString());
                }

                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                conn.Close();
                break;
            } 
        }

    }  
}
