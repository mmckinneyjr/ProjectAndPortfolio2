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
    public class Beer
    {



        public static List<Beer> beerList = new List<Beer>();

        public string _beerID { get; set; }
        public int _menuNumber { get; set; }
        public string _brewery { get; set; }
        public string _beerName { get; set; }
        public decimal _abv { get; set; }
        public int _kegPercent { get; set; }
        public int _servingSize { get; set; }
        public string _style { get; set; }
        public decimal _price { get; set; }
        public string _locID { get; set; }


        public Beer(string beerID, int menuNum, string brewery, string beerName, decimal abv, int keg, int size, string style, decimal price, string locID) {
            _beerID = beerID;
            _menuNumber = menuNum;
            _brewery = brewery;
            _beerName = beerName;
            _abv = abv;
            _kegPercent = keg;
            _servingSize = size;
            _style = style;
            _price = price;
            _locID = locID;
        }

        public static void beer(string uid) {
            //CONNECTION STRING
            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
            MySqlConnection conn = null;
            conn = new MySqlConnection(cs);
            conn.Open();
            MySqlDataReader rdr = null;
            //SQL Statement
            string stm = "SELECT beerMenuNumber, beerID,  beerName, Breweries.breweryName, BeerStyle.beerStyle, servingSize,Price FROM Beers  JOIN Breweries ON Breweries.breweryID = Beers.brewery JOIN BeerStyle ON BeerStyle.styleID = Beers.styleID WHERE beerMenuNumber = 2389;";
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@userid", uid);
            rdr = cmd.ExecuteReader();
            rdr.Read();
            string name = rdr["userFirstName"].ToString();


        }
    }
}
