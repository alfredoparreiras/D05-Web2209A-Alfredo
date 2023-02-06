using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport
{
    internal class Validations
    {

        public static int ValidateInt()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                    return number;
                Console.WriteLine( $"Error : {input} is not a valid input.\n");
            }
        }

        public static double ValidateDouble()
        {
            while(true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double number))
                    return number;
                Console.WriteLine($"Error : {input} is not a valid input\n");
            }
        }
    }
}
