﻿namespace FlightPlanner.Core.Requests
{
    public class FlightSearchRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string DepartureDate { get; set; }
    }
}
