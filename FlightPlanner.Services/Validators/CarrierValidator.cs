﻿namespace FlightPlanner.Services.Validators
{
    public class CarrierValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.Carrier);
        }
    }
}