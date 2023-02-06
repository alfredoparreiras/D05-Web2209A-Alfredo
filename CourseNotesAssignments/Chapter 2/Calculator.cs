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
            return x + y;
        }

        public  bool IsDivisibleBy(int x, int y)
        { 
            return x % y == 0;
        }

        public  bool IsEven(int x)
        {
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

            double Minimum = double.MaxValue;


            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < Minimum)
                    Minimum = numbers[i];
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
                Console.Write(number + " ");
            }
            Console.WriteLine('\n');
        }

        // Method solution created by @Jared Chevalier
        public char GetMostCommonChaacter(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));
            if (text.Length == 0)
                throw new ArgumentException("Text must not be empty.", nameof(text));

            if (text.Length == 1)
                return text[0];

            List<CharacterCount> characterCounts = GetCharacterCounts(text);
            CharacterCount mostCommonCharacterCount = GetMostCommonCharacterCount(characterCounts);
            return mostCommonCharacterCount.Character;
        }

        private static List<CharacterCount> GetCharacterCounts(string text)
        {
            List<CharacterCount> characterCounts = new List<CharacterCount>();

            foreach (char character in text)
            {
                CharacterCount characterCount = GetCharacterCount(characterCounts, character);
                if (characterCount == null)
                    characterCounts.Add(new CharacterCount(character, 1));
                else
                    characterCount.Count++;
            }

            return characterCounts;
        }

        private static CharacterCount GetCharacterCount(List<CharacterCount> characterCounts, char character)
        {
            foreach (CharacterCount characterCount in characterCounts)
            {
                if (characterCount.Character == character)
                    return characterCount;
            }
            return null;
        }

        private static CharacterCount GetMostCommonCharacterCount(List<CharacterCount> characterCounts)
        {
            CharacterCount mostCommon = null;
            foreach (CharacterCount characterCount in characterCounts)
            {
                if (mostCommon == null || characterCount.Count > mostCommon.Count)
                    mostCommon = characterCount;
            }
            return mostCommon;
        }

        private class CharacterCount
        {
            public readonly char Character;
            public int Count;

            public CharacterCount(char character, int count)
            {
                Character = character;
                Count = count;
            }
        }
    }
}
