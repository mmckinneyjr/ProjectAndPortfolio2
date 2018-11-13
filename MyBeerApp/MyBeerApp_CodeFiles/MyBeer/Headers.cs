using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeer
{
    class Headers
    {


        public static void Header(string user, string loc) {
            Console.WindowWidth = 120;
            Console.Clear();
            Console.WriteLine($" {user} {loc}");
            LineBreak();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                                  ___ ___  __ __      ____     ___    ___  ____                           ");
            Console.WriteLine("              oOOOOOo            |   |   ||  |  |    |    \\   /  _]  /  _]|    \\              oOOOOOo       ");
            Console.WriteLine("             ,|    oO            | _   _ ||  |  |    |  o  ) /  [_  /  [_ |  D  )            ,|    oO        ");
            Console.WriteLine("            //|     |            |  \\_/  ||  ~  |    |     ||    _]|    _]|    /            //|     |     ");
            Console.WriteLine("            \\\\|     |            |   |   ||___, |    |  O  ||   [_ |   [_ |    \\            \\\\|     |      ");
            Console.WriteLine("             `|     |            |   |   ||     |    |     ||     ||     ||  .  \\            `|     |       ");
            Console.WriteLine("              `-----`            |___|___||____/     |_____||_____||_____||__|\\_|             `-----`      ");
            LineBreak();
        }

        public static void LineBreak() {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" =================================================================================================================");
            Console.ResetColor();
        }

        public static void LineBreakSY() {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" -----------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }


        public static void MainMenu(string user, string loc) {
            Header(user, loc);
            Console.WriteLine("    [1] Beer List");
            Console.WriteLine("    [2] Order Beer");
            Console.WriteLine("    [3] Favorites");
            Console.WriteLine("    [4] Reviews");
            Console.WriteLine("    [5] Update User Info");
            Console.WriteLine("\r\n    [0] Exit");
            LineBreak();
        }

        public static void DisplaySort(string user, string loc) {
            Header(user, loc);
            Console.WriteLine(" View by:");
            Console.WriteLine("    [1] Name");
            Console.WriteLine("    [2] ABV");
            Console.WriteLine("    [3] Style");
            Console.WriteLine("\r\n    [0] Back");
            LineBreak();
        }

        public static void Ordering(string user, string loc)  {
            Header(user, loc);
            Console.WriteLine(" Ordering");
            Console.WriteLine("\r\n [0] To Cancel");
            LineBreak();
        }

        public static void SelectingALocation(string user, string loc) {
            Header(user, loc);
            Console.WriteLine(" Select a Location:");
            LineBreak();
        }

        public static void FavoritesHeader(string user, string loc) {
            Header(user, loc);
            Console.WriteLine(" [1] Add Favorite");
            Console.WriteLine(" [2] Remove Favorite");
            Console.WriteLine("\r\n [0] Main Menu");
            LineBreak();
        }

        public static void ReviewsHeader(string user, string loc) {
            Header(user, loc);
            Console.WriteLine(" [1] Add Review");
            Console.WriteLine("\r\n [0] Main Menu");
            LineBreak();
        }

        public static void AddReviewsHeader(string user, string loc) {
            Console.WriteLine(" ADD REVIEW\r\n");
            Header(user, loc);
            Console.WriteLine(" [1] Add Review");
            Console.WriteLine("\r\n [0] Main Menu");
            LineBreak();
    }

}
}
