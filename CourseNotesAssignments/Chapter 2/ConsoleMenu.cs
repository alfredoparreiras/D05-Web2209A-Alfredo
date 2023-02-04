using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProgram
{
    internal class ConsoleMenu
    {

        private readonly string title;
        private readonly string message;
        private readonly List<string> options;

        public ConsoleMenu (List<string> options)
        {
            this.options = options;
        }

        public int DisplayAndGetUserInput()
        {
            int selection = 0;
            do
            {
                DisplayTitle();
                DisplaySeparator();
                DisplayOptions();
                selection = ReadInt("You need to type a number");
            } while (selection != options.Count || selection > options.Count);

            DisplayMessage(selection);
            return selection;
        }

        private void DisplaySeparator()
        {
            Console.WriteLine("------------------\n");
        }

        private void DisplayTitle()
        {
            if(title == null)
                Console.WriteLine("Calculator Menu\n");
            else if(title.Length > 0)
                Console.WriteLine(title);
        }

        // Method to display menu's options
        private void DisplayOptions()
        {
            for(var i = 0; i < options.Count; i++)
            {
                Console.WriteLine($" {i+1} - {options[i]}.");
            }
            Console.Write("\nPlease select an option => ");
        }

        // Message to confirm the user input.
        private void DisplayMessage(int selection)
        {
            if(message == null)
                Console.WriteLine($"Option {selection} selected with sucess");
            else
                Console.WriteLine($"Option {selection}, {message}");

        }
        
        
        // Method to check if user's input is an Integer.
        private int ReadInt(string message)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                    return number;
                Console.WriteLine($"Error {input} is invalid => {message}");
            }
        }
    }
}
