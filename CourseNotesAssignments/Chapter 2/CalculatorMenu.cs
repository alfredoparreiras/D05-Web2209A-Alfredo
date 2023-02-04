
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProgram
{
    internal class CalculatorMenu
    {
        // Private Fields
        private Calculator Calculator { get; set; }
        private ConsoleMenu ConsoleMenu;
        private List<string> options;
      

        // Constructors
        public CalculatorMenu()
        {
            Calculator = new Calculator();
           
            options = new List<string>();
            ConsoleMenu = new ConsoleMenu(options);

            // Adding menu options 
            options.Add("Add Numbers");
            options.Add("Display Ascending Numbers");
            options.Add("Check Divisibility");
            options.Add("Check Even or Odd");
            options.Add("Find Minimum Number");
            options.Add("Sort Numbers");
            options.Add("Find Most Common Character");
            options.Add("Exit");
        }

        //Methods
        public void start()
        {
            int selection = ConsoleMenu.DisplayAndGetUserInput();

            switch(selection)
            {
                case 1:
                    Console.WriteLine("Please insert two values");
                    double x = Validations.ReadDouble();
                    double y = Validations.ReadDouble();
                    Console.WriteLine(Calculator.Sum(x, y));
                    break;
                case 2:
                    Console.WriteLine("Please insert one positive value");
                    int maximum = Validations.ReadInt();
                    for(var i = 0; i <= maximum; i++)
                    {
                        Console.WriteLine($"{i} -- ");
                    }
                    break;
                case 3:
                    Console.WriteLine("Please insert two values");
                    int xx = Validations.ReadInt();
                    int yy = Validations.ReadInt();
                    if(Calculator.IsDivisibleBy(xx,yy))
                        Console.WriteLine($"{xx} is divisible by {yy}");
                    break;


            }


        }



    }
}
