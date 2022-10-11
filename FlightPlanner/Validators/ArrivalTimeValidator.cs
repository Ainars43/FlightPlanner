﻿using System;

namespace FlightPlanner.Validators
{
    public class ArrivalTimeValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.ArrivalTime);
        }
    }
}
