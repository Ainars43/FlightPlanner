﻿namespace FlightPlanner.Validators
{
    public class AddFlightRequestValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return flight != null;
        }
    }
}