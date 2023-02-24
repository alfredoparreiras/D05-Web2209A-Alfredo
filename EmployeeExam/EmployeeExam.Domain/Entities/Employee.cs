using Chevalier.Utility.ViewModels;
using EmployeeExam.Domain.Exceptions;

namespace EmployeeExam.Domain.Entities
{
    public class Employee : ViewModel
    {
        // TODO: Enforce encapsulation and business rules by:
        // Making property set accessors private, and/or
        // Manually defining set accessors to include validation (conditional validation)

        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; }
        public decimal HourlyWage { get; private set; }
        public decimal HoursWorked { get; private set; }
        public decimal HoursPaid { get; set; }
        public decimal PaymentReceived { get; set; }

        public string FullName
        {
            get
            {
                // TODO
                return FirstName + " " + LastName;
            }
        }

        public decimal HoursUnpaid
        {
            get
            {
                // TODO
                return (HourlyWage * HoursWorked) - HoursPaid;
            }
        }

        public decimal PaymentDue
        {
            get
            {
                // TODO
                return Math.Round(HourlyWage * HoursWorked);
                
               
            }
        }

        public Employee(int id, Employee other)
            : this(id, other.FirstName, other.LastName, other.DateOfBirth, other.JobTitle, other.HourlyWage, other.HoursWorked, other.HoursPaid, other.PaymentReceived)
        { }

        /// <exception cref="ArgumentNullException">If first name, last name, or job title is null.</exception>
        /// <exception cref="EmployeeException">If first name, last name, or job title is empty or whitespace.</exception>
        /// <exception cref="EmployeeException">If date of birth is not in the past.</exception>
        /// <exception cref="EmployeeException">If hourly wage is negative.</exception>
        public Employee(string firstName, string lastName, DateTime dateOfBirth, string jobTitle, decimal hourlyWage)
            : this(id: 0, firstName, lastName, dateOfBirth, jobTitle, hourlyWage, hoursWorked: 0, hoursPaid: 0, paymentReceived: 0)
        { }

        /// <exception cref="ArgumentNullException">If first name, last name, or job title is null.</exception>
        /// <exception cref="EmployeeException">If first name, last name, or job title is empty or whitespace.</exception>
        /// <exception cref="EmployeeException">If date of birth is not in the past.</exception>
        /// <exception cref="EmployeeException">If hourly wage, hours worked, hours paid, or payment received is negative.</exception>
        public Employee(int id, string firstName, string lastName, DateTime dateOfBirth, string jobTitle, decimal hourlyWage, decimal hoursWorked, decimal hoursPaid, decimal paymentReceived)
        {
            // TODO: Validate that nullable arguments are not null, and otherwise throw an ArgumentNullException
            if(firstName == null || lastName == null || jobTitle == null)
                throw new ArgumentNullException("First Name, Last Name or Job Title Can't be Null");


            // TODO: Validate that all arguments are valid, and otherwise throw an EmployeeException with a clear message
            // Rule: First name must not be empty or whitespace.
            if(string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName))
                throw new EmployeeException("First Name can't be Empty or Contain only Whitespaces");
            FirstName = firstName; 
            
            // Rule: Last name must not be empty or whitespace.
            if(string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName))
                throw new EmployeeException("Last Name can't be Empty or Contain only Whitespaces");
            LastName = lastName;

            // Rule: Job title must not be empty or whitespace.
            if(string.IsNullOrEmpty(jobTitle) || string.IsNullOrWhiteSpace(jobTitle))
                throw new EmployeeException("Job Title can't be Empty or Contain only Whitespaces");
            JobTitle = jobTitle;

            // Rule: Date of birth must be in the past.
            if (DateOfBirth.CompareTo(DateTime.UtcNow) > 0)
                throw new EmployeeException("Date of Birth must be in the past");
            DateOfBirth = dateOfBirth;

            // Rule: Hourly wage must not be negative.
            if (hourlyWage < 0)
                throw new EmployeeException("Hourly wage must not be negative");
            HourlyWage = hourlyWage;

            // Rule: Hours worked must not be negative.
            if (hoursWorked < 0)
                throw new EmployeeException("Hours Worked must not be negative");
            HoursWorked = hoursWorked;

            // Rule: Hours paid must not be negative.
            if (hoursPaid < 0)
                throw new EmployeeException("Hours Paid must not be negative");
            HoursPaid = hoursPaid;

            // Rule: Payment received must not be negative.
            if (paymentReceived < 0)
                throw new EmployeeException("Payment Received must not be negative");
            PaymentReceived = paymentReceived;

            // TODO: Initialize instance variables and properties
            Id = id;
        }

        /// <exception cref="EmployeeException">If additional hours worked is not positive.</exception>
        public void LogHours(decimal additionalHoursWorked)
        {
            // TODO: Validate that argument is valid, and otherwise throw an EmployeeException with a clear message
            // Rule: Additional hours worked must be positive.
            if (additionalHoursWorked < 0)
                throw new EmployeeException("Hours must be a positive value");

            // TODO: If and only if the argument is valid, update the total number of hours worked to reflect the additional hours worked
            HoursWorked += additionalHoursWorked;
            NotifyPropertyChanged(nameof(HoursWorked));
            NotifyPropertyChanged(nameof(PaymentDue));

        }

        /// <exception cref="EmployeeException">If raise percentage is not positive.</exception>
        public void GiveRaise(decimal raisePercentage)
        {
            // TODO: Validate that argument is valid, and otherwise throw an EmployeeException with a clear message
            // Rule: Raise percentage must be positive.
            if (raisePercentage < 0)
                throw new EmployeeException("Raise Percentage must be a positive value");

            // TODO: If and only if the argument is valid, calculate the raise amount and update the hourly wage to reflect the raise
            HourlyWage = HourlyWage + (HourlyWage * raisePercentage / 100);
            NotifyPropertyChanged(nameof(HourlyWage));
        }

        public void PayAmountDue()
        {
            // TODO: Pay the employee for all unpaid hours by updating the number of hours paid and the total amount of payment received
            HoursPaid = HoursWorked;
            PaymentReceived = PaymentDue;
            HoursWorked = 0;

            NotifyPropertyChanged(nameof(PaymentReceived));
            NotifyPropertyChanged(nameof(PaymentDue));
            NotifyPropertyChanged(nameof(HoursPaid));
        }
    }
}
