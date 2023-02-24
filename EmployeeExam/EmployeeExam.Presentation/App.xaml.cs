using EmployeeExam.Domain.Entities;
using EmployeeExam.Persistence.Repositories;
using System;
using System.Diagnostics;
using System.Windows;

namespace EmployeeExam.Presentation
{
    public partial class App : System.Windows.Application
    {
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    var repository = new EmployeeRepository();
        //    var employeeTest = repository.GetEmployee(10014);
        //    var listOfEmployees = repository.GetEmployees();
        //    var alfredo = new Employee("Alfredo", "Silva", new DateTime(1990, 09, 19), "BackEnd Developer", 50m);
        //    alfredo = repository.GetEmployee(10014);

        //    alfredo.JobTitle = "FrontEnd";
        //    repository.UpdateEmployee(alfredo);
        //}
    }
}
