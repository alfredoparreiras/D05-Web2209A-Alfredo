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
        private int PassportID { get; }
        private string Country { get; }
        private DateTime TimeOfEntry { get; }

        //Calculated Properties
        public TimeSpan GetTimeSpan => DateTime.UtcNow - TimeOfEntry; 


        public TravelEvent(int passportID, string country, DateTime timeOfEntry)
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
