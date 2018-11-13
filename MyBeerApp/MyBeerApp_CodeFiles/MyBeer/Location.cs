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
    public class Location
    {
        public static List<Location> locationList = new List<Location>();

        public string _locationID { get; set; }
        public string _locationName { get; set; }
        public string _locationAddress { get; set; }
        public string _locationState { get; set; }
        public string _locationCity { get; set; }
        public string _locationZip { get; set; }

        public Location(string locationID, string locationName, string locationAddress, string locationState, string locationCity, string locationZip) {
            _locationID = locationID;
            _locationName = locationName;
            _locationAddress = locationAddress;
            _locationState = locationState;
            _locationCity = locationCity;
            _locationZip = locationZip;
        }

        public Location() { }
    }
}
