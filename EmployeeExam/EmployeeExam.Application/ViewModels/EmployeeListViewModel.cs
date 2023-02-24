using System.Collections.ObjectModel;
using System.ComponentModel;
using Chevalier.Utility.Commands;
using Chevalier.Utility.ViewModels;
using EmployeeExam.Domain.Entities;
using EmployeeExam.Persistence.Repositories;

namespace EmployeeExam.Application.ViewModels
{
    public class EmployeeListViewModel : ViewModel, INotifyPropertyChanged
    {
        // TODO: Declare employees collection property
        public ObservableCollection<Employee> employees { get; }

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
                //NotifyPropertyChanged(nameof(SelectedEmployee));
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
        public EmployeeListViewModel()
        {
            // Initialize instance variables and properties
            // Load all employees from the database
            var repository = new EmployeeRepository();
            var employeesList = new List<Employee>();
            // Store the employees in the collection
            employees = new ObservableCollection<Employee>(employeesList);

            LogHoursCommand = new DelegateCommand(logHoursCommand);
        }

        private void logHoursCommand(object obj)
        {
            throw new NotImplementedException();
        }

        // TODO: Define command methods
    }
}
