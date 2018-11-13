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
    public class BeerList
    {

        //LOAD BEER DATA
        public static void BeerData(string user, string locID) {
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
            MySqlConnection conn = null;
            conn = new MySqlConnection(cs);
            conn.Open();

            string query = ("SELECT Locations.locationID, Beers.beerID, beerMenuNumber, breweryName, beerName, abv, kegPercent, servingSize, beerStyle, Price FROM Beers JOIN Breweries on Beers.brewery = Breweries.breweryID JOIN BeerStyle on Beers.styleID = BeerStyle.styleID JOIN Locations on Locations.beerID = Beers.beerID WHERE Locations.locationID = @locID;");
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable data = new DataTable();
            adapter.SelectCommand.Parameters.AddWithValue("@locID", locID);
            adapter.Fill(data);
            DataRowCollection rows = data.Rows;

            foreach (DataRow row in rows) {
                Beer.beerList.Add(new Beer(row["beerID"].ToString(), Convert.ToInt32(row["beerMenuNumber"]), row["breweryName"].ToString(), row["beerName"].ToString(), Convert.ToDecimal(row["abv"]), Convert.ToInt32(row["kegPercent"]), Convert.ToInt32(row["servingSize"]), row["beerStyle"].ToString(), Convert.ToInt32(row["Price"]), row["locationID"].ToString()));
            }
            conn.Close();
        }

        //DISPLAY BEERS
        public static void BeerDisplay(string user, List<Beer> beerList, string loc)  {
            Headers.DisplaySort(user,loc);
            Console.WriteLine(" #      BEER");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" =================================================================================================================");
            Console.ResetColor();
            
            foreach (var beer in beerList) {
                string a = beer._beerID.ToString();
                string b = Limit(beer._brewery, 45);
                string c = Limit(beer._beerName,40).ToUpper();
                string d = beer._abv.ToString();
                string e = beer._kegPercent.ToString();
                string f = beer._servingSize.ToString();
                string g = Limit(beer._style, 45);
                string h = Math.Round(beer._price,2).ToString("0.##");

                //menu number
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($" {a,-6}");
                Console.ResetColor();

                //name
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($" {c,-42}");
                Console.ResetColor();

                //brewery
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(" Brewery:");
                Console.ResetColor();
                Console.WriteLine($" {b}");

                //abv
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"        ABV:");
                Console.ResetColor();
                Console.Write($" {d + " %",-9}");

                //keg
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($" Keg:");
                Console.ResetColor();
                Console.Write($" {e + " %",-8}");

                //size
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($" Size:");
                Console.ResetColor();
                Console.Write($" {f + " oz",-7}");

                //style
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($" Style:");
                Console.ResetColor();
                Console.Write($" {g,-46}");

                //price
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($" Price:");
                Console.ResetColor();
                Console.WriteLine($" ${h}");

                Headers.LineBreakSY();

          
            }
        }

        //LIST FEATURES
        public static string Count(int numInv)  {
            if (numInv >= 1 && numInv <= 9) {
                return $"  [{numInv++.ToString()}] ";
            }
            else {

                return $" [{numInv++.ToString()}] ";
            }
        }
        public static string Limit(string input, int maxLength) {
            if (string.IsNullOrEmpty(input)) {
                return input;
            }

            else {
                input = input.Substring(0, Math.Min(input.Length, maxLength));
                if (input.Length >= maxLength) {
                    input += " . . .";
                }
                return input;
            }
        }
        public static string Trim(List<Beer> list, int selection) {
            string item = list[selection - 1].ToString();
            item = item.Remove(item.IndexOf("|") - 1).Substring(item.IndexOf(":") + 2);
            return item;
        }


    }
}
