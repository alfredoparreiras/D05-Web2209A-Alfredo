using Passports.Models;

namespace Passports.Views
{
    public class PassportConsoleMenu
    {
        private readonly string title;
        private readonly string message;
        private readonly Dictionary<int, Passport> passports;

        public PassportConsoleMenu(string title, string message, Dictionary<int, Passport> passports)
        {
            this.title = title;
            this.message = message;
            this.passports = passports;
        }

        public Passport DisplayAndGetSelectedPassport()
        {
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine();

            foreach (Passport passport in passports.Values)
                Console.WriteLine($"    {passport.Id}: {passport}");
            Console.WriteLine($"    X: Cancel");
            Console.WriteLine();

            Console.WriteLine(message);
            Passport selectedPassport = GetSelectedPassport();
            Console.WriteLine();

            return selectedPassport;
        }

        private Passport GetSelectedPassport()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Length == 1 && char.ToUpper(input[0]) == 'X')
                {
                    return null;
                }
                else if (int.TryParse(input, out int id))
                {
                    if (passports.TryGetValue(key: id, out Passport passport))
                        return passport;
                    else
                        Console.WriteLine($"Error: There is no passport with id {id}.");
                }
                else
                {
                    Console.WriteLine($"Error: \"{input}\" is not an integer.");
                }
            }
        }
    }
}
