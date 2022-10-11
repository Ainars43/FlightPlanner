﻿using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Services.Validators
{
    public class AirportToCountryValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.To?.Country);
        }
    }
}