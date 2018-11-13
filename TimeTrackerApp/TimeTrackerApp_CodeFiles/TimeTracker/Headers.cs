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
    class Headers
    {

        public static string userName(int uid) {
            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=MarkMckinney_MDV229_Database_201810; port=8889";
            MySqlConnection conn = null;
            conn = new MySqlConnection(cs);
            conn.Open();
            MySqlDataReader rdr = null;
            //SQL Statement
            string stm = "SELECT user_firstname from time_tracker_users WHERE user_id = @userid;";
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@userid", uid);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            string name = rdr["user_firstname"].ToString();
            return name;
        }

        public static void Header() {
            Console.Clear();
            LineBreak();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("        ______  ____  ___ ___    ___      ______  ____    ____    __  __  _    ___  ____  ");
            Console.WriteLine("       |      ||    ||   |   |  /  _]    |      ||    \\  /    |  /  ]|  |/ ]  /  _]|    \\ ");
            Console.WriteLine("       |      | |  | | _   _ | /  [_     |      ||  D  )|  o  | /  / |  ' /  /  [_ |  D  )");
            Console.WriteLine("       |_|  |_| |  | |  \\_/  ||    _]    |_|  |_||    / |     |/  /  |    \\ |    _]|    / ");
            Console.WriteLine("         |  |   |  | |   |   ||   [_       |  |  |    \\ |  _  /   \\_ |     \\|   [_ |    \\ ");
            Console.WriteLine("         |  |   |  | |   |   ||     |      |  |  |  .  \\|  |  \\     ||  .  ||     ||  .  \\");
            Console.WriteLine("         |__|  |____||___|___||_____|      |__|  |__|\\_||__|__|\\____||__|\\_||_____||__|\\_|");
            Console.ResetColor();
            LineBreak();
        }

        public static void MainMenu() {
            Header();
            Console.WriteLine(" Main Menu");
            Console.WriteLine($"\r\n [1] Enter Activity");
            Console.WriteLine($" [2] View Tracked Data");
            Console.WriteLine($" [3] Run Calculations");
            Console.WriteLine($"\r\n [0] Exit");
            LineBreak();
        }

        public static void Enter_Activity()  {
            Header();
            Console.WriteLine(" Enter Activity");
            Console.WriteLine($"\r\n  [0] Exit");
            LineBreak();
        }

        public static void ViewTrackerByDate() {
            Header();
            Console.WriteLine(" View By Date:");
            Console.WriteLine($"\r\n  [0] Exit");
            LineBreak();
        }

        public static void ViewTrackerByDescription() {
            Header();
            Console.WriteLine(" View By Description:");
            Console.WriteLine($"\r\n  [0] Exit");
            LineBreak();
        }

        public static void ViewTrackerByCategory()  {
            Header();
            Console.WriteLine(" View By Category:");
            Console.WriteLine($"\r\n  [0] Exit");
            LineBreak();
        }

        public static void LineBreak() {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" ==============================================================================================");
            Console.ResetColor();
        }

        public static void LineBreak2() {
            Console.WriteLine(" ----------------------------------------------------------------------------------------------");
        }

        public static void ViewTracked() {
            Header();
            Console.WriteLine(" View Tracked Data");
            Console.WriteLine($"\r\n [1] View By Date");
            Console.WriteLine($" [2] View By Category");
            Console.WriteLine($" [3] View By Description");
            Console.WriteLine($"\r\n [0] Main Menu");
            LineBreak();
        }

        public static void CalculationsMainMenu() {
            Header();
            Console.WriteLine(" Calculations: \r\n");
            Console.WriteLine("    [1] Time Spent Sleeping                     [6] Percent of Time Spent Driving During Month");
            Console.WriteLine("    [2] Percentage of time Sleeping             [7] Total Time Spent Working Out");
            Console.WriteLine("    [3] Time spent doing Homework               [8] Average Time a Day Spend on Homework");
            Console.WriteLine("    [4] Percent of Time Doing Homework          [9] Total Time Awake");
            Console.WriteLine("    [5] Time Spent Driving During Month         [10] Percentage of Time Awake");
            Console.WriteLine("\r\n    [0] Main Menu");
            LineBreak();
        }
    }
}
