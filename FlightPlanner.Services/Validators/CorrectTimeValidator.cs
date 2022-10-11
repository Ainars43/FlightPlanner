using System;

namespace FlightPlanner.Services.Validators
{
    public class CorrectTimeValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            var departureTime = DateTime.Parse((string)flight.DepartureTime);
            var arrivalTime = DateTime.Parse((string)flight.ArrivalTime);

            return arrivalTime > departureTime; 
        }
    }
}
