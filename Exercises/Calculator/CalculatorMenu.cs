namespace Calculator
{
    public class CalculatorMenu
    {
        private readonly Calculator calculator;
        private readonly List<string> commands;

        public CalculatorMenu()
        {
            calculator = new Calculator();
            commands = new List<string>
            {
                "Add numbers",
                "Display ascending numbers",
                "Check divisibility",
                "Check even or odd",
                "Find minimum number",
                "Sort numbers",
                "Find most common character",
                "Exit"
            };
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Calculator menu");
                Console.WriteLine();

                for (int i = 0; i < commands.Count; i++)
                    Console.WriteLine($"    {i + 1}: {commands[i]}");

                Console.WriteLine();
                Console.WriteLine("Select a command:");
                int selection = ReadInteger(1, commands.Count);
                Console.WriteLine();

                switch (selection)
                {
                    case 1: AddNumbers(); break;
                    case 2: DisplayAscendingNumbers(); break;
                    case 3: CheckDivisibility(); break;
                    case 4: CheckEvenOrOdd(); break;
                    case 5: FindMinimumNumber(); break;
                    case 6: SortNumbers(); break;
                    case 7: FindMostCommonCharacter(); break;
                    case 8: return;
                }

                Console.WriteLine();
            }
        }

        private void AddNumbers()
        {
            Console.WriteLine("Enter number:");
            int first = ReadInteger();

            Console.WriteLine("Enter number:");
            int second = ReadInteger();

            int sum = calculator.Add(first, second);
            Console.WriteLine($"{first} + {second} = {sum}");
        }

        private static void DisplayAscendingNumbers()
        {
            Console.WriteLine("Enter number:");
            int number = ReadInteger(1, 100);

            Console.Write("{ ");
            for (int i = 1; i <= number; i++)
                Console.Write(i + " ");
            Console.WriteLine("}");
        }

        private void CheckDivisibility()
        {
            Console.WriteLine("Enter number:");
            int number = ReadInteger();

            Console.WriteLine("Enter divisor:");
            int divisor = ReadInteger();

            bool divisible = calculator.IsDivisible(number, divisor);
            if (divisible)
                Console.WriteLine($"{number} is divisible by {divisor}.");
            else
                Console.WriteLine($"{number} is not divisible by {divisor}.");
        }

        private void CheckEvenOrOdd()
        {
            Console.WriteLine("Enter number:");
            int number = ReadInteger();

            bool even = calculator.IsEven(number);
            if (even)
                Console.WriteLine($"{number} is even.");
            else
                Console.WriteLine($"{number} is odd.");
        }

        private void FindMinimumNumber()
        {
            int[] numbers = ReadNumbers();
            DisplayNumbers(numbers);

            int minimum = calculator.GetMinimum(numbers);
            Console.WriteLine($"Minimum number: {minimum}");
        }

        private void SortNumbers()
        {
            int[] numbers = ReadNumbers();
            DisplayNumbers(numbers);

            Console.WriteLine("Sorting numbers...");
            calculator.Sort(numbers);
            DisplayNumbers(numbers);
        }

        private void FindMostCommonCharacter()
        {
            Console.WriteLine("Enter text:");
            string text = Console.ReadLine();
            char character = calculator.GetMostCommonCharacter(text);
            Console.WriteLine($"Most common character: '{character}'");
        }

        private static int ReadInteger()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int integer))
                    return integer;
                else
                    Console.WriteLine($"Error: \"{input}\" is not an integer.");
            }
        }

        private static int ReadInteger(int min, int max)
        {
            while (true)
            {
                int integer = ReadInteger();
                if (integer >= min && integer <= max)
                    return integer;
                else
                    Console.WriteLine($"Error: {integer} is not in the valid range ({min}, {max}).");
            }
        }

        private static int[] ReadNumbers()
        {
            Console.WriteLine("Enter size:");
            int size = ReadInteger(0, int.MaxValue);
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter a number between 0 and 100:");
                int number = ReadInteger(0, 100);
                array[i] = number;
            }
            return array;
        }

        private static void DisplayNumbers(int[] numbers)
        {
            Console.Write("{ ");
            foreach (int number in numbers)
                Console.Write(number + " ");
            Console.WriteLine("}");
        }
    }
}
