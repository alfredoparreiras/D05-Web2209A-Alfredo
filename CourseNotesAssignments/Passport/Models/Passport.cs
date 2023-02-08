namespace Passport.Models
{
    internal class Passport
    {
        // Calculated Properties 
        public string GetFullName => string.Concat(FirstName," ",LastName);
        //TODO: Create more accurate method. 
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

        public string Id
        {
            get
            {
                return id;
            }
        }
        
        // Properties 
        private string id; 
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
            var initialTravel = new TravelEvent(Id, this.countryOfResidence, DateTime.UtcNow);
            
            // Adding Travel Event 
            travelHistory = new List<TravelEvent>();
            travelHistory.Add(initialTravel);
            
        }
        public override string ToString()
        {
            return $"Passport ID : {Id}\n" +
                   $"Name : {FirstName + " " + LastName}\n" +
                   $"Country Of Residence: {countryOfResidence}\n" +
                   $"Current Country: {travelHistory[travelHistory.Count - 1].Country}\n";
        }

        public void Travelling(string country, DateTime timeOfEntry)
        {
            var newTravel = new TravelEvent(this.Id, country, timeOfEntry);
            travelHistory.Add(newTravel);
        }
    }
}
