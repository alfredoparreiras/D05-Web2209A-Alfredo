namespace EmployeeProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var alfredo = new Employee(3123, "Alfredo", 1.74, 2000.50m);
            Console.WriteLine($"Employee ID => {alfredo.Id}");
            Console.WriteLine($"Employee name => {alfredo.Name}");
            Console.WriteLine($"Employee Height => {alfredo.Height}");
            Console.WriteLine("Employee Height in Feet => {0:0.00}",alfredo.HeightInFeet);
            Console.WriteLine($"Employee Income => {alfredo.Income}");
        }
    }
}