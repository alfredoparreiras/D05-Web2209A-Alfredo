namespace Chapter1_1
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Enter circle radius:");
            double radius = ReadDouble();

            double perimeter = 2 * Math.PI * radius;
            Console.WriteLine($"Circle perimeter = {perimeter}");

            double area = Math.PI * radius * radius;
            Console.WriteLine($"Circle area = {area}");
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