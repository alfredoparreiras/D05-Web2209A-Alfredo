using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport
{
    internal class Passport
    {
        
        // Calculated Properties 
        public string GetFullName => string.Concat(FirstName," ",LastName);
        public int GetAge => DateTime.Now.Year - dateOfBirth.Year;

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
        
        // Properties 
        private readonly string id;
        private string FirstName { set; get; }
        private string LastName { set; get; }
        private DateTime dateOfBirth;
        private readonly string countryOfResidence;
        private List<TravelEvent> travelHistory;
    
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
            if (Validations.ValidateDateTime(dateOfBirth))
                this.dateOfBirth = dateOfBirth;

            //Check if country is a valid input
            if(Validations.ValidateName(countryOfResidence))
                this.countryOfResidence = countryOfResidence;   
            
            //Creating Travel Event 
            var initialTravel = new TravelEvent(id, this.countryOfResidence, DateTime.UtcNow);
            
            // Adding Travel Event 
            travelHistory = new List<TravelEvent>();
            travelHistory.Add(initialTravel);
            
        }
        public override string ToString()
        {
            return $"Passport ID : {id}\n" +
                   $"Name : {FirstName + " " +  LastName}\n" +
                   $"Country Of Residence: {countryOfResidence}\n";
        }

        public void Travelling(string country, DateTime timeOfEntry)
        {
            var newTravel = new TravelEvent(this.id, country, timeOfEntry);
            travelHistory.Add(newTravel);
        }
    }
}
