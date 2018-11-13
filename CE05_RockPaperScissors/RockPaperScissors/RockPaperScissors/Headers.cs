using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Headers
    {

        public static void Header() {
            Console.Clear();
            LineBreak();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" ╦═╗┌─┐┌─┐┬┌─   ╔═╗┌─┐┌─┐┌─┐┬─┐   ╔═╗┌─┐┬┌─┐┌─┐┌─┐┬─┐┌─┐  ╦  ┬┌─┐┌─┐┬─┐┌┬┐  ╔═╗┌─┐┌─┐┌─┐┬┌─");
            Console.WriteLine(" ╠╦╝│ ││  ├┴┐   ╠═╝├─┤├─┘├┤ ├┬┘   ╚═╗│  │└─┐└─┐│ │├┬┘└─┐  ║  │┌─┘├─┤├┬┘ ││  ╚═╗├─┘│ ││  ├┴┐");
            Console.WriteLine(" ╩╚═└─┘└─┘┴ ┴┘┘ ╩  ┴ ┴┴  └─┘┴└─┘┘ ╚═╝└─┘┴└─┘└─┘└─┘┴└─└─┘┘ ╩═╝┴└─┘┴ ┴┴└──┴┘┘ ╚═╝┴  └─┘└─┘┴ ┴");
            Console.ResetColor();
            LineBreak();
            Console.WriteLine(" Rock, Paper, Scissors:\r\n");
            Console.WriteLine(" Scissors cuts paper, paper covers rock, rock crushes lizard, lizard poisons Spock, Spock\r\n smashes scissors, scissors decapitates lizard, lizard eats paper, paper disproves Spock,\r\n Spock vaporizes rock, and as it always has, rock crushes scissors.\r\n");
            Console.WriteLine(" [1] = Rock");
            Console.WriteLine(" [2] = Paper");
            Console.WriteLine(" [3] = Scissors");
            Console.WriteLine(" [4] = Lizzard");
            Console.WriteLine(" [5] = Spock");
            Console.WriteLine("\r\n [0] = Exit\r\n");
            LineBreak();
        }

        public static void LineBreak() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ==========================================================================================");
            Console.ResetColor();

        }




    }
}
