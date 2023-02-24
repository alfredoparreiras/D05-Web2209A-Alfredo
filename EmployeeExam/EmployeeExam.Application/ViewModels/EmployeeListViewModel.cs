using System.Collections.ObjectModel;
using System.ComponentModel;
using Chevalier.Utility.Commands;
using Chevalier.Utility.ViewModels;
using EmployeeExam.Domain.Entities;
using EmployeeExam.Persistence.Repositories;

namespace EmployeeExam.Application.ViewModels
{
    public delegate void ErrorHandler(string message);
    public class EmployeeListViewModel : ViewModel, INotifyPropertyChanged
    {

        public event ErrorHandler CommandFailed;
        // TODO: Declare employees collection property
        public ObservableCollection<Employee> Employees { get; }

        // TODO: Declare other data properties
        public Employee SelectedEmployee
        {
            get
            {
                return selectedEmployee;
            }
            set
            {
                selectedEmployee = value;
                NotifyPropertyChanged(nameof(SelectedEmployee));
                PayEmployeeCommand.NotifyCanExecuteChanged();
            }
        }

        public decimal HoursWorked
        {
            get
            {
                return hoursWorked;
            }
            set
            {
                hoursWorked = value;
            }

        }

        public decimal EmployeeRaise
        {
            get
            {
                return employeeRaise;
            }
            set
            {
                employeeRaise = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }

        public string JobTitle
        {
            get
            {
                return jobTitle;
            }
            set
            {
                jobTitle = value;
            }
        }

        public decimal HourlyWage
        {
            get
            {
                return hourlyWage;
            }
            set
            {
                hourlyWage = value;
            }
        }
        // TODO: Declare command properties
        public DelegateCommand LogHoursCommand { get; }
        public DelegateCommand EmployeeRaiseCommand { get; }
        public DelegateCommand PayEmployeeCommand { get; }
        public DelegateCommand RemoveEmployeeCommand { get; }
        public DelegateCommand AddEmployeeCommand { get; }


        // TODO: Declare any other required member variables, respecting encapsulation
        private Employee selectedEmployee;
        private decimal hoursWorked;
        private decimal employeeRaise;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string jobTitle;
        private decimal hourlyWage;
        private EmployeeRepository repository;
        private List<Employee> employeesList;
        public EmployeeListViewModel()
        {
            // Initialize instance variables and properties
            // Load all employees from the database
            repository = new EmployeeRepository();
            employeesList = repository.GetEmployees();
            // Store the employees in the collection
            Employees = new ObservableCollection<Employee>(employeesList);

            LogHoursCommand = new DelegateCommand(logHours);
            EmployeeRaiseCommand = new DelegateCommand(employeeRaiseC);
            PayEmployeeCommand = new DelegateCommand(payEmployee, canPayEmployee);
            RemoveEmployeeCommand = new DelegateCommand(removeEmployee);
            AddEmployeeCommand = new DelegateCommand(addEmployee);
        }


        // TODO: Define command methods
        private void removeEmployee(object _)
        {
            if(SelectedEmployee != null)
            {
                repository.RemoveEmployee(SelectedEmployee);
                Employees.Remove(SelectedEmployee);
            }
        }

        private void addEmployee(object _)
        {
            try
            {
                var employee = new Employee(FirstName, LastName, DateOfBirth, JobTitle, HourlyWage);
                Employee correct = repository.AddEmployee(employee);
                Employees.Add(correct);
            }
            catch(Exception e)
            {
                CommandFailed?.Invoke(e.Message);
            }
        }

        private void employeeRaiseC(object _)
        {
            if(SelectedEmployee != null)
                SelectedEmployee.GiveRaise(employeeRaise);
        }

        private void payEmployee(object _)
        {
            if(SelectedEmployee != null)
                SelectedEmployee.PayAmountDue();
        }
        private bool canPayEmployee(object _)
        {
            return SelectedEmployee != null;
        }

        private void logHours(object _)
        {
            if (SelectedEmployee != null)
            {
                SelectedEmployee.LogHours(hoursWorked);
                hoursWorked = 0;
                NotifyPropertyChanged(nameof(hoursWorked));
            }

         
            
           
        }
    }
}
