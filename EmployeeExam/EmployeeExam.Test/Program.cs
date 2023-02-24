

using EmployeeExam.Domain.Entities;
using EmployeeExam.Persistence.Repositories;

namespace EmployeeExam.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var Alfredo = new Employee("Alfredo", "Silva", new System.DateTime(1990, 09, 19), "BackEnd Developer", 40m);
            ////Console.WriteLine(Alfredo.HourlyWage);
            //Alfredo.GiveRaise(0.5m);
            ////Console.WriteLine(Alfredo.HourlyWage);
            //Console.WriteLine(Alfredo.PaymentDue);
            //Alfredo.LogHours(40m);
            //Console.WriteLine(Alfredo.PaymentDue);

            var repository = new EmployeeRepository();
            var employeeTest = repository.GetEmployee(10001);
            Console.WriteLine(employeeTest.FirstName);


        }
    }
}