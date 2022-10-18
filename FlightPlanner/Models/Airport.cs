using System;
using System.Text.Json.Serialization;

namespace FlightPlanner.Models
{
    public class Airport
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [JsonPropertyName("airport")]
        public string AirportCode { get; set; }

        public override bool Equals(object o)
        {
            return o is Airport airport
                   && string.Equals(airport.AirportCode.Trim(), AirportCode.Trim(),
                       StringComparison.CurrentCultureIgnoreCase);
        }

        public bool HasIncorrectValues()
        {
            return string.IsNullOrEmpty(Country) 
                   || string.IsNullOrEmpty(City)
                   || string.IsNullOrEmpty(AirportCode);
        }
    }
}
