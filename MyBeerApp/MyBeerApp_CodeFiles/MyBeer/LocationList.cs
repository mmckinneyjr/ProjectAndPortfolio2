using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace MyBeer
{
    class LocationList
    {

        public static void LocationData(string user)  {
            Connection.OpenConnection();
            DataTable data = Connection.QueryDB("SELECT DISTINCT(locationID), pubName,locationAddress,locationCity,locationState,locationZipCode FROM Locations;");
            DataRowCollection rows = data.Rows;

            foreach (DataRow row in rows) {
                Location.locationList.Add(new Location(row["locationID"].ToString(), row["pubName"].ToString(), row["locationAddress"].ToString(), row["locationCity"].ToString(), row["locationState"].ToString(), row["locationZipCode"].ToString()));
            }

            Connection.CloseConnection();
        }

        public static void LocationDisplay(string user, List<Location> locationList) {
            Console.WriteLine("  #   LOCATION");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" =================================================================================================================");
            Console.ResetColor();

            foreach (var loc in locationList) {
                string a = loc._locationID;
                string b = loc._locationName.ToUpper();
                string c = loc._locationAddress;
                string d = loc._locationCity;
                string e = loc._locationState;
                string f = loc._locationZip;

                //menu number
                Console.Write($" {"["+a+"]",-3} ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($" {b}");
                Console.ResetColor();
                Console.WriteLine($"\r\n      {c}\r\n      {d}, {e} {f}");

                Headers.LineBreakSY();
            }
        }

        //RETURN LOCATION STRING
        public static string LocationStr(string uid)  {
            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
            MySqlConnection conn = null;
            conn = new MySqlConnection(cs);
            conn.Open();
            MySqlDataReader rdr = null;
            //SQL Statement
            string stm = "SELECT DISTINCT(locationID), pubName,locationAddress,locationCity,locationState,locationZipCode FROM Locations WHERE locationID = @LId;";
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@LId", uid);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            string name = rdr["pubName"].ToString();
            string city = rdr["locationCity"].ToString();
            string state = rdr["locationState"].ToString();
            string x = $"{name + " - " + city + ", " + state, 72}";

            return x;
        }
    }   
}
