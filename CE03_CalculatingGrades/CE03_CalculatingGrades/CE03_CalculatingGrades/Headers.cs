using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMckinney_CE03
{
    class Headers
    {
        public static void MainMenu(){
            Console.Clear();
            Linebreak();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   _____ ______  __ __  ___      ___  ____   ______       ____  ____    ____  ___      ___  _____");
            Console.WriteLine("  / ___/|      ||  |  ||   \\    /  _]|    \\ |      |     /    ||    \\  /    ||   \\    /  _]/ ___/");
            Console.WriteLine(" (   \\_ |      ||  |  ||    \\  /  [_ |  _  ||      |    |   __||  D  )|  o  ||    \\  /  [_(   \\_ ");
            Console.WriteLine("  \\__  ||_|  |_||  |  ||  D  ||    _]|  |  ||_|  |_|    |  |  ||    / |     ||  D  ||    _]\\__  |");
            Console.WriteLine("  /  \\ |  |  |  |  :  ||     ||   [_ |  |  |  |  |      |  |_ ||    \\ |  _  ||     ||   [_ /  \\ |");
            Console.WriteLine("  \\    |  |  |  |     ||     ||     ||  |  |  |  |      |     ||  .  \\|  |  ||     ||     |\\    |");
            Console.WriteLine("   \\___|  |__|   \\__,_||_____||_____||__|__|  |__|      |___,_||__|\\_||__|__||_____||_____| \\___|");
            Console.ResetColor();
            Linebreak();
            Console.WriteLine("\r\n    [1] View Students");
            Console.WriteLine("    [2] View Courses");
            Console.WriteLine("    [3] Edit Student Grades");
            Console.WriteLine("    [4] View All Students Courses & Grades");
            Console.WriteLine("\r\n    [0] Exit\r\n");
            Linebreak();
        }

        public static void Linebreak(){
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" ================================================================================================");
            Console.ResetColor();
        }

        public static void Linebreak2() {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" ------------------------------------------------------------------------------------------------");      
            Console.ResetColor();
        }
    }
}
