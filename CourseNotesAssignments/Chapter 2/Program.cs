using System.Collections;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CalculatorProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            var calculatorMenu = new CalculatorMenu();

            calculatorMenu.start();
         

            double[] doubleArray = { 11, 13, 15, 11.1, 12.9, 10.9, 50 };
            //Console.WriteLine(calculator.GetMinimum(doubleArray));
            //calculator.GetMostCommonCharacter("Banana");


        }

  

    }


}