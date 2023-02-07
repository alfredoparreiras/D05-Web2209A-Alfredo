using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateTime = System.DateTime;

namespace Passport.Menu
{
    internal class PassportMenu
    {
        private static int _nextId = 0001;
        private ConsoleMenu consoleMenu;
        private List<string> menuOptions;
        private readonly Dictionary<int, Passport> passportsDataBase = new Dictionary<int, Passport>();

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
            
            // Inserting Hard-Code Passports
            passportsDataBase.Add(_nextId++ , new Passport("Alfredo", "Silva", new DateTime(1990, 09, 19), "Brazil"));
            passportsDataBase.Add(_nextId++, new Passport("Jared", "Chevalier", new DateTime(1989, 10, 29), "Canada"));
            passportsDataBase.Add(_nextId++, new Passport("Gabriela", "Franco", new DateTime(1993, 01, 18), "Colômbia"));
            passportsDataBase.Add(_nextId++, new Passport("Danials", "Behzad", new DateTime(2002, 03, 10), "Iran"));
        }

        public void Start()
        {
            int selection = 0;

            do
            {
                selection = consoleMenu.displayAndGetSelection();

            } while (selection != menuOptions.Count);
        }

    }
}
