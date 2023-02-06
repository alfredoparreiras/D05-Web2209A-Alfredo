using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Menu
{
    internal class ConsoleMenu
    {
        private readonly string title;
        private readonly string message;
        private readonly List<string> menuOptions;

        public ConsoleMenu(List<string> options, string title = "Menu")
        {
            this.title = title;
            menuOptions = options;
            ;
        }

        public int displayAndGetSelection()
        {
            int selection = 0;

            DisplayMenuTitle();
            DisplayMenuSeparator();
            DisplayMenuOptions();
            DisplayMenuUserChoice();

            selection = Validations.ValidateInt();

            Console.WriteLine($"Your option ({selection}) was sucessfully selected\n Loading...\n");

            return selection;

        }

        private void DisplayMenuTitle()
        {
            Console.WriteLine(title + "\n");
        }

        private void DisplayMenuSeparator()
        {
            Console.WriteLine("----------------------------\n");
        }

        private void DisplayMenuOptions()
        {
            for (var i = 0; i < menuOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1} : {menuOptions[i]}");
            }
        }

        private void DisplayMenuUserChoice()
        {
            Console.Write($"\nPlease choose one option between 1 and {menuOptions.Count} : ");
        }
    }
}
