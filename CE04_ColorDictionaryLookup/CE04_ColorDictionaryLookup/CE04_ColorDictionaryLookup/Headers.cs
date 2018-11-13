using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE04_ColorDictionaryLookup
{
    class Headers
    {
        
        //Main menu header
        public static void Header(string color) {
            Console.Clear();
            IfColor(color); Console.WriteLine(" ========================================================================================");
            R(); Console.WriteLine("              _______  _______  ___      _______  ______    _______  __  ");
            O(); Console.WriteLine("             |       ||       ||   |    |       ||    _ |  |       ||  |");
            Y(); Console.WriteLine("             |       ||   _   ||   |    |   _   ||   | ||  |  _____||  | ");
            G(); Console.WriteLine("             |       ||  | |  ||   |    |  | |  ||   |_||_ | |_____ |  | ");
            B(); Console.WriteLine("             |      _||  |_|  ||   |___ |  |_|  ||    __  ||_____  ||__| ");
            I(); Console.WriteLine("             |     |_ |       ||       ||       ||   |  | | _____| | __  ");
            V(); Console.WriteLine("             |________|_______||_______||_______||___|  |_||_______||__| ");
            Console.ResetColor();
            IfColor(color); Console.WriteLine(" ========================================================================================");
            Console.ResetColor();
            Console.WriteLine(" Fun Facts About Colors:\r\n");
            R(); Console.WriteLine("    [1] Red");
            O(); Console.WriteLine("    [2] Orange");
            Y(); Console.WriteLine("    [3] Yellow");
            G(); Console.WriteLine("    [4] Green");
            B(); Console.WriteLine("    [5] Blue");
            I(); Console.WriteLine("    [6] Indigo");
            V(); Console.WriteLine("    [7] Violet");
                 Console.ResetColor();
                 Console.WriteLine("\r\n    [0] Exit\r\n");
            IfColor(color); Console.WriteLine(" ========================================================================================");
        }

        //Facts 
        public static void Next(string one, string two, string three, string color)  {
            //fact 1 display
            Header(color);
            IfColor(color);
            Console.WriteLine($" {color}:\r\n");
            Console.WriteLine($"    Fact1: {one}");
            Console.WriteLine("\r\n ========================================================================================");
            Console.ResetColor();
            Console.Write(" Press enter for next fact");
            Console.ReadKey();

            //Fact 2 display
            Header(color);
            IfColor(color);
            Console.WriteLine($" {color}:\r\n");
            Console.WriteLine($"    Fact1: {one}");
            Console.WriteLine($"    Fact2: {two}");
            Console.WriteLine("\r\n ========================================================================================");
            Console.ResetColor();
            Console.Write(" Press enter for next fact");
            Console.ReadKey();

            //Fact 3 display
            Header(color);
            IfColor(color);
            Console.WriteLine($" {color}:\r\n");
            Console.WriteLine($"    Fact1: {one}");
            Console.WriteLine($"    Fact2: {two}");
            Console.WriteLine($"    Fact3: {three}");
            Console.WriteLine("\r\n ========================================================================================");
            Console.ResetColor();
            Console.Write(" Press enter to continue to main menu");
            Console.ReadKey();

            Header(color);
        }

        //Color Decision
        public static void IfColor(string color) {
            if (color == "Red") { R(); }
            else if (color == "Orange") { O(); }
            else if (color == "Yellow") { Y(); }
            else if (color == "Green") { G(); }
            else if (color == "Blue") { B(); }
            else if (color == "Indigo") { I(); }
            else if (color == "Violet") { V(); }
        }

        //Red
        public static void R() { Console.ForegroundColor = ConsoleColor.DarkRed; }

        //Orange
        public static void O() { Console.ForegroundColor = ConsoleColor.DarkYellow; }

        //Yellow
        public static void Y() { Console.ForegroundColor = ConsoleColor.Yellow; }

        //Green
        public static void G() { Console.ForegroundColor = ConsoleColor.DarkGreen; }

        //Blue
        public static void B() { Console.ForegroundColor = ConsoleColor.DarkCyan; }

        //Indigo
        public static void I() { Console.ForegroundColor = ConsoleColor.DarkBlue; }

        //Violet
        public static void V() { Console.ForegroundColor = ConsoleColor.DarkMagenta; }


        //Validate Menu Selection Options
        public static string SelectionOptions(string message) {
            Console.ResetColor();
            Console.Write(message);
            string input = Console.ReadLine().ToLower().Trim();
            while (!((input == "0") || (input == "exit") ||
                     (input == "1") || (input == "red") ||
                     (input == "2") || (input == "orange") ||
                     (input == "3") || (input == "yellow") ||
                     (input == "4") || (input == "green") ||
                     (input == "5") || (input == "blue") ||
                     (input == "6") || (input == "indigo") ||
                     (input == "7") || (input == "violet"))) {
                Console.Write("    Please choose a valid option: ");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
