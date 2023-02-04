using System.Collections;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CalculatorProgram
{
    internal class Calculator
    {
        static void Main(string[] args)
        {
            double[] testing = { 13.1, 13.2, 13.8, 13.5, 16, 11, 20 };
            GetMostCommonCharacter("Banana");

        }

        public static double Sum(double x, double y)
        {
            x = ReadDouble();
            y = ReadDouble();

            return x + y;
        }

        public static bool IsDivisibleBy(int x, int y)
        {
            x = ReadInt();
            y = ReadInt();
            return x % y == 0;
        }

        public static bool IsEven(int x)
        {
            x = ReadInt();

            return x % 2 == 0;
        }

        public static double GetMinimum(double[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }
            if (numbers.Length == 0)
            {
                throw new ArgumentNullException("Numbers array must not be empty.", nameof(numbers));
            }

            double Minimum = 0;


            for (var i = 0; i < numbers.Length; i++)
            {
                for (var j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i] < numbers[j])
                    {
                        Minimum = numbers[i];
                    }
                }
            }

            return Minimum;
        }

        public static void SortArray(double[] numbers)
        {

            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }
            if (numbers.Length == 0)
            {
                throw new ArgumentException("numbers array must not be empty.", nameof(numbers));
            }

            Array.Sort(numbers);

            //Writing the sorting algo.

            /*double temp = 0;
            for (var i = 0; i < numbers.Length; i++)
            {
                for (var j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i] < numbers[j])
                    {
                        temp = numbers[j];
                        numbers[j] = numbers[i];
                        numbers[i] = temp;
                    }
                }
            }*/

            foreach (double number in numbers)
            {
                Console.Write(number + " - ");
            }
        }

        public static void GetMostCommonCharacter(string input)
        {

            if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (input.Length == 0)
                throw new ArgumentException("You need to insert a valid input value");

            var characterCounts = new List<CharacterCount>();
       
            for (var i = 0; i < input.Length; i++)
            {
                char character = input[i];
                CharacterCount characterCount = GetCharacterCount(characterCounts, character);

                if (characterCount != null)
                {
                    characterCount.Count++;
                }
                else
                {
                    CharacterCount @char = new CharacterCount(input[i]);
                    characterCounts.Add(@char);
                }

                // Search characterCounts list to find whether it has this character in it
                // If the list already contains, then increment the count
                // Else create a new character count and add it to the list


                foreach (CharacterCount test in characterCounts)
                {
                    Console.WriteLine($"The char is {test.Character} and the count is {test.Count} ");
                }
            }
        }

        private static CharacterCount GetCharacterCount(List<CharacterCount> characterCounts, char character)
        {
            for (var j = 0; j < characterCounts.Count; j++)
            {

            }
            return null;
        }

        private static int ReadInt()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                    return number;
                Console.WriteLine($"Error: {input} is not a Int number.");
            }
        }

        private static double ReadDouble()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double number))
                    return number;
                Console.WriteLine($"Error: {input} is not a Double Number.");
            }
        }

    }


    internal class CharacterCount
    {
        public char Character { get; }
        public int Count { get; set; }

        public CharacterCount(char character)
        {
            this.Character = character;
            Count = 1;
        }
    }
}