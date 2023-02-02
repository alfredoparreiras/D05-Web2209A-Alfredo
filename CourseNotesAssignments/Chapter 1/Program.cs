using System.Xml;

namespace Chapter_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Numbers();

        }

        private static void Numbers()
        {
            Console.WriteLine("Enter a number : ");
            int number = Convert.ToInt32(Console.ReadLine());

            int result = 0;

            for (var i = number; i > 0; i--)
            {
                result += i;
            }

            Console.WriteLine(result);
        }

        private static void Company()
        {
            Console.WriteLine("Enter the company name: ");
            string companyName = Console.ReadLine();

            Console.WriteLine("Enter the company address: ");
            string companyAddress = Console.ReadLine();

            Console.WriteLine("Enter the company phone Number: ");
            string companyPhoneNumber = Console.ReadLine();

            Console.WriteLine("Enter the company Fax Number: ");
            string companyFaxNumber = Console.ReadLine();

            Console.WriteLine("Enter the company website: ");
            string companyWebsite = Console.ReadLine();

            Console.WriteLine("Enter the manager's name: ");
            string managerName = Console.ReadLine();

            Console.WriteLine("Enter the manager's surname: ");
            string managerSurname = Console.ReadLine();

            Console.WriteLine("Enter the manager phone Number: ");
            string managerPhoneNumber = Console.ReadLine();

            Console.WriteLine($"This company is called {companyName}, is located at {companyAddress}, its phone number and fax number are {companyPhoneNumber} and {companyFaxNumber}. You can access its information at {companyWebsite}. Actually the manager is {managerName} {managerSurname}, and can be contact by phone {managerPhoneNumber}.");
        }

        private static void Circle()
        {
            Console.Write("Please insert the radius: ");
            int radius = 0;
            radius = Convert.ToInt32(Console.ReadLine());

            // Calculating Perimeter and Area

                double area = Math.Round(Math.PI * Math.Pow(radius, 2));
                double perimeter = Math.Round((2 * Math.PI) * radius);

                // Printing Values 

                Console.WriteLine($"This circle has {area} of Area and {perimeter} of Perimeter.");
            }
    }
}