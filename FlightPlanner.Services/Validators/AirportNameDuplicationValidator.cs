using System;
using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Requests;

namespace FlightPlanner.Services.Validators
{
    public class AirportNameDuplicationValidator : IValidator
    {
        public bool Validate(FlightRequest request)
        {
            return !string.Equals(request.From.Airport.Trim(), request.To.Airport.Trim(), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
