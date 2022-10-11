using System;

namespace FlightPlanner.Validators
{
    public class CorrectTimeValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            var departureTime = DateTime.Parse(flight.DepartureTime);
            var arrivalTime = DateTime.Parse(flight.ArrivalTime);

            return arrivalTime > departureTime; 
        }
    }
}
