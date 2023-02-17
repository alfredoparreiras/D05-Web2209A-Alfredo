using Passports.Models;

namespace Passports.Views
{
    public class PassportMenu
    {
        private readonly Dictionary<int, Passport> passports;
        private readonly ConsoleMenu mainMenu;
        private int nextId;
        
        public PassportMenu()
        {
            passports = new Dictionary<int, Passport>();
            mainMenu = CreateMainMenu();
            nextId = 101;
        
            AddPassport(new Passport(nextId++, "Anna", "Brown", new DateTime(1998, 5, 1), "Canada"));
            AddPassport(new Passport(nextId++, "Catherine", "Dubois", new DateTime(2001, 12, 15), "France"));
        }

        private static ConsoleMenu CreateMainMenu()
        {
            List<string> commands = new List<string>
            {
                "Display all passports",
                "View passport",
                "Add passport",
                "Remove passport",
                "Travel",
                "Exit"
            };

            return new ConsoleMenu("Passport menu", "Select a command:", commands);
        }

        public void Start()
        {
            while (true)
            {
                int selection = mainMenu.DisplayAndGetSelection();
        
                switch (selection)
                {
                    case 1: DisplayAllPassports(); break;
                    case 2: ViewPassport(); break;
                    case 3: AddPassport(); break;
                    case 4: RemovePassport(); break;
                    case 5: Travel(); break;
                    case 6: return;
                }
            }
        }
        
        private void DisplayAllPassports()
        {
            foreach (Passport passport in passports.Values)
            {
                Console.WriteLine(passport);
            }

            Console.ReadLine();
        }
        
        private void ViewPassport()
        {
            if (passports.Count == 0)
            {
                Console.WriteLine("Error: No passports available to view");
                return;
            }

            PassportConsoleMenu menu = new PassportConsoleMenu("View passport", "Select passport to view:", passports);
            Passport passport = menu.DisplayAndGetSelectedPassport();
            if (passport == null)
            {
                return;
            }

            ViewPassport(passport);
            Console.ReadLine();
        }
        
        private static void ViewPassport(Passport passport)
        {
            Console.WriteLine(passport.ToString());
            Console.WriteLine($"Date of birth: {passport.DateOfBirth:yyyy-MM-dd}");
            Console.WriteLine($"Age: {passport.Age} {(passport.Age == 1 ? "year" : "years")} old");
            Console.WriteLine($"Country: {passport.Country}");
            Console.WriteLine($"Current location: {passport.CurrentLocation}");
            Console.WriteLine($"Traveling: {passport.Traveling}");
        }
        
        private void AddPassport()
        {
            try
            {
                Passport passport = ReadPassport();
                AddPassport(passport);
                Console.WriteLine($"Successfully added passport: {passport}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.ReadLine();
        }
        
        private Passport ReadPassport()
        {
            Console.WriteLine("Enter first name:");
            string firstName = Console.ReadLine();
        
            Console.WriteLine("Enter last name:");
            string lastName = Console.ReadLine();
        
            int year = ConsoleMenu.ReadInteger("Enter birth year:", min: DateTime.MinValue.Year, max: DateTime.MaxValue.Year);
            int month = ConsoleMenu.ReadInteger("Enter birth month:", min: 1, max: 12);
            int day = ConsoleMenu.ReadInteger("Enter birth day:", min: 1, max: DateTime.DaysInMonth(year, month));
            DateTime dateOfBirth = new DateTime(year, month, day);
        
            Console.WriteLine("Enter country:");
            string country = Console.ReadLine();
        
            return new Passport(nextId++, firstName, lastName, dateOfBirth, country);
        }
        
        private void AddPassport(Passport passport)
        {
            if (!passports.ContainsKey(passport.Id))
            {
                passports.Add(passport.Id, passport);
            }
        }
        
        private void RemovePassport()
        {
            if (passports.Count == 0)
            {
                Console.WriteLine("Error: No passports available to remove.");
                return;
            }

            PassportConsoleMenu menu = new PassportConsoleMenu("Remove passport", "Select passport to remove:", passports);
            Passport passport = menu.DisplayAndGetSelectedPassport();
            if (passport == null)
            {
                return;
            }

            passports.Remove(passport.Id);
            Console.WriteLine($"Successfully removed passport: {passport}");
            Console.ReadLine();
        }
        
        private void Travel()
        {
            if (passports.Count == 0)
            {
                Console.WriteLine("Error: No passports available to travel.");
                return;
            }

            PassportConsoleMenu menu = new PassportConsoleMenu("Travel", "Select passport to travel:", passports);
            Passport passport = menu.DisplayAndGetSelectedPassport();
            if (passport == null)
            {
                return;
            }

            Console.WriteLine("Enter destination country:");
            string country = Console.ReadLine();
            
            if (passport.CurrentLocation != country)
            {
                passport.Travel(country);
                Console.WriteLine($"Successfully traveled to {country}.");
                Console.WriteLine();
                ViewPassport(passport);
            }
            else
            {
                Console.WriteLine($"Passport current location is already {country}.");
            }

            Console.ReadLine();
        }
    }
}
