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
    class RunCalculations
    {

        //Total Time Spent sleeping
        public static void Calc1_TimeSpentSleeping(int userID, int num) {

            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
            MySqlConnection conn = null;
            MySqlConnection conn2 = null;

            try  {
                //SQL STATEMENTS
                string calc1_TimeSpentSleeping = "SELECT activity_descriptions.activity_description, SUM(activity_times.time_spent_on_activity) as SumActivity FROM activity_log JOIN activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_descriptions.activity_description_id = 1 and activity_log.user_id = @userID GROUP BY activity_descriptions.activity_description;";
                string calc_Count = "SELECT Count(*) as count FROM tracked_calendar_dates;";

                //Open Connection
                conn = new MySqlConnection(cs);
                conn2 = new MySqlConnection(cs);

                conn.Open();
                conn2.Open();

                MySqlDataReader rdr = null;
                MySqlDataReader rdr2 = null;

                //Calculation
                MySqlCommand cmd1 = new MySqlCommand(calc1_TimeSpentSleeping, conn);
                cmd1.Parameters.AddWithValue("@userID", userID);

                MySqlCommand cmd2 = new MySqlCommand(calc_Count, conn2);
                rdr = cmd1.ExecuteReader();
                rdr2 = cmd2.ExecuteReader();

                Headers.CalculationsMainMenu();
                //DISPLAY OPTIONS
                rdr.Read();
                rdr2.Read();

                if (!rdr.HasRows) {
                    Console.WriteLine(" You have not spent anytime on this activity");
                }
                else {

                    Console.WriteLine($" [{num}] Total time spent sleeping in {rdr2["count"].ToString()} days: {rdr["SumActivity"].ToString()} hours");
                }
                Headers.LineBreak();
                rdr.Close();
                rdr2.Close();

            }

            catch (MySqlException ex)  {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally {
                if (conn != null || conn2 != null)  {
                    conn.Close();
                    conn2.Close();

                }
            }
            conn.Close();
            conn2.Close();

        }

        //Percent  Spent sleeping
        public static void Calc2_SleepPercent(int userID, int num)  {

            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
            MySqlConnection conn = null;
            MySqlConnection conn2 = null;
            MySqlConnection conn3 = null;

            try  {
                //SQL STATEMENTS
                string calc1_TimeSpentSleeping = "SELECT activity_descriptions.activity_description, SUM(activity_times.time_spent_on_activity) as SumActivity FROM activity_log JOIN activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_descriptions.activity_description_id = 1 and activity_log.user_id = @userID GROUP BY activity_descriptions.activity_description;";
                string calc_Count = "SELECT Count(*) as count FROM tracked_calendar_dates;";
                string calc_TotalSUM = "SELECT Sum(activity_times.time_spent_on_activity) as Total FROM activity_log JOIN activity_times ON activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_log.user_id = @userID;";

                //Open Connection
                conn = new MySqlConnection(cs);
                conn2 = new MySqlConnection(cs);
                conn3 = new MySqlConnection(cs);

                conn.Open();
                conn2.Open();
                conn3.Open();

                MySqlDataReader rdr = null;
                MySqlDataReader rdr2 = null;
                MySqlDataReader rdr3 = null;

                //Calculation
                MySqlCommand cmd1 = new MySqlCommand(calc1_TimeSpentSleeping, conn);
                cmd1.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd2 = new MySqlCommand(calc_Count, conn2);
                cmd2.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd3 = new MySqlCommand(calc_TotalSUM, conn3);
                cmd3.Parameters.AddWithValue("@userID", userID);

                rdr = cmd1.ExecuteReader();
                rdr2 = cmd2.ExecuteReader();
                rdr3 = cmd3.ExecuteReader();

                Headers.CalculationsMainMenu();
                //DISPLAY OPTIONS
                rdr.Read();
                rdr2.Read();
                rdr3.Read();

                if (!rdr.HasRows) {
                    Console.WriteLine(" You have not spent anytime on this activity");
                }
                else  {

                    int sleepPercent = (int)Math.Round( Convert.ToDecimal(rdr["SumActivity"])/ Convert.ToDecimal(rdr3["Total"]) * 100);
                    Console.WriteLine($" [{num}] The percentage of time spent sleeping over {rdr2["count"].ToString()} days: {sleepPercent}%");
                }
                Headers.LineBreak();
                rdr.Close();
                rdr2.Close();
                rdr3.Close();

            }

            catch (MySqlException ex)  {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally {
                if (conn != null || conn2 != null || conn3 != null) {
                    conn.Close();
                    conn2.Close();
                    conn3.Close();
                }
            }
            conn.Close();
            conn2.Close();
            conn3.Close();
        }

        //Total Time Spent Working on School Work
        public static void Calc3_TimeSpentOnHW(int userID, int num) {

            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
            MySqlConnection conn = null;
            MySqlConnection conn2 = null;

            try {
                //SQL STATEMENTS
                string calc_TimeSpentOnHW = "SELECT activity_descriptions.activity_description, SUM(activity_times.time_spent_on_activity) as SumActivity FROM activity_log JOIN activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_descriptions.activity_description_id = 9 and activity_log.user_id = @userID GROUP BY activity_descriptions.activity_description;";
                string calc_Count = "SELECT Count(*) as count FROM tracked_calendar_dates;";


                //Open Connection
                conn = new MySqlConnection(cs);
                conn2 = new MySqlConnection(cs);

                conn.Open();
                conn2.Open();

                MySqlDataReader rdr = null;
                MySqlDataReader rdr2 = null;

                //Calculation
                MySqlCommand cmd1 = new MySqlCommand(calc_TimeSpentOnHW, conn);
                cmd1.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd2 = new MySqlCommand(calc_Count, conn2);

                rdr = cmd1.ExecuteReader();
                rdr2 = cmd2.ExecuteReader();

                Headers.CalculationsMainMenu();
                //DISPLAY OPTIONS
                rdr.Read();
                rdr2.Read();

                if (!rdr.HasRows) {
                    Console.WriteLine(" You have not spent anytime on this activity");
                }
                else {

                    Console.WriteLine($" [{num}] Total time spent doing Homework in {rdr2["count"].ToString()} days: {rdr["SumActivity"].ToString()} hours");
                }
                Headers.LineBreak();
                rdr.Close();
                rdr2.Close();

            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (conn != null || conn2 != null)
                {
                    conn.Close();
                    conn2.Close();

                }
            }
            conn.Close();
            conn2.Close();

        }

        //Percent of time doing homework during month
        public static void Calc4_HWPercent(int userID, int num)  {

            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
            MySqlConnection conn = null;
            MySqlConnection conn2 = null;
            MySqlConnection conn3 = null;

            try {
                //SQL STATEMENTS
                string calc1_TimeSpentSleeping = "SELECT activity_descriptions.activity_description, SUM(activity_times.time_spent_on_activity) as SumActivity FROM activity_log JOIN activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_descriptions.activity_description_id = 9 and activity_log.user_id = @userID GROUP BY activity_descriptions.activity_description;";
                string calc_Count = "SELECT Count(*) as count FROM tracked_calendar_dates;";
                string calc_TotalSUM = "SELECT Sum(activity_times.time_spent_on_activity) as Total FROM activity_log JOIN activity_times ON activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_log.user_id = @userID;";

                //Open Connection
                conn = new MySqlConnection(cs);
                conn2 = new MySqlConnection(cs);
                conn3 = new MySqlConnection(cs);

                conn.Open();
                conn2.Open();
                conn3.Open();

                MySqlDataReader rdr = null;
                MySqlDataReader rdr2 = null;
                MySqlDataReader rdr3 = null;

                //Calculation
                MySqlCommand cmd1 = new MySqlCommand(calc1_TimeSpentSleeping, conn);
                cmd1.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd2 = new MySqlCommand(calc_Count, conn2);
                MySqlCommand cmd3 = new MySqlCommand(calc_TotalSUM, conn3);
                cmd3.Parameters.AddWithValue("@userID", userID);

                rdr = cmd1.ExecuteReader();
                rdr2 = cmd2.ExecuteReader();
                rdr3 = cmd3.ExecuteReader();

                Headers.CalculationsMainMenu();
                //DISPLAY OPTIONS
                rdr.Read();
                rdr2.Read();
                rdr3.Read();

                if (!rdr.HasRows) {
                    Console.WriteLine(" You have not spent anytime on this activity");
                }
                else  {

                    int sleepPercent = (int)Math.Round(Convert.ToDecimal(rdr["SumActivity"])/(Convert.ToDecimal(rdr3["Total"])) * 100);
                    Console.WriteLine($" [{num}] The percentage of time spent sleeping over {rdr2["count"].ToString()} days: {sleepPercent}%");
                }
                Headers.LineBreak();
                rdr.Close();
                rdr2.Close();
                rdr3.Close();

            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (conn != null || conn2 != null || conn3 != null)
                {
                    conn.Close();
                    conn2.Close();
                    conn3.Close();
                }
            }
            conn.Close();
            conn2.Close();
            conn3.Close();
        }

        //Time spent driving during month
        public static void Calc5(int userID, int num)  {

            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
            MySqlConnection conn = null;
            MySqlConnection conn2 = null;
            MySqlConnection conn3 = null;

            try {
                //SQL STATEMENTS
                string calc_drivingTo = "SELECT activity_descriptions.activity_description, SUM(activity_times.time_spent_on_activity) as SumActivity1 FROM activity_log JOIN activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_descriptions.activity_description_id = 3 and activity_log.user_id = @userID GROUP BY activity_descriptions.activity_description; ";
                string calc_drivingFrom = "SELECT activity_descriptions.activity_description, SUM(activity_times.time_spent_on_activity) as SumActivity2 FROM activity_log JOIN activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_descriptions.activity_description_id = 12 and activity_log.user_id = @userID GROUP BY activity_descriptions.activity_description; ";
                string calc_Count = "SELECT Count(*) as count FROM tracked_calendar_dates;";

                //Open Connection
                conn = new MySqlConnection(cs);
                conn2 = new MySqlConnection(cs);
                conn3 = new MySqlConnection(cs);

                conn.Open();
                conn2.Open();
                conn3.Open();

                MySqlDataReader rdr = null;
                MySqlDataReader rdr2 = null;
                MySqlDataReader rdr3 = null;

                //Calculation
                MySqlCommand cmd1 = new MySqlCommand(calc_drivingTo, conn);
                cmd1.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd2 = new MySqlCommand(calc_drivingFrom, conn2);
                cmd2.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd3 = new MySqlCommand(calc_Count, conn3);

                rdr = cmd1.ExecuteReader();
                rdr2 = cmd2.ExecuteReader();
                rdr3 = cmd3.ExecuteReader();

                Headers.CalculationsMainMenu();
                //DISPLAY OPTIONS
                rdr.Read();
                rdr2.Read();
                rdr3.Read();

                if (!rdr.HasRows)  {
                    Console.WriteLine(" You have not spent anytime on this activity");
                }
                else
                {

                    decimal driving = Convert.ToDecimal(rdr["SumActivity1"]) +  Convert.ToDecimal(rdr2["SumActivity2"]);
                    Console.WriteLine($" [{num}] Total TIme Spent Driving over {rdr3["count"].ToString()} days: {driving} hours");
                }
                Headers.LineBreak();
                rdr.Close();
                rdr2.Close();
                rdr3.Close();

            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (conn != null || conn2 != null || conn3 != null)
                {
                    conn.Close();
                    conn2.Close();
                    conn3.Close();
                }
            }
            conn.Close();
            conn2.Close();
            conn3.Close();
        }

        //Percent spent driving during month
        public static void Calc6(int userID, int num)  {

            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
            MySqlConnection conn = null;
            MySqlConnection conn2 = null;
            MySqlConnection conn3 = null;
            MySqlConnection conn4 = null;

            try {
                //SQL STATEMENTS
                string calc_drivingTo = "SELECT activity_descriptions.activity_description, SUM(activity_times.time_spent_on_activity) as SumActivity1 FROM activity_log JOIN activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_descriptions.activity_description_id = 3 and activity_log.user_id = @userID GROUP BY activity_descriptions.activity_description; ";
                string calc_drivingFrom = "SELECT activity_descriptions.activity_description, SUM(activity_times.time_spent_on_activity) as SumActivity2 FROM activity_log JOIN activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_descriptions.activity_description_id = 12 and activity_log.user_id = @userID GROUP BY activity_descriptions.activity_description; ";
                string calc_Count = "SELECT Count(*) as count FROM tracked_calendar_dates;";
                string calc_TotalSUM = "SELECT Sum(activity_times.time_spent_on_activity) as Total FROM activity_log JOIN activity_times ON activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_log.user_id = @userID;";

                //Open Connection
                conn = new MySqlConnection(cs);
                conn2 = new MySqlConnection(cs);
                conn3 = new MySqlConnection(cs);
                conn4 = new MySqlConnection(cs);

                conn.Open();
                conn2.Open();
                conn3.Open();
                conn4.Open();

                MySqlDataReader rdr = null;
                MySqlDataReader rdr2 = null;
                MySqlDataReader rdr3 = null;
                MySqlDataReader rdr4 = null;

                //Calculation
                MySqlCommand cmd1 = new MySqlCommand(calc_drivingTo, conn);
                cmd1.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd2 = new MySqlCommand(calc_drivingFrom, conn2);
                cmd2.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd3 = new MySqlCommand(calc_TotalSUM, conn3);
                cmd3.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd4 = new MySqlCommand(calc_Count, conn4);

                rdr = cmd1.ExecuteReader();
                rdr2 = cmd2.ExecuteReader();
                rdr3 = cmd3.ExecuteReader();
                rdr4 = cmd4.ExecuteReader();

                Headers.CalculationsMainMenu();
                //DISPLAY OPTIONS
                rdr.Read();
                rdr2.Read();
                rdr3.Read();
                rdr4.Read();

                if (!rdr.HasRows) {
                    Console.WriteLine(" You have not spent anytime on this activity");
                }
                else {

                    decimal driving = Convert.ToDecimal(rdr["SumActivity1"]) + Convert.ToDecimal(rdr2["SumActivity2"]);
                    int drivingPercent = (int)Math.Round((driving) / (Convert.ToDecimal(rdr3["Total"])) * 100);
                    Console.WriteLine($" [{num}] Total TIme Spent Driving over {rdr4["count"].ToString()} days: {drivingPercent}%");
                }
                Headers.LineBreak();
                rdr.Close();
                rdr2.Close();
                rdr3.Close();
                rdr4.Close();
            }

            catch (MySqlException ex) {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally {
                if (conn != null || conn2 != null || conn3 != null) {
                    conn.Close();
                    conn2.Close();
                    conn3.Close();
                    conn4.Close();
                }
            }
            conn.Close();
            conn2.Close();
            conn3.Close();
            conn3.Close();
        }

        //Total Time Spent Working Out
        public static void Calc7(int userID, int num) {

            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
            MySqlConnection conn = null;
            MySqlConnection conn2 = null;

            try  {
                //SQL STATEMENTS
                string calc_TimeSpentAtGym = "SELECT activity_descriptions.activity_description, SUM(activity_times.time_spent_on_activity) as SumActivity FROM activity_log JOIN activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_descriptions.activity_description_id = 8 and activity_log.user_id = @userID GROUP BY activity_descriptions.activity_description;";
                string calc_Count = "SELECT Count(*) as count FROM tracked_calendar_dates;";

                //Open Connection
                conn = new MySqlConnection(cs);
                conn2 = new MySqlConnection(cs);

                conn.Open();
                conn2.Open();

                MySqlDataReader rdr = null;
                MySqlDataReader rdr2 = null;

                //Calculation
                MySqlCommand cmd1 = new MySqlCommand(calc_TimeSpentAtGym, conn);
                cmd1.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd2 = new MySqlCommand(calc_Count, conn2);

                rdr = cmd1.ExecuteReader();
                rdr2 = cmd2.ExecuteReader();

                Headers.CalculationsMainMenu();
                //DISPLAY OPTIONS
                rdr.Read();
                rdr2.Read();

                if (!rdr.HasRows)  {
                    Console.WriteLine(" You have not spent anytime on this activity");
                }
                else  {

                    Console.WriteLine($" [{num}] Total time spent Working Out in {rdr2["count"].ToString()} days: {rdr["SumActivity"].ToString()} hours (Not enough!)");
                }
                Headers.LineBreak();
                rdr.Close();
                rdr2.Close();

            }

            catch (MySqlException ex) {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally {
                if (conn != null || conn2 != null) {
                    conn.Close();
                    conn2.Close();
                }
            }
            conn.Close();
            conn2.Close();

        }

        //average time a day on hw
        public static void Calc8(int userID, int num) {

            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
            MySqlConnection conn = null;
            MySqlConnection conn2 = null;

            try  {
                //SQL STATEMENTS
                string calc_TimeSpentOnHW = "SELECT activity_descriptions.activity_description, SUM(activity_times.time_spent_on_activity) as SumActivity FROM activity_log JOIN activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_descriptions.activity_description_id = 9 and activity_log.user_id = @userID GROUP BY activity_descriptions.activity_description;";
                string calc_Count = "SELECT Count(*) as count FROM tracked_calendar_dates;";


                //Open Connection
                conn = new MySqlConnection(cs);
                conn2 = new MySqlConnection(cs);

                conn.Open();
                conn2.Open();

                MySqlDataReader rdr = null;
                MySqlDataReader rdr2 = null;



                //Calculation
                MySqlCommand cmd1 = new MySqlCommand(calc_TimeSpentOnHW, conn);
                cmd1.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd2 = new MySqlCommand(calc_Count, conn2);

                rdr = cmd1.ExecuteReader();
                rdr2 = cmd2.ExecuteReader();


                Headers.CalculationsMainMenu();
                //DISPLAY OPTIONS
                rdr.Read();
                rdr2.Read();

                if (!rdr.HasRows)  {
                    Console.WriteLine(" You have not spent anytime on this activity");
                }
                else  {
                    decimal c = Convert.ToDecimal(rdr2["count"]);
                    decimal s = Convert.ToDecimal(rdr["SumActivity"]);

                    decimal a = Math.Round((c/s),2);
                    Console.WriteLine($" [{num}] Average hours per day doing Homework over {rdr2["count"].ToString()} days: {a} hours a day");
                }
                Headers.LineBreak();
                rdr.Close();
                rdr2.Close();

            }

            catch (MySqlException ex) {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally  {
                if (conn != null || conn2 != null)
                {
                    conn.Close();
                    conn2.Close();

                }
            }
            conn.Close();
            conn2.Close();

        }

        //Total Time awake
        public static void Calc9(int userID, int num){

            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
            MySqlConnection conn = null;
            MySqlConnection conn2 = null;
            MySqlConnection conn3 = null;

            try {
                //SQL STATEMENTS
                string calc_TotalSUM = "SELECT SUM(activity_times.time_spent_on_activity) as EverythingTotal FROM activity_log JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_log.user_id = @userID;";
                string calc1_TimeSpentSleeping = "SELECT activity_descriptions.activity_description, SUM(activity_times.time_spent_on_activity) as Sleeping FROM activity_log JOIN activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_descriptions.activity_description_id = 1 and activity_log.user_id = @userID GROUP BY activity_descriptions.activity_description;";
                string calc_Count = "SELECT Count(*) as count FROM tracked_calendar_dates;";


                //Open Connection
                conn = new MySqlConnection(cs);
                conn2 = new MySqlConnection(cs);
                conn3 = new MySqlConnection(cs);

                conn.Open();
                conn2.Open();
                conn3.Open();

                MySqlDataReader rdr = null;
                MySqlDataReader rdr2 = null;
                MySqlDataReader rdr3 = null;

                //Calculation
                MySqlCommand cmd1 = new MySqlCommand(calc_TotalSUM, conn);
                cmd1.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd2 = new MySqlCommand(calc1_TimeSpentSleeping, conn2);
                cmd2.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd3 = new MySqlCommand(calc_Count, conn3);
                cmd3.Parameters.AddWithValue("@userID", userID);

                rdr = cmd1.ExecuteReader();
                rdr2 = cmd2.ExecuteReader();
                rdr3 = cmd3.ExecuteReader();

                Headers.CalculationsMainMenu();
                //DISPLAY OPTIONS
                rdr.Read();
                rdr2.Read();
                rdr3.Read();

                if (!rdr.HasRows)  {
                    Console.WriteLine(" You have not spent anytime on this activity");
                }
                else  {

                    decimal awake = Convert.ToDecimal(rdr["EverythingTotal"]) - Convert.ToDecimal(rdr2["Sleeping"]);
                    Console.WriteLine($" [{num}] Total Time Awake over {rdr3["count"].ToString()} days (not sleeping): {awake} Hours");
                    Console.WriteLine($"     Out of {rdr["EverythingTotal"].ToString()} hours tracked");
                }
                Headers.LineBreak();
                rdr.Close();
                rdr2.Close();
                rdr3.Close();
            }

            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (conn != null || conn2 != null || conn3 != null)
                {
                    conn.Close();
                    conn2.Close();
                    conn3.Close();
                }
            }
            conn.Close();
            conn2.Close();
            conn3.Close();
        }

        //Percentage of Time Awake
        public static void Calc10(int userID, int num) {

            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
            MySqlConnection conn = null;
            MySqlConnection conn2 = null;
            MySqlConnection conn3 = null;

            try {
                //SQL STATEMENTS
                string calc_TotalSUM = "SELECT SUM(activity_times.time_spent_on_activity) as EverythingTotal FROM activity_log JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_log.user_id = @userID;";
                string calc1_TimeSpentSleeping = "SELECT activity_descriptions.activity_description, SUM(activity_times.time_spent_on_activity) as Sleeping FROM activity_log JOIN activity_descriptions on activity_descriptions.activity_description_id = activity_log.activity_description JOIN activity_times on activity_times.activity_time_id = activity_log.time_spent_on_activity WHERE activity_descriptions.activity_description_id = 1 and activity_log.user_id = @userID GROUP BY activity_descriptions.activity_description;";
                string calc_Count = "SELECT Count(*) as count FROM tracked_calendar_dates;";


                //Open Connection
                conn = new MySqlConnection(cs);
                conn2 = new MySqlConnection(cs);
                conn3 = new MySqlConnection(cs);

                conn.Open();
                conn2.Open();
                conn3.Open();

                MySqlDataReader rdr = null;
                MySqlDataReader rdr2 = null;
                MySqlDataReader rdr3 = null;

                //Calculation
                MySqlCommand cmd1 = new MySqlCommand(calc_TotalSUM, conn);
                cmd1.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd2 = new MySqlCommand(calc1_TimeSpentSleeping, conn2);
                cmd2.Parameters.AddWithValue("@userID", userID);
                MySqlCommand cmd3 = new MySqlCommand(calc_Count, conn3);
                cmd3.Parameters.AddWithValue("@userID", userID);

                rdr = cmd1.ExecuteReader();
                rdr2 = cmd2.ExecuteReader();
                rdr3 = cmd3.ExecuteReader();

                Headers.CalculationsMainMenu();
                //DISPLAY OPTIONS
                rdr.Read();
                rdr2.Read();
                rdr3.Read();

                if (!rdr.HasRows) {
                    Console.WriteLine(" You have not spent anytime on this activity");
                }
                else {
                    decimal awake = Convert.ToDecimal(rdr["EverythingTotal"]) - Convert.ToDecimal(rdr2["Sleeping"]);
                    int awakePercent = (int)Math.Round((awake) / (Convert.ToDecimal(rdr["EverythingTotal"])) * 100);
                    Console.WriteLine($" [{num}] Percentage of time Awake over {rdr3["count"].ToString()} days (not sleeping): {awakePercent}%");
                }
                Headers.LineBreak();
                rdr.Close();
                rdr2.Close();
                rdr3.Close();
            }

            catch (MySqlException ex)  {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally {
                if (conn != null || conn2 != null || conn3 != null) {
                    conn.Close();
                    conn2.Close();
                    conn3.Close();
                }
            }
            conn.Close();
            conn2.Close();
            conn3.Close();
        }
    }
}
