using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProgram
{
    internal class Calculator
    {
        public Calculator() { }

        public  double Sum(double x, double y)
        {
            x = Validations.ReadDouble();
            y = Validations.ReadDouble();

            return x + y;
        }

        public  bool IsDivisibleBy(int x, int y)
        {
            x = Validations.ReadInt();
            y = Validations.ReadInt();
            return x % y == 0;
        }

        public  bool IsEven(int x)
        {
            x = Validations.ReadInt();

            return x % 2 == 0;
        }

        public  double GetMinimum(double[] numbers)
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

        public  void SortArray(double[] numbers)
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

        public  void GetMostCommonCharacter(string input)
        {
            // Validation
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (input.Length == 0)
                throw new ArgumentException("You need to insert a valid input value");

            // Creating a List do store the character object
            var characterCountsList = new List<CharacterCount>();

            //Loop to check if a character exist, if exist will increase the counter if isn't will create a new object with counter set 1;
            for (var i = 0; i < input.Length; i++)
            {
                char character = input[i];
                CharacterCount characterCount = GetCharacterCount(characterCountsList, character);

                if (characterCount != null)
                {
                    characterCountsList.Add(new)
                }
                else
                {
                    characterCount.Count++;
                }

                // Search characterCounts list to find whether it has this character in it
                // If the list already contains, then increment the count
                // Else create a new character count and add it to the list

                // Displayng the List 
                foreach (CharacterCount test in characterCountsList)
                {
                    Console.WriteLine($"The char is {test.Character} and the count is {test.Count} ");
                }
            }
        }

        private  CharacterCount GetCharacterCount(List<CharacterCount> characterCounts, char character)
        {
            for (var j = 0; j < characterCounts.Count; j++)
            {
                if (characterCounts[j].Character == character)
                {
                    return characterCounts[j];
                }
            }
            return null;
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
}
