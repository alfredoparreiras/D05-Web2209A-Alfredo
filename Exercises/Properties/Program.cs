namespace Properties
{
    internal class Program
    {
        private static void Main()
        {
            Employee employee = new Employee(id: 101, name: "Anna", height: 1.5, income: 999.99m);

            int id = employee.Id;
            Console.WriteLine($"Employee id = {id}");

            string name = employee.Name;
            Console.WriteLine($"Employee name = {name}");

            int nameLength = employee.NameLength;
            Console.WriteLine($"Employee name length = {nameLength}");

            double height = employee.Height;
            Console.WriteLine($"Employee height = {height}");

            double heightInFeet = employee.HeightInFeet;
            Console.WriteLine($"Employee height in feet = {heightInFeet}");

            decimal income = employee.Income;
            Console.WriteLine($"Employee income = {income}");

            //employee.Id = 123; // Compiler error because Id property is read-only

            Console.WriteLine("Attempting to set employee name to Catherine...");
            employee.Name = "Catherine";
            Console.WriteLine($"Employee name = {employee.Name}");
            Console.WriteLine($"Employee name length = {employee.NameLength}");

            //employee.NameLength = 123; // Compiler error because NameLength property is read-only

            Console.WriteLine("Attempting to set employee height to 1.9...");
            employee.Height = 1.9; // Successfully changes height because 1.9 passes validation
            Console.WriteLine($"Employee height = {employee.Height}");
            Console.WriteLine($"Employee height in feet = {employee.HeightInFeet}");

            Console.WriteLine("Attempting to set employee height to -5...");
            employee.Height = -5; // Fails to change height because -5 fails validation
            Console.WriteLine($"Employee height = {employee.Height}");
            Console.WriteLine($"Employee height in feet = {employee.HeightInFeet}");

            //employee.HeightInFeet = 5.5; // Compiler error because HeightInFeet property is read-only

            //employee.Income = 1500; // Compiler error because Income property has private set accessor
        }
    }
}