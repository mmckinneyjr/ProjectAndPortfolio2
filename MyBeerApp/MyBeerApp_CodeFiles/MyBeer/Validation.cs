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
    class Validation
    {
        public static int ValidateInt(int min, int max, string message = "Enter an integer: ") {
            int validInt;
            string input = null;
            Console.Write(message);
            input = Console.ReadLine();
            while (!((int.TryParse(input, out validInt)) && (min <= validInt && max >= validInt))) {
                Console.Write("    Please enter a valid option: ");
                input = Console.ReadLine();
                int.TryParse(input, out validInt);
            }
            return validInt;
        }

        public static string ValidateString()  {
            string input = null;
            input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input))  {
                Console.Write("    Do not leave blank: ");
                input = Console.ReadLine();
            }
            return input;
        }

        public static string orderNumer(string message, string uid, string loc, string locId) {

            bool selectingBeer = true;
            string num = "";
            while (selectingBeer) {
           
                string input = null;
                Console.Write(message);
                input = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(input)) {
                    Console.Write("    Do not leave blank: ");
                    input = Console.ReadLine();
                }
            
                //CONNECTION STRING
                string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
                MySqlConnection conn = null;
                conn = new MySqlConnection(cs);
                conn.Open();
                MySqlDataReader rdr = null;
                //SQL Statement
                string stm = "SELECT beerMenuNumber, Beers.beerID, beerName, locationID FROM Beers JOIN Locations on Locations.beerID = Beers.beerID WHERE locationID = @loc_id and Beers.beerID = @beer_id;";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                cmd.Parameters.AddWithValue("@loc_id", locId);
                cmd.Parameters.AddWithValue("@beer_id", input);
                rdr = cmd.ExecuteReader();
                rdr.Read();

                if (input == "0") {
                    selectingBeer = false;
                    num = "0";
                    break;
                }

                else if (rdr.HasRows) {
                    num = rdr["beerID"].ToString();
                    selectingBeer = false;
                    break;
                }
                else  {
                    Headers.Ordering(uid, loc);
                    Console.WriteLine(" There is no beer with that ID, select another");
                }
            }
            return num;        
        }

        public static int FavoriteBeerNumerAdd(string message, string uidName, string loc, string uid) {

            bool selectingBeer = true;
            int num = 0;
            while (selectingBeer) {

                int validInt;
                string input = null;
                Console.Write(message);
                input = Console.ReadLine();
                while (!(int.TryParse(input, out validInt)))  {
                    Console.Write("    Please enter a valid option: ");
                    input = Console.ReadLine();
                    int.TryParse(input, out validInt);
                }

                //CONNECTION STRING
                string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
                MySqlConnection conn = null;
                MySqlConnection conn2 = null;
                conn = new MySqlConnection(cs);
                conn2 = new MySqlConnection(cs);
                conn.Open();
                conn2.Open();
                MySqlDataReader rdr = null;
                MySqlDataReader rdr2 = null;
                //SQL Statement
                string stm = "SELECT Beers.beerID, Favorites.beerID FROM Beers JOIN Favorites ON Favorites.beerID = Beers.beerID WHERE Beers.beerID = @beer_id;";
                string stm2 = "SELECT beerID FROM Beers WHERE beerID = @beer_id2;";

                MySqlCommand cmd = new MySqlCommand(stm, conn);
                cmd.Parameters.AddWithValue("@beer_id", validInt);
                rdr = cmd.ExecuteReader();
                rdr.Read();

                MySqlCommand cmd2 = new MySqlCommand(stm2, conn2);
                cmd2.Parameters.AddWithValue("@beer_id2", validInt);
                rdr2 = cmd2.ExecuteReader();
                rdr2.Read();

                if (validInt == 0) {
                    selectingBeer = false;
                    num = 0;
                    break;
                }

                else if (rdr.HasRows && Convert.ToInt32(rdr["beerID"]) == validInt) {
                    Favorites.Favs(uidName, loc, uid);
                    Console.WriteLine(" Beer already added to Favorites");
                }

                else if (rdr2.HasRows)  {
                    num = Convert.ToInt32(rdr2["beerID"]);
                    selectingBeer = false;
                    num = validInt;
                    break;
                }

                else {
                    Favorites.Favs(uidName, loc, uid);
                    Console.WriteLine(" There is no beer with that ID, select another");
                }
            }
            return num;
        }

        public static int FavoriteBeerNumerRemove(string message, string uidName, string loc, string uid)  {

            bool selectingBeer = true;
            int num = 0;
            while (selectingBeer) {

                int validInt;
                string input = null;
                Console.Write(message);
                input = Console.ReadLine();
                while (!(int.TryParse(input, out validInt)))  {
                    Console.Write("    Please enter a valid option: ");
                    input = Console.ReadLine();
                    int.TryParse(input, out validInt);
                }

                //CONNECTION STRING
                string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
                MySqlConnection conn = null;
                conn = new MySqlConnection(cs);
                conn.Open();
                MySqlDataReader rdr = null;
                //SQL Statement
                string stm = "SELECT Beers.beerID, Favorites.beerID FROM Beers JOIN Favorites ON Favorites.beerID = Beers.beerID WHERE Beers.beerID = @beer_id;";

                MySqlCommand cmd = new MySqlCommand(stm, conn);
                cmd.Parameters.AddWithValue("@beer_id", validInt);
                rdr = cmd.ExecuteReader();
                rdr.Read();

                if (validInt == 0) {
                    selectingBeer = false;
                    num = 0;
                    break;
                }

                else if (rdr.HasRows) {
                    num = Convert.ToInt32(rdr["beerID"]);
                    selectingBeer = false;
                    num = validInt;
                    break;
                }

                else {
                    break;
                };
            }
            return num;
        }

        public static int BeerValidation(string message, string uidName, string loc, string uid) {

            bool selectingBeer = true;
            int num = 0;
            while (selectingBeer)  {

                int validInt;
                string input = null;
                Console.Write(message);
                input = Console.ReadLine();
                while (!(int.TryParse(input, out validInt))) {
                    Console.Write("    Please enter a valid option: ");
                    input = Console.ReadLine();
                    int.TryParse(input, out validInt);
                }

                //CONNECTION STRING
                string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
                MySqlConnection conn = null;
                conn = new MySqlConnection(cs);
                conn.Open();
                MySqlDataReader rdr = null;
                //SQL Statement
                string stm = "SELECT Beers.beerID, Favorites.beerID FROM Beers JOIN Favorites ON Favorites.beerID = Beers.beerID WHERE Beers.beerID = @beer_id;";

                MySqlCommand cmd = new MySqlCommand(stm, conn);
                cmd.Parameters.AddWithValue("@beer_id", validInt);
                rdr = cmd.ExecuteReader();
                rdr.Read();

                if (rdr.HasRows) {
                    num = Convert.ToInt32(rdr["beerID"]);
                    selectingBeer = false;
                    num = validInt;
                    break;
                }

                else  {
                    Headers.ReviewsHeader(uidName, loc);
                    Console.WriteLine(" There is no beer that matches that number, select another");
                };
            }
            return num;        
        }
    }
}
