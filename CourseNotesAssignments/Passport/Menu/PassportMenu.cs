using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Menu
{
    internal class PassportMenu
    {
        private ConsoleMenu consoleMenu;
        private List<string> menuOptions;

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
