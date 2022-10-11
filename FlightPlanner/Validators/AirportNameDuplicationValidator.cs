using System;

namespace FlightPlanner.Validators
{
    public class AirportNameDuplicationValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return !string.Equals(flight.From.AirportCode.Trim(), flight.To.AirportCode.Trim(), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
