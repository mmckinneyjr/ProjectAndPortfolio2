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
    class Program
    {

        private static User currentUser = new User();
        private static Location currentLoc = new Location();


        static void Main(string[] args)
        {
            Console.Title = "Mark Mckinney - Time Tracker";

        


            //LOGIN
            bool loggingIn = true;
            int counter = 0;
            while (loggingIn) {

                Headers.Header("","");
                Console.WriteLine("    [1] Login");
                Console.WriteLine("    [2] Create Account");
                Headers.LineBreak();
                counter++;
                if (counter > 1) {
                        Console.WriteLine(" The login provided did not match any records\r\n");                 
                }

                int login = Validation.ValidateInt(1, 2, " Selection: ");
                switch (login)  {
                    case 1: {
                            Console.WriteLine(" Login:");
                            currentUser._userId = User.UserLogin("","");
                            if (currentUser._userId.Any()) {
                                loggingIn = false;
                            }
                        } break;

                    case 2: {
                            Headers.Header("","");
                            Console.WriteLine(" Create Account:");
                            currentUser._userId = User.NewUser();
                            loggingIn = false;
                        }  break;
                }
            }




            //SELECT LOCATION
            Headers.SelectingALocation(User.userName(currentUser._userId), "");
            LocationList.LocationData("");

            List<Location> locList = Location.locationList.OrderBy(x => x._locationID).ToList();
            LocationList.LocationDisplay("", locList); ;
            int locationSelection = Validation.ValidateInt(1, 4, " Selection: ");
            currentLoc._locationID = locationSelection.ToString();

            //APPLICATION
            BeerList.BeerData(User.userName(currentUser._userId), currentLoc._locationID);
            Headers.MainMenu(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));
            bool programIsRunning = true;
            while (programIsRunning) {
                int menuSelection = Validation.ValidateInt(0,5," Selection: ");
                switch (menuSelection) {
                  
                    //Display Beers
                    case 1: {

                            Headers.DisplaySort(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));
                            bool displayingBeer = true;
                            while (displayingBeer) {
                            int displaySelection = Validation.ValidateInt(0, 3, " Selection: ");

                                switch (displaySelection) {
                                    case 1: {
                                            List<Beer> SortedList = Beer.beerList.OrderBy(x => x._beerName).ToList();
                                            BeerList.BeerDisplay(User.userName(currentUser._userId), SortedList, LocationList.LocationStr(currentLoc._locationID));
                                        } break;

                                    case 2: {
                                            List<Beer> SortedList = Beer.beerList.OrderBy(x => x._abv).ToList();
                                            BeerList.BeerDisplay(User.userName(currentUser._userId), SortedList, LocationList.LocationStr(currentLoc._locationID));
                                        }
                                        break;
                                    case 3: {
                                            List<Beer> SortedList = Beer.beerList.OrderBy(x => x._style).ToList();
                                            BeerList.BeerDisplay(User.userName(currentUser._userId), SortedList, LocationList.LocationStr(currentLoc._locationID));
                                        }
                                        break;
                                    case 0: {
                                            Headers.MainMenu(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));
                                            displayingBeer = false;
                                        } break;
                                }
                            }
                        } break;
                    
                    //Order Beer
                    case 2: {
                            Headers.Ordering(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));
                            string orderBeerNum = Validation.orderNumer(" Enter beer number: ", User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID), currentLoc._locationID);
                            if (orderBeerNum == "0") {
                                Headers.MainMenu(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));
                                break;
                            }

                            int orderTableNum = Validation.ValidateInt(0, 30, " Table Number(1-30): ");
                            if (orderTableNum == 0) {
                                Headers.MainMenu(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));
                                break;
                            }

                            //CONNECTION STRING
                            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
                            MySqlConnection conn = null;
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            MySqlConnection conn2 = null;
                            conn2 = new MySqlConnection(cs);
                            conn2.Open();


                            //SQL Statement
                            string stm2 = "SELECT beerMenuNumber, Beers.beerID, beerName, Breweries.breweryName, BeerStyle.beerStyle, servingSize, Price, pubName, locationAddress,locationCity,locationState,locationZipCode FROM Beers JOIN Breweries ON Breweries.breweryID = Beers.brewery JOIN Locations ON Locations.beerID = Beers.beerID JOIN BeerStyle ON BeerStyle.styleID = Beers.styleID WHERE Beers.beerID = @beerInput AND locationID = @loc_ID;";
                            MySqlDataReader rdr2 = null;
                            MySqlCommand cmd2 = new MySqlCommand(stm2, conn);
                            cmd2.Parameters.AddWithValue("@beerInput", orderBeerNum);
                            cmd2.Parameters.AddWithValue("@loc_ID", currentLoc._locationID);
                            rdr2 = cmd2.ExecuteReader();
                            rdr2.Read();

                            //print to doc
                            string order_ID = DateTime.Now.ToString("yyyyMM-ddssfff");
                            string str = "";
                           
                            str += $"Order ID: {order_ID} ";
                            str += "\r\n================================================";
                            str += $"\r\nDate: {DateTime.Now.ToString("MM/dd/yyyy")}";
                            str += $"\r\nTime: {DateTime.Now.ToString("hh:mm tt")}";
                            str += $"\r\n\r\n{rdr2["pubName"]}";
                            str += $"\r\n{rdr2["locationAddress"]}";
                            str += $"\r\n{rdr2["locationCity"]}, {rdr2["locationState"]} {rdr2["locationZipCode"]}";
                            str += $"\r\n\r\nCustomer Name: {User.Name(currentUser._userId)}";
                            str += $"\r\n\r\nBeerID: {rdr2["beerID"]}";
                            str += $"\r\nBeer: {rdr2["beerName"]}";
                            str += $"\r\nBrewery: {rdr2["breweryName"]}";
                            str += $"\r\nStyle: {rdr2["beerStyle"]}";
                            str += $"\r\nSize: ${rdr2["servingSize"]} oz";
                            str += $"\r\nTable Number: ${orderTableNum}";
                            str += $"\r\nPrice: ${rdr2["Price"]}";

                            string dir = @"..\..\..\..\MyBeerOrders\";
                            Directory.CreateDirectory(dir);
                            File.WriteAllText($@"{dir}{order_ID}.txt", str);

                            Headers.MainMenu(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));
                            Console.WriteLine(" Your Order has been sent!");

                            //Add to database
                            MySqlDataReader rdr = null;

                            string stm = "INSERT INTO Orders (orderID, beerID, userID, locationID) VALUES(@order_id, @beer_id, @user_id, @location_ID);";

                            MySqlCommand cmd = new MySqlCommand(stm, conn2);
                            cmd.Parameters.AddWithValue("@order_id", order_ID);
                            cmd.Parameters.AddWithValue("@beer_id", rdr2["beerID"]);
                            cmd.Parameters.AddWithValue("@user_id", currentUser._userId);
                            cmd.Parameters.AddWithValue("@location_id", currentLoc._locationID);
                            rdr = cmd.ExecuteReader();

                            conn.Close();
                            conn2.Close();


                } break;

                    //Favorites
                    case 3: {


                            //CONNECTION STRING
                            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
                            MySqlConnection conn = null;
                            conn = new MySqlConnection(cs);
                            conn.Open();

                            bool inFavorites = true;
                            while (inFavorites) {
                                Favorites.Favs(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID), currentUser._userId);
                                int favoritesSelection = Validation.ValidateInt(0, 2, " Selection: ");
                                switch (favoritesSelection) {

                                    //ADD FAVORITE
                                    case 1: {

                                            int favBeerNum = Validation.FavoriteBeerNumerAdd(" Enter beer number to add: ", User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID), currentUser._userId);
                                            if (favBeerNum == 0) {
                                                Headers.MainMenu(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));
                                                break;
                                            }                               

                                            //SQL Statement
                                            string stm1 = "INSERT INTO Favorites (userID, beerID) VALUES (@user_id, @beer_id);";
                                            MySqlDataReader rdr1 = null;
                                            MySqlCommand cmd1 = new MySqlCommand(stm1, conn);
                                            cmd1.Parameters.AddWithValue("@user_id", currentUser._userId);
                                            cmd1.Parameters.AddWithValue("@beer_id", favBeerNum);
                                            rdr1 = cmd1.ExecuteReader();
                                            rdr1.Read();

                                            Favorites.Favs(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID), currentUser._userId);
                                            rdr1.Close();
                                        }
                                        break;

                                    //REMOVE FAVORITE
                                    case 2: {

                                            int favBeerNum = Validation.FavoriteBeerNumerRemove(" Enter beer number to remove: ", User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID), currentUser._userId);
                                            if (favBeerNum == 0) {
                                                Headers.FavoritesHeader(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));
                                                break;
                                            }

                                            //SQL Statement
                                            string stm1 = "DELETE FROM Favorites WHERE userID = @user_id and beerID = @beer_id;";
                                            MySqlDataReader rdr1 = null;
                                            MySqlCommand cmd1 = new MySqlCommand(stm1, conn);
                                            cmd1.Parameters.AddWithValue("@user_id", currentUser._userId);
                                            cmd1.Parameters.AddWithValue("@beer_id", favBeerNum);
                                            rdr1 = cmd1.ExecuteReader();
                                            rdr1.Read();

                                            Favorites.Favs(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID), currentUser._userId);
                                            rdr1.Close();
                                        } break;

                                    //EXIT
                                    case 0: {
                                            Headers.MainMenu(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));
                                            inFavorites = false;
                                        } break;
                                }
                            }                           
                            conn.Close();
                        } break;

                    //Reviews
                    case 4: {

                            Headers.ReviewsHeader(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));
                            Reviews.Review(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));

                            bool viewingReviews = true;
                            while (viewingReviews) {
                                Headers.LineBreak();
                                int reviewSelection = Validation.ValidateInt(0, 1, " Selection: ");
                                switch (reviewSelection) {
                                    case 1: {
                                            Reviews.AddReview(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID),currentUser._userId);
                                        } break;
                                    case 0: {
                                            Headers.MainMenu(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));
                                            viewingReviews = false;
                                        } break; 
                                }
                            }



                        } break;

                    //Update Info
                    case 5: {
                            currentUser.UpdateInfo(User.userName(currentUser._userId), LocationList.LocationStr(currentLoc._locationID));
                        } break;

                    //Exit
                    case 0: {
                            programIsRunning = false;
                        } break;
                }
            }
            }
    }
}
