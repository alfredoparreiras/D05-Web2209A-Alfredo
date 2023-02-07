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

        //TODO: Discover how to validate if only whitespace was typed

        public static bool ValidateName(string input)
        {
            if (input == null)
                throw new ArgumentNullException("First Name is Null, please insert a Value");

            else if (input.Length == 0)
                throw new ArgumentException("First Name must be inserted");

            return true;
        }

        public static bool ValidateDateTime(DateTime input)
        {
            if(input.CompareTo(DateTime.UtcNow) > 0)
                throw new ArgumentException("The date of birth needs to be earlier than today");

            return true;
        }
    }
}
