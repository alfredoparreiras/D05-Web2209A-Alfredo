
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            // Creating variable to store user's input.
            int selection = 0; 

            //Displaying the calculator menu
            do
            {
                selection = ConsoleMenu.DisplayAndGetUserInput();
                switch (selection)
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
                        for (var i = 0; i <= maximum; i++)
                        {
                            Console.WriteLine(i);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Please insert two values");
                        int xx = Validations.ReadInt();
                        int yy = Validations.ReadInt();

                        if (Calculator.IsDivisibleBy(xx, yy))
                            Console.WriteLine($"{xx} is divisible by {yy}\n");
                        else
                            Console.WriteLine($"{xx} isn't divisible by {yy}\n");


                        break;
                    case 4:
                        Console.WriteLine("Please insert a value");

                        int xxx = Validations.ReadInt();

                        if (Calculator.IsEven(xxx))
                            Console.WriteLine($"{xxx} is an even number\n");
                        else
                            Console.WriteLine($"{xxx} is an odd number\n");

                        break;
                    case 5:

                        double[] doubleArray = CreatingAndInsertingDoubleArray();

                        Console.WriteLine($"The minimum value is {Calculator.GetMinimum(doubleArray)}.");

                        break;
                    case 6:
                        double[] SecondDoubleArray = CreatingAndInsertingDoubleArray();
                        Console.WriteLine("The sorted values are : \n");
                        Calculator.SortArray(SecondDoubleArray);
                        break;

                    case 7:
                        Console.Write("Please insert an input : ");
                        string userInput = Console.ReadLine();
                        Console.WriteLine($"The most common character is {Calculator.GetMostCommonChaacter(userInput)}.");
                        break;
                }
            } while (selection != 8);


        }

        private static double[] CreatingAndInsertingDoubleArray()
        {
            Console.WriteLine("Enter how many numbers do you want to insert : ");

            int arrayLength = Validations.ReadInt();

            double[] doubleArray = new double[arrayLength];

            Console.WriteLine("Enter the numbers\n");

            for (var i = 0; i < arrayLength; i++)
            {
                doubleArray[i] = Validations.ReadDouble();
            }

            return doubleArray;
        }


    }
}
