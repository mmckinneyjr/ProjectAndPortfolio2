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
    class EnterActivity
    {
        public static void EnterActivityMethod(int usersID ) {
            Headers.Enter_Activity();

            bool enterActivityIsRunning = true;
            while (enterActivityIsRunning) {

                //CONNECTION STRING
                string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
                MySqlConnection conn = null;

                try {
                    //SQL STATEMENTS
                    string selectionCount_categories = "SELECT Count(*) FROM activity_categories;";
                    string selectionCount_Descriptions = "SELECT Count(*) FROM activity_descriptions;";
                    string selectionCount_Dates = "SELECT Count(*) FROM tracked_calendar_dates;";
                    string selectionCount_Times = "SELECT Count(*) FROM activity_times;";
                    string stm1 = "SELECT activity_category_id, category_description FROM activity_categories;";
                    string stm2 = "SELECT activity_description_id, activity_description from activity_descriptions;";
                    string stm3 = "SELECT calendar_date_id, calendar_date FROM tracked_calendar_dates; ";
                    string stmActivityTimes = "SELECT activity_time_id, time_spent_on_activity FROM activity_times;";
                    string enterActivity = "INSERT INTO activity_log (user_id, calendar_day, calendar_date, day_name, category_description, activity_description, time_spent_on_activity) values(@users_id, @calendar_day, @calendar_date, @day_name, @category_description, @activity_description, @time_spent_on_activity);";

                    conn = new MySqlConnection(cs);
                    conn.Open();
                    MySqlDataReader rdr = null;

                    //1 First Option (Category)
                    //==================================================================================================================================
                    //CATEGORY DISPLAY OPTIONS
                    MySqlCommand cmd1 = new MySqlCommand(stm1, conn);
                    rdr = cmd1.ExecuteReader();
                    while (rdr.Read())  {
                        Console.Write($" {$"[{rdr["activity_category_id"].ToString()}]",4} ");
                        Console.WriteLine($"[{rdr["category_description"].ToString()}]");

                    }
                    rdr.Close();

                    //PROMPT USER TO SELECT A CATEGORY
                    MySqlCommand selectionCountCategoryCmd = new MySqlCommand(selectionCount_categories, conn);
                    rdr = selectionCountCategoryCmd.ExecuteReader();
                    rdr.Read();

                    Headers.LineBreak();
                    int seletionCategory = Validation.ValidateInt(0, Convert.ToInt32(rdr["Count(*)"]), " Select A Category: ");
                    if (seletionCategory == 0) {
                        Headers.MainMenu();
                        break;
                    }
                    rdr.Close();

                    //2 Second Option (Description)
                    //==================================================================================================================================
                    Headers.Enter_Activity();
                    
                    //DESCRIPTION DISPLAY OPTIONS
                    MySqlCommand cmd2 = new MySqlCommand(stm2, conn);
                    rdr = cmd2.ExecuteReader();
                    while (rdr.Read()) {
                        Console.Write($" {$"[{rdr["activity_description_id"].ToString()}]",4} ");
                        Console.WriteLine($"[{rdr["activity_description"].ToString()}]");
                    }
                    rdr.Close();

                    //PROMPT USER TO SELECT A CATEGORY
                    MySqlCommand selectionCountDescriptionCmd = new MySqlCommand(selectionCount_Descriptions, conn);
                    rdr = selectionCountDescriptionCmd.ExecuteReader();
                    rdr.Read();

                    Headers.LineBreak();
                    int seletionDescription = Validation.ValidateInt(0, Convert.ToInt32(rdr["Count(*)"]), " Select A Description: ");
                    if (seletionDescription == 0) {
                        Headers.MainMenu();
                        break;
                    }
                    rdr.Close();


                    //3 Third Option (Date)
                    //==================================================================================================================================
                    Headers.Enter_Activity();

                    //DATES DISPLAY OPTIONS
                    MySqlCommand cmd3 = new MySqlCommand(stm3, conn);
                    rdr = cmd3.ExecuteReader();
                    while (rdr.Read()) {
                        DateTime date = Convert.ToDateTime(rdr["calendar_date"]);
                        string dateString = date.ToString("dd MMMM yyyy");
                        Console.Write($" {$"[{rdr["calendar_date_id"].ToString()}]",4} ");
                        Console.WriteLine($"{dateString}");
                    }
                    rdr.Close();

                    //PROMPT USER TO SELECT A DESCRIPTION
                    MySqlCommand selectionCountDateCmd = new MySqlCommand(selectionCount_Dates, conn);
                    rdr = selectionCountDateCmd.ExecuteReader();
                    rdr.Read();

                    Headers.LineBreak();
                    int seletionDate = Validation.ValidateInt(0, Convert.ToInt32(rdr["Count(*)"]), " Select A Date: ");
                    if (seletionDate == 0) {
                        Headers.MainMenu();
                        break;
                    }
                    rdr.Close();


                    //4 Fourth Option (Activity time)
                    //==================================================================================================================================
                    Headers.Enter_Activity();

                    //TIMES DISPLAY OPTIONS
                    MySqlCommand cmd4 = new MySqlCommand(stmActivityTimes, conn);
                    rdr = cmd4.ExecuteReader();
                    while (rdr.Read())  {
                        Console.Write($" {$"[{rdr["activity_time_id"].ToString()}]",4} ");
                        Console.WriteLine($"{rdr["time_spent_on_activity"]}");
                    }
                    rdr.Close();

                    //PROMPT USER TO SELECT A DESCRIPTION
                    MySqlCommand selectionCountTimeCmd = new MySqlCommand(selectionCount_Times, conn);
                    rdr = selectionCountTimeCmd.ExecuteReader();
                    rdr.Read();

                    Headers.LineBreak();

                    int inputTimeSpent = Validation.ValidateInt(0, Convert.ToInt32(rdr["Count(*)"]), " How Long Did You Perform That Activity?: ");
                    if (inputTimeSpent == 0) {
                        Headers.MainMenu();
                        break;
                    }
                    rdr.Close();

                    MySqlCommand cmdInsert = new MySqlCommand(enterActivity, conn);

                    cmdInsert.Parameters.AddWithValue("@users_Id", usersID);
                    cmdInsert.Parameters.AddWithValue("@calendar_day", seletionDate);
                    cmdInsert.Parameters.AddWithValue("@calendar_date", seletionDate);
                    cmdInsert.Parameters.AddWithValue("@day_name", dayName(seletionDate));
                    cmdInsert.Parameters.AddWithValue("@category_description", seletionCategory);
                    cmdInsert.Parameters.AddWithValue("@activity_description", seletionDescription);
                    cmdInsert.Parameters.AddWithValue("@time_spent_on_activity", inputTimeSpent);

                    cmdInsert.ExecuteNonQuery();

                    Headers.MainMenu();
                    Console.WriteLine(" Your activity has successfully been added!\r\n");
                }

                catch (MySqlException ex)  {
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

        public static int dayName(int num) {
            if (num == 1 || num == 8 || num == 15 || num == 22) { return 1; }
            else if (num == 2 || num == 9 || num == 16 || num == 23) { return 2; }
            else if (num == 3 || num == 10 || num == 17 || num == 24) { return 3; }
            else if (num == 4 || num == 11 || num == 18 || num == 25) { return 4; }
            else if (num == 5 || num == 12 || num == 19 || num == 26)  { return 5; }
            else if (num == 6 || num == 13 || num == 20 || num == 27) { return 6; }
            else  { return 7; }
        }
    }
}
