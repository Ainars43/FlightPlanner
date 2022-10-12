using System;
using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Requests;

namespace FlightPlanner.Services.Validators
{
    public class CorrectTimeValidator : IValidator
    {
        public bool Validate(FlightRequest request)
        {
            var departureTime = DateTime.Parse((string)request.DepartureTime);
            var arrivalTime = DateTime.Parse((string)request.ArrivalTime);

            return arrivalTime > departureTime; 
        }
    }
}
