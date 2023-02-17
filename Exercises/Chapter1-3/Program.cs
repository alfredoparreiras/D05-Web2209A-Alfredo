namespace Chapter1_3
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("How many numbers do you want to enter?");
            int count = ReadInteger();

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter a number:");
                sum += ReadDouble();
            }

            Console.WriteLine($"Sum = {sum}");
        }

        private static int ReadInteger()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                    return number;
                Console.WriteLine($"Error: {input} is not an integer.");
            }
        }

        private static double ReadDouble()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double number))
                    return number;
                Console.WriteLine($"Error: {input} is not a number.");
            }
        }
    }
}