using System;
using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Requests;

namespace FlightPlanner.Services.Validators
{
    public class TimeValidator : IValidator
    {
        public bool Validate(FlightRequest request)
        {
            if (string.IsNullOrEmpty(request.DepartureTime) || string.IsNullOrEmpty(request.ArrivalTime))
            {
                return false;
            }

            var departureTime = DateTime.Parse((string)request.DepartureTime);
            var arrivalTime = DateTime.Parse((string)request.ArrivalTime);

            return arrivalTime > departureTime; 
        }
    }
}
