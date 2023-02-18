using PassportApp.Models;
using PassportApp.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PassportApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            PassportRepository repository = new PassportRepository();
            //Passport passport = repository.GetPassport(100); //Work
            //List<Passport> result = repository.GetPassports(); Work
            //List<Passport> result = repository.GetPassportsByName("Alfredo", "Parreira"); Work
            //List<Passport> result = repository.GetPassportsByDate(new DateTime(1990, 09, 01), new DateTime(2000, 09, 01)); Work
            //repository.AddPassport(new Passport(10, new Passport("Jared", "Chevalier", new DateTime(1989, 10, 10), "Canada"))); Work
            //repository.RemovePassport(103);
            //repository.RemovePassport(104);

            //Passport sabrina = new Passport(100, "Sabrina", "Sato", new DateTime(1983, 09, 19), "Brazil", DateTime.Now, DateTime.Now);
            //repository.UpdatePassport(sabrina); Work
    
        }
    }
}
