using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {

        static List<int> Score = new List<int>();

        static void Main(string[] args)
        {
            Console.Title = "Mark Mckinney's Code Challenges - Rock, Paper, Scissors, Lizard, Spock";
            Headers.Header();
            int counter = 1;
            bool isRunning = true;
            while (counter <= 10 || isRunning == true) {

                Console.WriteLine($" Game {counter} of 10\r\n");
                //USER CHOICE
                string userInput = ValidateString(" Selection: ");

                if (userInput == "0") {
                    isRunning = false;
                    break;
                }
                Headers.Header();

                //COMPUTERS CHOICE
                string compChoice = "";
                int number = 0;
                Random randomNumber = new Random();
                number = randomNumber.Next(1, 6);
                int compChoiceNumber = number;

                //Console Output
                if (compChoiceNumber == 1) { compChoice = "Rock"; }
                else if (compChoiceNumber == 2) { compChoice = "Paper"; }
                else if (compChoiceNumber == 3) { compChoice = "Scissors"; }
                else if (compChoiceNumber == 4) { compChoice = "Lizard"; }
                else if (compChoiceNumber == 5) { compChoice = "Spock"; }

                if (userInput == "1" || userInput == "rock") { userInput = "Rock"; }
                else if (userInput == "2" || userInput == "paper") { userInput = "Paper"; }
                else if (userInput == "3" || userInput == "scissor") { userInput = "Scissors"; }
                else if (userInput == "4" || userInput == "lizard") { userInput = "Lizard"; }
                else if (userInput == "5" || userInput == "spock") { userInput = "Spock"; }


                Console.WriteLine(" You chose {0}, The computer chose {1}", userInput, compChoice);
                Console.WriteLine("\r\n" + WinLose(userInput, compChoice));
                counter++;
                Headers.LineBreak();
            }
            Headers.Header();
            Console.WriteLine(" Score:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Wins: ");
            Console.ResetColor();
            Console.WriteLine(totalScore(Score, 1));

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Loses: ");
            Console.ResetColor();
            Console.WriteLine(totalScore(Score, 2));

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Ties: ");
            Console.ResetColor();
            Console.WriteLine(totalScore(Score, 3));

            if (totalScore(Score,1) > totalScore(Score, 2) && totalScore(Score, 1) > totalScore(Score, 3)) {
                Console.WriteLine(" You WON!");
            }

            else if (totalScore(Score, 2) > totalScore(Score, 1)  && totalScore(Score, 2) > totalScore(Score, 3)) {
                Console.WriteLine(" You LOST!");
            }

            else  {
                Console.WriteLine(" You TIED!");
            }

            Headers.LineBreak();

        }

        public static int totalScore(List<int> count, int i) {
            return count.Count(x => x.Equals(i));
        }

        private static string WinLose(string input, string comp) {
            string winLose = "";

            //ROCK
            //WIN
            if ((input == "Rock") && (comp == "Scissors" || comp  == "Lizard")) {
                    Score.Add(1);
                    winLose = " You Win"; 
            }
            //lose
            if ((input == "Rock") && (comp  == "Paper" || comp == "Spock")) {
                Score.Add(2);
                winLose = " You Lose";
            }

            //PAPER
            //win
            if ((input == "Paper") && (comp == "Rock" || comp == "Spock"))  {
                Score.Add(1);
                winLose = " You Win";
            }
            //lose
            if ((input == "Paper") && (comp == "Scissors" || comp == "Lizard")) {
                Score.Add(2);
                winLose = " You Lose";
            }

            //SCISSOR
            //win
            if ((input == "Scissors") && (comp == "Paper" || comp == "Lizard")) {
                Score.Add(1);
                winLose = " You Win";
            }
            //lose
            if ((input == "Scissors") && (comp == "Rock" || comp == "Spock"))  {
                Score.Add(2);
                winLose = " You Lose";
            }

            //LIZARD
            //win
            if ((input == "Lizard") && (comp == "Paper" || comp  == "Spock")) {
                Score.Add(1);
                winLose = " You Win";
            }
            //lose
            if ((input == "Lizard") && (comp == "Rock" || comp == "Scissors"))  {
                Score.Add(2);
                winLose = " You Lose";
            }

            //LIZARD
            //win
            if ((input == "Spock") && (comp == "Rock" || comp == "Scissors")) {
                Score.Add(1);
                winLose = " You Win";
            }
            //lose
            if ((input == "Spock") && (comp == "Paper" || comp == "Lizard")) {
                Score.Add(2);
                winLose = " You Lose";
            }

            if (input == comp) {
                Score.Add(3);
                winLose = " You tied";
            }


            return winLose;
            
        }
    
        //Validate Selection int and strings
        public static string ValidateString (string message = " Selection: ")  {
            Console.Write(message);
            string input = Console.ReadLine().ToLower().Trim();
            while (!((input == "0") || (input == "exit") ||
                     (input == "1") || (input == "rock") ||
                     (input == "2") || (input == "paper") ||
                     (input == "3") || (input == "scissor") ||
                     (input == "4") || (input == "lizzard") ||
                     (input == "5") || (input == "spock"))) {
                Console.Write("    Please choose a valid option: ");
                input = Console.ReadLine();
            }
            return input;
        }



    }
    
}
