using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DateTime = System.DateTime;

namespace Passport.Menu
{
    internal class PassportMenu
    {
        // Private Fields 
        private ConsoleMenu consoleMenu;
        private List<string> menuOptions;
        private readonly Dictionary<string, Models.Passport> passportsDataBase = new Dictionary<string, Models.Passport>();
        public PassportMenu()
        {
            menuOptions = new List<string>();
            consoleMenu = new ConsoleMenu(menuOptions, "Passport Control System v2");
     
            // Inserting Menu options to display
            menuOptions.Add("Display All Passports");
            menuOptions.Add("Consult Passport Details");
            menuOptions.Add("Add Passaport");
            menuOptions.Add("Delete Passport");
            menuOptions.Add("Travel");
            menuOptions.Add("Exit");
            
            //TODO: Check with jared if there is a better way to create this passport using passport ID as Dictionary Key.
            // Inserting Hard-Code Passports
            var passport = new Models.Passport("Alfredo", "Silva", new DateTime(1990, 09, 19), "Brazil");
            passportsDataBase.Add(passport.Id,passport);
            var passport2 = new Models.Passport("Jared", "Chevalier", new DateTime(1989, 10, 29), "Canada");
            passportsDataBase.Add(passport2.Id,passport2);
            var passport3 = new Models.Passport("Gabriela", "Franco", new DateTime(1993, 01, 18), "Colômbia");
            passportsDataBase.Add(passport3.Id,passport3);
            var passport4 = new Models.Passport("Danials", "Behzad", new DateTime(2002, 03, 10), "Iran");
            passportsDataBase.Add(passport4.Id,passport4);
        }
        public void Start()
        {
            int selection = 0;
            do
            {
                selection = consoleMenu.displayAndGetSelection();

                switch (selection)
                {
                    case 1: 
                        DisplayAllPassports();
                        ConsoleMenu.DisplayReturnMessage();
                        Console.ReadKey();
                        break;
                    case 2:
                        DisplaySpecificPassport();
                        ConsoleMenu.DisplayReturnMessage();
                        break;
                    case 3:
                        AddNewPassport(); 
                        ConsoleMenu.DisplayReturnMessage();
                        break; 
                    case 4:
                        DeletePassport(); 
                        ConsoleMenu.DisplayReturnMessage();
                        break; 
                    case 5:
                        AddCitizenTravel();
                        ConsoleMenu.DisplayReturnMessage();
                        break;
                }
                
                if(selection == menuOptions.Count)
                    Console.WriteLine("Logging out of the system");
            } while (selection != menuOptions.Count);
        }
        private void AddCitizenTravel()
        {
            string userInput = UserIdInput();
            Console.Write("Please insert citizen's country of Destination: ");
            string countryOfDestination = Validations.ValidateNameWithInput();
            
            Console.Write("Please insert citizen's date of entry: ");
            DateTime dateOfEntry = DateTime.Parse(Console.ReadLine());
            if(Validations.ValidateDateOfTravel(dateOfEntry,passportsDataBase[userInput]))
                passportsDataBase[userInput].Travelling(countryOfDestination, dateOfEntry);
        }
        private void DeletePassport()
        {
            string userInput = UserIdInput();
            Models.Passport temp = passportsDataBase[userInput];
            passportsDataBase.Remove(userInput);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{temp.ToString()}\nWas sucessfully deleted.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void AddNewPassport()
        {
            //TODO: Check if there is another passport with same name?
            Console.Write("Please insert citizen first name: ");            
            string firstName = Validations.ValidateNameWithInput();

            Console.Write("Please insert citizen last name: ");
            string lastName = Validations.ValidateNameWithInput();

            //TODO: Write DateOfBirth Validation - tryparse
            Console.Write("Please insert citizen's date of birth: ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Please insert citizen's country of residence: ");
            string countryOfResidence = Validations.ValidateNameWithInput();

            var newPassport = new Models.Passport(firstName, lastName, dateOfBirth, countryOfResidence);
            passportsDataBase.Add(newPassport.Id,newPassport);
        }
        private void DisplaySpecificPassport()
        {
            string userInput = UserIdInput();
            Console.WriteLine($"\nDisplaying Passport information : \n\n{passportsDataBase[userInput].ToString()}\n.");
        }
        public void DisplayAllPassports()
        {
            foreach (KeyValuePair<string, Models.Passport> passport in passportsDataBase)
            {
                Console.WriteLine(passport.Value.ToString());
            }
        }
        private static string UserIdInput()
        {
            Console.Write("Please enter the passport ID : ");
            string userInput = Validations.ValidatePassportId();
            return userInput;
        }
    }
}
