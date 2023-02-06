using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport
{
    internal class Passport
    {
        private readonly string Id;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private readonly string countryOfResidence;

        private List<TravelEvent> travelHistory;

        public Passport(string firstName, string lastName, DateTime dateOfBirth, string countryOfResidence)
        {
            Id = GeneratedID.GenerateId();

            //Check if first name can be used as a valid name
            if(Validations.ValidateName(firstName))
                this.firstName = firstName;

            //Check if last name can be used as a valid name
            if(Validations.ValidateName(lastName))
                this.lastName = lastName;

            //Check if date of birthe can be used as a valid date;
            if (Validations.ValidateDateTime(dateOfBirth))
                this.dateOfBirth = dateOfBirth;

            //Check if country is a valid input
            if(Validations.ValidateName(countryOfResidence))
                this.countryOfResidence = countryOfResidence;   

        }
    }
}
