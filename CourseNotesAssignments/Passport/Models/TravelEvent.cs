using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport
{
    internal class TravelEvent
    {   
        //Automatic Properties 
        private string PassportID { get; }
        public string Country { get; }
        private DateTime TimeOfEntry { get; }

        //Calculated Properties
        public TimeSpan GetTimeSpan => DateTime.UtcNow - TimeOfEntry; 


        public TravelEvent(string passportID, string country, DateTime timeOfEntry)
        {
            PassportID = passportID;
            Country = country;
            TimeOfEntry = timeOfEntry;
        }

        
        public override string ToString()
        {
            return $"Passport ID : {PassportID}\n" +
                   $"Country : {Country}\n" +
                   $"Time Of Entry : {TimeOfEntry}\n";
        }


    }
}
