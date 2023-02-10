using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Passport.Models;

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
        public static bool ValidateName(string input)
        {
            if (input == null)
                throw new ArgumentNullException("First Name is Null, please insert a Value");

            else if (input.Length == 0)
                throw new ArgumentException("First Name must be inserted");

            return true;
        }
        public static string ValidateNameWithInput()
        {
            string input = Console.ReadLine();
            
            if (String.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("First Name is Null, please insert a Value");
            
            if (input.Length == 0)
                throw new ArgumentException("First Name must be inserted");
            
            return input.Replace(" ","").ToUpper();
        }
        public static string ValidatePassportId()
        {
            string input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(string.Format("First Name{0}{1} is Null, please insert a Value", "ARG0", "ARG1"));
            
            if (input.Length == 0)
                throw new ArgumentException("First Name must be inserted");
            
            return input.Replace(" ","");
        }
        public static bool ValidateDateOfBirth(DateTime input)
        {
            if(input.CompareTo(DateTime.UtcNow) > 0)
                throw new ArgumentException("The date of birth needs to be earlier than today");

            return true;
        }
        public static bool ValidateDateOfTravel(DateTime input, Models.Passport passportCheck)
        {
            if(input.CompareTo(passportCheck.PassportCreation) < 0)
                throw new ArgumentException("The date of travel needs to be later than the date of passport's creation");
        
            return true;
        }
    }
}
