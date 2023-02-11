using Chevalier.Utility.Commands;
using Chevalier.Utility.ViewModels;
using PassportApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PassportApp.ViewModels
{
    class PassportListViewModel : ViewModel
    {
        public ObservableCollection<Passport> Passports { get; }
        // Add Travel Section
        public Passport SelectedPassport
        {
            get
            {
                return selectedPassport;
            }
            set
            {
                selectedPassport = value;
                TravelCommand.NotifyCanExecuteChanged();
            }
        }
        public string DestinationCountry 
        {
            get
            {
                return destinationCountry; 
            }
            set
            {
                destinationCountry = value;
                TravelCommand.NotifyCanExecuteChanged();

            }
        }
        public DelegateCommand TravelCommand { get; }

        // Add Passport Section
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                AddPassportCommand.NotifyCanExecuteChanged();
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
                AddPassportCommand.NotifyCanExecuteChanged();
            }
        }

        public DateTime? DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
                AddPassportCommand.NotifyCanExecuteChanged();
            }
        }

        public string ResidenceCountry
        {
            get
            {
                return residenceCountry;
            }
            set
            {
                residenceCountry = value;
                AddPassportCommand.NotifyCanExecuteChanged();
            }
        }
        public DelegateCommand AddPassportCommand { get; }


    
        //Instance Fields
        private string destinationCountry;
        private Passport selectedPassport;
        private string firstName;
        private string lastName;
        private DateTime? dateOfBirth;
        private string residenceCountry;


        public PassportListViewModel()
        {
            Passports = new ObservableCollection<Passport>();

            var passport = new Passport("Alfredo", "Silva", new DateTime(1990, 09, 19), "Brazil");
            Passports.Add(passport);
            var passport2 = new Models.Passport("Jared", "Chevalier", new DateTime(1989, 10, 29), "Canada");
            Passports.Add(passport2);
            var passport3 = new Models.Passport("Gabriela", "Franco", new DateTime(1993, 01, 18), "Colômbia");
            Passports.Add(passport3);
            var passport4 = new Models.Passport("Danials", "Behzad", new DateTime(2001, 04, 15), "Iran");
            Passports.Add(passport4);

            TravelCommand = new DelegateCommand(Travel,CanTravel);
            AddPassportCommand = new DelegateCommand(AddPassport, CanAddPassport);

        }

        /// <summary>
        /// Method responsible to call travel method in passport. 
        /// </summary>
        /// <param name="_"></param>
        private void Travel(object _)
        {
            SelectedPassport.Travelling(DestinationCountry, DateTime.Now);

            //Clear Fiel 
            DestinationCountry = string.Empty;

            //Updating the View
            NotifyPropertyChanged(nameof(DestinationCountry)); 
        }
        private bool CanTravel(object _)
        {
            return SelectedPassport is not null && !string.IsNullOrWhiteSpace(DestinationCountry);
        }

        // Add Passport Section 
        private void AddPassport(object _)
        {
            var newPassport = new Passport(FirstName, LastName, DateOfBirth.Value, residenceCountry);

            // Adding passport to the collection
            Passports.Add(newPassport);

            // Cleaning Entry Fields;
            FirstName = string.Empty;
            NotifyPropertyChanged(nameof(FirstName));
            LastName = string.Empty;
            NotifyPropertyChanged(nameof(LastName));
            ResidenceCountry = string.Empty;
            NotifyPropertyChanged(nameof(ResidenceCountry));
            DateOfBirth = DateTime.Today;
            NotifyPropertyChanged(nameof(DateOfBirth));
        }
        private bool CanAddPassport(object _) 
        {
            return !string.IsNullOrWhiteSpace(FirstName)
                && !string.IsNullOrWhiteSpace(LastName)
                && !string.IsNullOrWhiteSpace(ResidenceCountry)
                && DateOfBirth.HasValue;
        }
    }
}
