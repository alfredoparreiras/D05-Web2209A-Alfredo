using System;

namespace Passport.Models
{
    internal class TravelEvent
    {   
        //Automatic Properties 
        private string PassportId { get; }
        public string Country { get; }
        public DateTime TimeOfEntry { get; }
        
        //Calculated Properties
        public TimeSpan GetTimeSpan => DateTime.UtcNow - TimeOfEntry;
        public TravelEvent(string passportId, string country, DateTime timeOfEntry)
        {
            PassportId = passportId;
            Country = country;
            TimeOfEntry = timeOfEntry;
        }
        public override string ToString()
        {
            return $"Passport ID : {PassportId}\n" +
                   $"Country : {Country}\n" +
                   $"Time Of Entry : {TimeOfEntry}\n";
        }
    }
}
