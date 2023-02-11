using System;
using System.Collections.Generic;

namespace PassportApp.Models
{
    internal class Passport
    {
        // Calculated Properties 
        public string GetFullName => string.Concat(FirstName," ",LastName);
        public int GetAge
        {
            get
            {
                TimeSpan age = (DateTime.Now - DateOfBirth) / 366;
                return age.Days;
            }
        }
        public string CurrentLocation
        {
            get
            {
                return travelHistory[^1].Country;
                //return travelHistory[travelHistory.Count - 1].ToString();
            }
        }
        public bool IsTravelling
        {
            get
            {
                if (travelHistory[^1].Country != CountryOfResidence)
                    return true;
                return false;
            }
        }
        //Properties
        public string Id
        {
            get
            {
                return id;
            }
        }
        
        // Automatic Properties 
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string CountryOfResidence { get; }
        public DateTime DateOfBirth { get; }
        
        // Data Fields 
        private string id; 
        public DateTime PassportCreation;
        private readonly List<TravelEvent> travelHistory;
    
        public Passport(string firstName, string lastName, DateTime dateOfBirth, string countryOfResidence)
        {
            id = GeneratedID.GenerateId();

            //Check if first name can be used as a valid name
            if(Validations.ValidateName(firstName))
                this.FirstName = firstName;

            //Check if last name can be used as a valid name
            if(Validations.ValidateName(lastName))
                this.LastName = lastName;

            //Check if date of birthe can be used as a valid date;
            if (Validations.ValidateDateOfBirth(dateOfBirth))
                this.DateOfBirth = dateOfBirth;

            //Check if country is a valid input
            if(Validations.ValidateName(countryOfResidence))
                this.CountryOfResidence = countryOfResidence;   
            
            //Creating Travel Event 
            var initialTravel = new TravelEvent(Id, this.CountryOfResidence, DateTime.UtcNow);
            
            // Adding Travel Event 
            travelHistory = new List<TravelEvent>();
            travelHistory.Add(initialTravel);
            PassportCreation = initialTravel.TimeOfEntry;

        }
        public override string ToString()
        {
            return $"Passport ID : {Id}\n" +
                   $"Name : {FirstName + " " + LastName}\n" +
                   $"Country Of Residence: {CountryOfResidence}\n" +
                   $"Current Country: {travelHistory[^1].Country}\n";
        }
        public void Travelling(string country, DateTime timeOfEntry)
        {
            var newTravel = new TravelEvent(this.Id, country, timeOfEntry);
            travelHistory.Add(newTravel);
        }
    }
}
