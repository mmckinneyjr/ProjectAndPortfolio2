using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTracker
{
    class Validation
    {

        //Validate Int (min/max/string)
        public static int ValidateInt(int min, int max, string message = "    Please enter valid value: ")
        {
            int validInt;
            string input = null;
            Console.Write(message);
            input = Console.ReadLine();
            while (!((int.TryParse(input, out validInt)) && (min <= validInt && max >= validInt))) {
                Console.Write("    Please enter a valid option: ");
                input = Console.ReadLine();
                int.TryParse(input, out validInt);
            }
            return validInt;
        }

        //Decimal
        public static decimal ValidateDec(string message = "    Please enter valid value: ") {
            decimal validDec;
            string input = null;
            Console.Write(message);
            input = Console.ReadLine();
            while (!((decimal.TryParse(input, out validDec)) && (validDec >= 0))) {
                Console.Write("    Please enter a valid option: ");
                input = Console.ReadLine();
                decimal.TryParse(input, out validDec);
            }
            validDec = Math.Round(validDec, 2);
            return validDec;
        }

    }
}
