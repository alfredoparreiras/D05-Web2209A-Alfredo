namespace Passports.Views
{
    public class ConsoleMenu
    {
        private readonly string title;
        private readonly string message;
        private readonly List<string> commands;

        public ConsoleMenu(string title, string message, List<string> commands)
        {
            this.title = title;
            this.message = message;
            this.commands = commands;
        }

        public int DisplayAndGetSelectionIndex()
        {
            return DisplayAndGetSelection() - 1;
        }

        public int DisplayAndGetSelection()
        {
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine();

            for (int i = 0; i < commands.Count; i++)
                Console.WriteLine($"    {i + 1}: {commands[i]}");
            Console.WriteLine();

            Console.WriteLine(message);
            int selection = ReadInteger(1, commands.Count);
            Console.WriteLine();

            return selection;
        }

        public static int ReadInteger(string message, int min, int max)
        {
            Console.WriteLine(message);
            return ReadInteger(min, max);
        }

        public static int ReadInteger(string message)
        {
            Console.WriteLine(message);
            return ReadInteger();
        }

        public static int ReadInteger(int min, int max)
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

        public static int ReadInteger()
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
    }
}
