using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingCards
{
    class Program
    {
        //PLAYER OBJECTS
        static Player player1 = new Player();
        static Player player2 = new Player();
        static Player player3 = new Player();
        static Player player4 = new Player();
        static List<Player> players = new List<Player> { player1, player2, player3, player4 };

        static void Main(string[] args)
        {

            Headers.Header();
            
            //CARD DECK
            List<string> cards = new List<string> { "2 Spades", "2 Diamonds", "2 Hearts", "2 Clubs", "3 Spades", "3 Diamonds", "3 Hearts", "3 Clubs", "4 Spades", "4 Diamonds", "4 Hearts", "4 Clubs", "5 Spades", "5 Diamonds", "5 Hearts", "5 Clubs", "6 Spades", "6 Diamonds", "6 Hearts", "6 Clubs", "7 Spades", "7 Diamonds", "7 Hearts", "7 Clubs", "8 Spades", "8 Diamonds", "8 Hearts", "8 Clubs", "9 Spades", "9 Diamonds", "9 Hearts", "9 Clubs", "10 Spades", "10 Diamonds", "10  Hearts", "10 Clubs", "J Spades", "J Diamonds", "J Hearts", "J Clubs", "Q Spades", "Q Diamonds", "Q Hearts", "Q Clubs", "K Spades", "K Diamonds", "K Hearts", "K Clubs", "A Spades", "A Diamonds", "A Hearts", "A Clubs" };
            //SHUFFLE CARDS
            List<string> shuffledcards = cards.OrderBy(a => Guid.NewGuid()).ToList();

            //ENTER PLAYERS NAMES
            player1.playerName = ValidateString(" Play1 Enter Name: ");
            player2.playerName = ValidateString(" Play2 Enter Name: ");
            player3.playerName = ValidateString(" Play3 Enter Name: ");
            player4.playerName = ValidateString(" Play4 Enter Name: ");

            //DEAL CARDS TO PLAYERS
            for (int i = 0; i < cards.Count; i += 4) { player1.playerHand.Add(shuffledcards[i]); }
            for (int i = 1; i < cards.Count; i += 4) { player2.playerHand.Add(shuffledcards[i]); }
            for (int i = 2; i < cards.Count; i += 4) { player3.playerHand.Add(shuffledcards[i]); }
            for (int i = 3; i < cards.Count; i += 4) { player4.playerHand.Add(shuffledcards[i]); }

            //PRINT NAMES AND CARDS TO CONSOLE
            Headers.Header();
            Console.WriteLine($"\r\n {player1.playerName + "'s Hand",-25}{player2.playerName + "'s Hand",-25}{player3.playerName + "'s Hand",-25}{player4.playerName + "'s Hand",-25}");
            Headers.LineBreak2();
            for (int i = 0; i < player1.playerHand.Count; i++) {
                Console.Write($" {player1.playerHand[i],-25}");
                Console.Write($"{player2.playerHand[i],-25}");
                Console.Write($"{player3.playerHand[i],-25}");
                Console.WriteLine($"{player4.playerHand[i],-25}");
            }

            //PLAYER TOTALS
            for (int i = 0; i < player1.playerHand.Count; i++) { player1.playerTotal += CardValues(player1.playerHand[i]); }
            for (int i = 0; i < player2.playerHand.Count; i++) { player2.playerTotal += CardValues(player2.playerHand[i]); }
            for (int i = 0; i < player3.playerHand.Count; i++) { player3.playerTotal += CardValues(player3.playerHand[i]); }
            for (int i = 0; i < player4.playerHand.Count; i++) { player4.playerTotal += CardValues(player4.playerHand[i]); }

            List<Player> sort = players.OrderByDescending(i => i.playerTotal).ToList();

            //PRINT TOTALS TO CONSOLE
            Console.WriteLine("\r\n Totals:");
            Headers.LineBreak2();
            Console.WriteLine($" {player1.playerTotal,-25}{player2.playerTotal,-25}{player3.playerTotal,-25}{player4.playerTotal,-25}");
            Headers.LineBreak2();

            Place("1st", 0);
            Place("2nd", 1);
            Place("3rd", 2);
            Place("4th", 3);
            Headers.LineBreak();
        }

        public static int CardValues(string cards) {
           // var match = cards.FirstOrDefault(stringToCheck => stringToCheck.Contains(""));

            int value = 0;
          //  foreach (var card in cards) {
                if (cards.Contains("2")) { value = 2; return value; }
                if (cards.Contains("3")) { value = 3; return value; }
                if (cards.Contains("4")) { value = 4; return value; }
                if (cards.Contains("5")) { value = 5; return value; }
                if (cards.Contains("6")) { value = 6; return value; }
                if (cards.Contains("7")) { value = 7; return value; }
                if (cards.Contains("8")) { value = 8; return value; }
                if (cards.Contains("9")) { value = 9; return value; }
                if (cards.Contains("10")) { value = 10; return value; }
                if (cards.Contains("J")) { value = 12; return value; }
                if (cards.Contains("Q")) { value = 12; return value; }
                if (cards.Contains("K")) { value = 12; return value; }
                if (cards.Contains("A")) { value = 15; return value; }
            //}
           return value;
        }

        public static void Place(string p, int i) {
            List<Player> sort = players.OrderByDescending(x => x.playerTotal).ToList();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" {p} Place: ");
            Console.ResetColor();
            Console.Write($"{sort[i].playerName} ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"Total of: ");
            Console.ResetColor();
            Console.WriteLine($"{ sort[i].playerTotal}");
        }

        public static string ValidateString(string message = "    Please enter a value: ") {
            string input = null;
            Console.Write(message);
            input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input))  {
                Console.Write("    Do not leave blank: ");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
