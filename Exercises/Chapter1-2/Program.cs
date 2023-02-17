namespace Chapter1_2
{
    internal class Program
    {
        private static void Main()
        {
            Company company = ReadCompany();

            Console.WriteLine("Successfully read company:");
            Console.WriteLine(company);
        }

        private static Company ReadCompany()
        {
            Console.WriteLine("Enter company name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter company address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter company phone number:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter company fax number:");
            string faxNumber = Console.ReadLine();
            Console.WriteLine("Enter company website URL:");
            string websiteUrl = Console.ReadLine();

            Manager manager = ReadManager();

            return new Company(name, address, phoneNumber, faxNumber, websiteUrl, manager);
        }

        private static Manager ReadManager()
        {
            Console.WriteLine("Enter manager first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter manager last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter manager phone number:");
            string phoneNumber = Console.ReadLine();

            return new Manager(firstName, lastName, phoneNumber);
        }
    }
}