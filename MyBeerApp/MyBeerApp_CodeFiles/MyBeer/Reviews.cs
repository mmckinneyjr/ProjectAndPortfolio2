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
    class Reviews
    {
        public static void Review(string user, string loc)
        {

            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
            MySqlConnection conn = null;

            conn = new MySqlConnection(cs);
            conn.Open();
            MySqlDataReader rdr = null;

            string stm = "SELECT reviewID, beerName, beerStyle,  abv, breweryName, userName, review, rating FROM Reviews JOIN Beers ON Beers.beerID = Reviews.BeerID JOIN Breweries ON Breweries.breweryID = Beers.brewery JOIN Users ON Users.userID = Reviews.userID JOIN BeerStyle ON BeerStyle.styleID = Beers.styleID;";

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            rdr = cmd.ExecuteReader();

            Headers.ReviewsHeader(user, loc);

            Console.WriteLine(" #    BEER REVIEWS");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" =================================================================================================================");
            Console.ResetColor();

            while (rdr.Read()) {
                //menu number
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($" {rdr["userName"], -100}");
                Console.ResetColor();

                //rating
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($" Rating");
                Console.ResetColor();
                

                //name
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($" {rdr["beerName"], -101}");
                Console.ResetColor();
                Console.WriteLine($"{Rating(Convert.ToInt32(rdr["rating"]))}");


                //brewery
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(" Brewery:");
                Console.ResetColor();
                Console.Write($" {rdr["breweryName"],-40}");

                //style
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($" Style:");
                Console.ResetColor();
                Console.Write($" {rdr["beerStyle"],-38}");

                //abv
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"      ABV:");
                Console.ResetColor();
                Console.WriteLine($" {rdr["abv"] + " %"}");

                //Review
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($" Review:");
                Console.ResetColor();
                Console.WriteLine($" {rdr["review"]}");

                Headers.LineBreakSY();
            }
            conn.Close();
        }

        public static void AddReview(string user, string loc, string uid) {

            string cs = @"server=192.168.207.1; userid=dbremoteuser; password=password; database=DigitalPour; port=8889";
            MySqlConnection conn = null;

            conn = new MySqlConnection(cs);
            conn.Open();
            MySqlDataReader rdr = null;

            string stm = "INSERT INTO Reviews (beerID, userID, review, rating) VALUES(@beer_ID, @user_ID, @review, @rating);";

            Headers.AddReviewsHeader(user,loc);

            int beer_id = Validation.BeerValidation(" Enter beer number: ", user, loc, uid);

            Console.Write(" Enter review: ");
            string uReview = Validation.ValidateString();
            int uRating = Validation.ValidateInt(1, 5, " Enter beer rating (1 - 5): ");

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.Parameters.AddWithValue("@beer_ID", beer_id);
            cmd.Parameters.AddWithValue("@user_ID", uid);
            cmd.Parameters.AddWithValue("@review", uReview);
            cmd.Parameters.AddWithValue("@rating", uRating);

            rdr = cmd.ExecuteReader();

            Headers.ReviewsHeader(user, loc);
            Review(user, loc);
            Console.WriteLine("\r\n Your review has been submitted");
        }

        public static string Rating(int rateNum) {
            string rating = "";
            if (rateNum == 1) {
                rating = "*";
                return rating;
            }
            if (rateNum == 2) {
                rating = "* *";
                return rating;
            }
            if (rateNum == 3)
            {
                rating = "* * *";
                return rating;
            }
            if (rateNum == 4)  {
                rating = "* * * *";
                return rating;
            }
            if (rateNum == 5) {
                rating = "* * * * *";
                return rating;
            }

            return rating;


        }

    }
}
