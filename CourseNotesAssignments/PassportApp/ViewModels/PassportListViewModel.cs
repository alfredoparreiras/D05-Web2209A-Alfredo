using Chevalier.Utility.Commands;
using PassportApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PassportApp.ViewModels
{
    class PassportListViewModel
    {
        public ObservableCollection<Passport> Passports { get; }
        public Passport SelectedPassport { get; set; }
        public string DestinationCountry { get; set; }
        public DelegateCommand TravelCommand { get; } 
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

            TravelCommand = new DelegateCommand(Travel);

        }

        private void Travel(Object _)
        {
            if(SelectedPassport is not null || !String.IsNullOrWhiteSpace(DestinationCountry))
            {
                SelectedPassport.Travelling(DestinationCountry, DateTime.Now);
            }

        }
    }
}
