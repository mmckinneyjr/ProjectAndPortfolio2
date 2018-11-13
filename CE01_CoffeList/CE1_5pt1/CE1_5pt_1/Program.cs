/*
Mark Mckinney
Mobile Development
Course: PPII
Assignment: Code Exercise 1.5 pt1
Sorting Arrays/Lists
28 October 2018
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE01_5pt1
{
    class Program
    {
        //List of 20 different coffee brands
        static List<String> coffeeBrands = new List<string> { "Starbucks", "Maxwell House", "Folgers", "Nescafe", "Millstone", "Moccona", "Costa", "Duncan Donuts", "McCafe", "Keurig", "Nespresso", "Eight O'Clock", "Gevalia", "Bru", "Peet's", "Lavazza", "Farmer Brothers", "Gavina", "Melitta", "Joe" };

        static void Main(string[] args)
        {
     
            //Menu Method Call
            Menu();
            PrintList(coffeeBrands, "");

            //Loop to stay in program and loop back through menu options
            bool programIsRunning = true;
            while (programIsRunning) {
                string input = Selection("Selection: ");

                //User Selection Switch
                switch (input){

                    // Alphabetize List A-Z
                    case "1":{
                            Menu();
                            PrintList(coffeeBrands.OrderBy(a => a).ToList(), "Alphabetize A-Z");                           
                        } break;

                    //Alphabetize List Z - A
                    case "2": {
                            Menu();
                            PrintList(coffeeBrands.OrderByDescending(z => z).ToList(), "Alphabetize Z-A");
                        } break;

                    //Randomize List
                    case "3": {
                            Menu();
                            var randomized = coffeeBrands.OrderBy(r => Guid.NewGuid()).ToList();
                            PrintList(randomized, "Randomized");
                        } break;

                    //Remove Random brand 20x
                    case "4": {
                            Menu();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"Coffee Brands: What is your lucky brand today? \r\n");
                            Console.ResetColor();                        

                            List<string> removeBrand = new List<string>(coffeeBrands);
                            Random rnd = new Random();
                            string L = "";
                            int counter = coffeeBrands.Count;
                            for (int x = removeBrand.Count-1; x >= 0; x--) {
                                int removeRandom = rnd.Next(0, x+ 1);
                                Console.Write($"[{counter--}] ");
                                for (int i = 0; i < removeBrand.Count; i++) {
                                    Console.Write(removeBrand[i]);
                                    if (i < removeBrand.Count - 1) {
                                        Console.Write(", ");
                                    }
                                    L = removeBrand[0].ToString();
                                }
                                removeBrand.Remove(removeBrand[removeRandom]);
                                Console.WriteLine();
                                
                        }
                            LineBreak();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"Your lucky coffee brand today is {L}");
                            Console.ResetColor();
                            LineBreak();

                        } break;

                    //Reset List
                    case "5": {
                            Menu();
                            PrintList(coffeeBrands, "");
                        }
                        break;

                    //Exit
                    case "0": {
                            programIsRunning = false;
                        } break;
                }
            }

        }

        //Prints out list items Method
        public static void PrintList(List<string> coffeeBrands, string str) {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Coffee Brands: {str}\r\n");
            Console.ResetColor();
            for (int i = 0; i < coffeeBrands.Count; i++) {
                Console.Write(coffeeBrands[i]);
                if (i < coffeeBrands.Count - 1) {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
            LineBreak();
        }


        //Menu Method
        public static void Menu() {
            Console.Clear();
            Console.WindowWidth = 102;
            Console.WindowHeight = 40;
            LineBreak();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                            _______  _______  _______  _______  _______  _______");
            Console.WriteLine("                           |       ||       ||       ||       ||       ||       |");
            Console.WriteLine("                           |       ||  | |  ||   |___ |   |___ |   |___ |   |___ ");
            Console.WriteLine("                           |      _||  |_|  ||    ___||    ___||    ___||    ___|");
            Console.WriteLine("                           |     |_ |       ||   |    |   |    |   |___ |   |___");
            Console.WriteLine("                           |_______||_______||___|    |___|    |_______||_______|");
            Console.ResetColor();
            LineBreak();
            Console.WriteLine("\r\n    [1] Alphabetize List A-Z");
            Console.WriteLine("    [2] Alphabetize List Z-A");
            Console.WriteLine("    [3] Randomize List");
            Console.WriteLine($"    [4] Lucky Brand of the day");
            Console.WriteLine("    [5] Reset List");
            Console.WriteLine("\r\n    [0] Exit\r\n");
            LineBreak();          
        }

        //Reusable Linebreak method
        public static void LineBreak() {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("================================================================================================================");
            Console.ResetColor();
        }

        //Validate users Selection method
        public static string Selection(string message) {
            Console.Write(message);
            string input = Console.ReadLine().ToLower().Trim();
            while (!((input == "0") ||
                     (input == "1") ||
                     (input == "2") ||
                     (input == "3") || 
                     (input == "4") ||
                     (input == "5"))) { 
                Console.Write("    Please choose a valid option: ");
            input = Console.ReadLine();       
            }
            return input;
        }
            

    }
}
