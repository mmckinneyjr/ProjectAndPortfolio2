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
    class Favorites
    {

        public static void Favs(string user, string loc, string uid) {
            
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
            MySqlConnection conn = null;

                conn = new MySqlConnection(cs);
                conn.Open();
                MySqlDataReader rdr = null;

                string stm = ("SELECT Beers.beerID, beerName, breweryName, abv, beerStyle, Users.userID FROM Favorites JOIN Beers ON Beers.beerID = Favorites.beerID JOIN BeerStyle ON BeerStyle.styleID = Beers.styleID JOIN Users ON Users.userID = Favorites.userID JOIN Breweries ON Breweries.breweryID = Beers.brewery WHERE Users.userID = @uid;");

                MySqlCommand cmd = new MySqlCommand(stm, conn);
                cmd.Parameters.AddWithValue("@uid", uid);
                rdr = cmd.ExecuteReader();

                Headers.FavoritesHeader(user, loc);

                Console.WriteLine(" #    BEER                                         MY FAVORITES");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" =================================================================================================================");
                Console.ResetColor();

            while (rdr.Read())  {
                //menu number
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($" {rdr["beerID"],-4}");
                Console.ResetColor();

                //name
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($" {rdr["beerName"]}");
                Console.ResetColor();

                //brewery
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("      Brewery:");
                Console.ResetColor();
                Console.Write($" {rdr["breweryName"], - 35}");

                //style
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($" Style:");
                Console.ResetColor();
                Console.Write($" {rdr["beerStyle"],-38}");

                //abv
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"        ABV:");
                Console.ResetColor();
                Console.WriteLine($" {rdr["abv"] + " %"}");

                Headers.LineBreakSY();
                Headers.LineBreak();
            }
                    conn.Close();
        }
    }
}
