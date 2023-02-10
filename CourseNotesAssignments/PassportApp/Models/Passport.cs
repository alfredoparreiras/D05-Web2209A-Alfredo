using System;
using System.Collections.Generic;

namespace Passport.Models
{
    internal class Passport
    {
        // Calculated Properties 
        public string GetFullName => string.Concat(FirstName," ",LastName);
        //TODO: Create more accurate method. 
        public int GetAge
        {
            get
            {
                TimeSpan age = (DateTime.Now - dateOfBirth) / 366;
                return age.Days;
            }
        }
        public string CurrentLocation
        {
            get
            {
                return travelHistory[^1].ToString();
                //return travelHistory[travelHistory.Count - 1].ToString();
            }
        }
        public bool IsTravelling
        {
            get
            {
                if (travelHistory[^1].Country != countryOfResidence)
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
        private string FirstName { set; get; }
        private string LastName { set; get; }
        
        // Data Fields 
        private string id; 
        private DateTime dateOfBirth;
        public DateTime PassportCreation;
        private readonly string countryOfResidence;
        private readonly List<TravelEvent> travelHistory;
    
        public Passport(string firstName, string lastName, DateTime dateOfBirth, string countryOfResidence, GeneratedID generatedID)
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
                this.dateOfBirth = dateOfBirth;

            //Check if country is a valid input
            if(Validations.ValidateName(countryOfResidence))
                this.countryOfResidence = countryOfResidence;   
            
            //Creating Travel Event 
            var initialTravel = new TravelEvent(Id, this.countryOfResidence, DateTime.UtcNow);
            
            // Adding Travel Event 
            travelHistory = new List<TravelEvent>();
            travelHistory.Add(initialTravel);
            PassportCreation = initialTravel.TimeOfEntry;

        }
        public override string ToString()
        {
            return $"Passport ID : {Id}\n" +
                   $"Name : {FirstName + " " + LastName}\n" +
                   $"Country Of Residence: {countryOfResidence}\n" +
                   $"Current Country: {travelHistory[^1].Country}\n";
        }
        public void Travelling(string country, DateTime timeOfEntry)
        {
            var newTravel = new TravelEvent(this.Id, country, timeOfEntry);
            travelHistory.Add(newTravel);
        }
    }
}
