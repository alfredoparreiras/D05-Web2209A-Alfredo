namespace Calculator
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public bool IsDivisible(int number, int divisor)
        {
            return number % divisor == 0;
        }

        public bool IsEven(int number)
        {
            return IsDivisible(number, 2);
        }

        public int GetMinimum(int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));
            if (numbers.Length == 0)
                throw new ArgumentException("Numbers array must not be empty.", nameof(numbers));

            int minimum = int.MaxValue;

            foreach (int number in numbers)
            {
                if (minimum > number)
                    minimum = number;
            }

            return minimum;
        }

        public void Sort(int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
        }

        public char GetMostCommonCharacter(string text)
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

    public class DictionaryCalculator
    {
        public char GetMostCommonCharacter(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));
            if (text.Length == 0)
                throw new ArgumentException("Text must not be empty.", nameof(text));

            if (text.Length == 1)
                return text[0];

            Dictionary<char, int> characterOccurrences = GetCharacterOccurrences(text);
            return GetMostCommonCharacter(characterOccurrences);
        }

        private static Dictionary<char, int> GetCharacterOccurrences(string text)
        {
            Dictionary<char, int> characterOccurrences = new Dictionary<char, int>();

            foreach (char character in text)
            {
                if (characterOccurrences.ContainsKey(character))
                {
                    int occurrences = characterOccurrences[character] + 1;
                    characterOccurrences[character] = occurrences;
                }
                else
                {
                    characterOccurrences.Add(character, 1);
                }
            }

            return characterOccurrences;
        }

        private static char GetMostCommonCharacter(Dictionary<char, int> characterOccurrences)
        {
            int maximum = int.MinValue;
            char character = char.MinValue;

            foreach (KeyValuePair<char, int> entry in characterOccurrences)
            {
                if (maximum < entry.Value)
                {
                    maximum = entry.Value;
                    character = entry.Key;
                }
            }

            return character;
        }
    }
}
