/*
Mark Mckinney
Mobile Development
Course: PPII
Assignment: Code Exercise 1.5 pt1
28 October 2018
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE1_5pt2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mark Mckinney - CE 1.5 pt2";
                Menu();
                Console.WriteLine(" Can you guess what im thinking?\r\n");

                //Answer
                string answer = "Africa";

                //Question
                string clue1 = " Coffee plants originated on what continent over 1000 years ago?: ";
                string clue2 = " There are 7 continents: Asia, Africa, North America, South America, Antarctica, Europe, and Australia";
                string clue3 = " It starts with an A";
                string clue4 = $" I'll give you a hint, it's {answer}";

                //Answer Method Loop
                bool incorrect = true;

                while (incorrect) {
                    //clue 1
                    if (UserGuessing(answer, clue1) == true) {
                        incorrect = false;
                    }
                    else {

                        //clue 2
                        if (UserGuessing(answer, clue2) == true) {
                            incorrect = false;
                        }
                        else {

                            //clue 3
                            if (UserGuessing(answer, clue3) == true) {
                                incorrect = false;
                            }

                            //clue 4
                            else {
                                Console.WriteLine(clue4);
                                Linebreak();
                                int counter = 10;
                                string input = ValidateString("    Guess: ");
                                while (counter > 1 && input != answer) {
                                if (!(char.IsUpper(input[0])) && (counter == 10)) {
                                    Console.WriteLine("    Make sure your answer starts with a capital letter");
                                }
                                counter--;
                                    input = ValidateString($"    Try entering {answer}: ");
                                if (!(char.IsUpper(input[0]))) {
                                    Console.WriteLine("    Make sure your answer starts with a capital letter");
                                }
                            }

                                if (input != answer) {
                                    Console.WriteLine($"\r\n I give up! The answer is {answer}");
                                    incorrect = false;
                                }
                                else {
                                    Console.WriteLine($" Yes, {input} is correct!");
                                    Console.WriteLine(" Congrats!");
                                    incorrect = false;
                                }
                            }
                        }
                    }
                }

                Linebreak();
                Console.WriteLine(" Press any key to continue");
                Console.ReadKey();


            }

            //Menu Method
            public static void Menu() {
                Linebreak();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("               ____  __ __    ___  _____ _____     __    __  __ __   ____  ______ ");
                Console.WriteLine("              /    ||  |  |  /  _]/ ___// ___/    |  |__|  ||  |  | /    ||      |");
                Console.WriteLine("             |   __||  |  | /  [_(   \\_(   \\_     |  |  |  ||  |  ||  o  ||      |");
                Console.WriteLine("             |  |  ||  |  ||    _]\\__  |\\__  |    |  |  |  ||  _  ||     ||_|  |_|");
                Console.WriteLine("             |  |_ ||  :  ||   [_ /  \\ |/  \\ |    |  `  '  ||  |  ||  _  |  |  |  ");
                Console.WriteLine("             |     ||     ||     |\\    |\\    |     \\      / |  |  ||  |  |  |  |  ");
                Console.WriteLine("             |___,_| \\__,_||_____| \\___| \\___|      \\_/\\_/  |__|__||__|__|  |__|  ");
                Console.ResetColor();
                Linebreak();
            }

            //visual Linebreak method
            public static void Linebreak() {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" ==========================================================================================");
                Console.ResetColor();
            }

            //visual Linebreak2 method
            public static void Linebreak2() {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" ------------------------------------------------------------------------------------------");
                Console.ResetColor();
            }

            //Try/guess method
            public static bool UserGuessing(string answer, string clue) {
                //list for random response for incorrect answers
                List<String> incorrect = new List<string> { "That's not right", "Sorry try again", "Nope still not right", "That is not correct" };
                Random random = new Random();

                Console.WriteLine(clue);
                Linebreak2();

                //User input
                string input = ValidateString("    Guess: ");

                //while loop for incorrect answeres
                int counter = 3;
                while (counter > 1 && input != answer)  {

                if (!(char.IsUpper(input[0])) && (counter == 3))  {
                    Console.WriteLine("    Make sure your answer starts with a capital letter");
                }
                counter--;
                    input = ValidateString($"    {incorrect[random.Next(0, incorrect.Count)]}, I'll give you {counter} more guesses: ");
                // input = char.ToUpper(input[0]) + input.Substring(1);
                if (!(char.IsUpper(input[0]))) {
                    Console.WriteLine("    Make sure your answer starts with a capital letter");
                }
            }

                Console.WriteLine();

                //return true or false for correct or incorrect answers
                if (input == answer)  {
                    Console.WriteLine($" Yes, {input} is correct!");
                    Console.WriteLine(" Congrats!");
                    return true;
                }
                else  {
                    return false;
                }
            }

            public static string ValidateString(string message = "    Do not leave blank") {
                string input = null;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(message);
                Console.ResetColor();
                input = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(input))  {
                    Console.Write("    Do not leave blank: ");
                    input = Console.ReadLine().ToLower();
                }
                return input;
            }

        }
    }


