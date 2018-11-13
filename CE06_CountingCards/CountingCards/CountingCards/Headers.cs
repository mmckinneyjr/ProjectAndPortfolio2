using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingCards
{
    public class Headers
    {

        public static void Header() {
            Console.Clear();
            Console.WindowWidth = 130;
            LineBreak();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                                          __   ____  ____   ___   _____");
            Console.WriteLine(" .------..------.                        /  ] /    ||    \\ |   \\ / ___/                   .------..------.");
            Console.WriteLine(" | A.--. ||K.--.|                       /  / |  o  ||  D  )|    (   \\_                    |Q.--. ||J.--. |");
            Console.WriteLine(" | (\\/) || :/\\: |                      /  /  |     ||    / |  D  \\__  |                   | (\\/) || :(): |");
            Console.WriteLine(" | :\\/: || :\\/: |                     /   \\_ |  _  ||    \\ |     /  \\ |                   | :\\/: || ()() |");
            Console.WriteLine(" | '--'A|| '--'K|                     \\     ||  |  ||  .  \\|     \\    |                   | '--'Q|| '--'J|");
            Console.WriteLine(" `------'`------'                      \\____||__|__||__|\\_||_____|\\___|                   `------'`------'");
            Console.ResetColor();
            LineBreak();
        }

        public static void LineBreak() {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" =========================================================================================================");
            Console.ResetColor();
        }

        public static void LineBreak2() {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" =========================================================================================================");
            Console.ResetColor();
        }
    }
}
