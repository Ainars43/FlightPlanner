using FlightPlanner.Core;
using FlightPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Services
{
    public class FlightStorage : IFlightStorage
    {
        //private static List<Flight> _flights = new();
        protected readonly IFlightPlannerDbContext _context;

        public FlightStorage(IFlightPlannerDbContext context)
        {
            _context = context;
        }

        public Flight GetFlight(int id)
        {
            return _context.Flights.FirstOrDefault(f => f.Id == id);
        }

        public bool FlightAlreadyExists(Flight flight)
        {
            return _context.Flights.Any(f => f.DepartureTime == flight.DepartureTime 
            && f.ArrivalTime == flight.ArrivalTime 
            && f.Carrier == flight.Carrier 
            && string.Equals(f.From.AirportCode.Trim().ToLower(), 
                flight.From.AirportCode.Trim().ToLower()) 
            && string.Equals(f.To.AirportCode.Trim().ToLower(), 
                flight.To.AirportCode.Trim().ToLower()));
        }

        public Airport[] FindAirports(string keyword)
        {
            var airportList = new List<Airport>();
            var fixedKeyword = keyword.ToLower().Trim();

            foreach (var f in _context.Flights)
            {
                if (f.To.Country.ToLower().Contains(fixedKeyword) || 
                    f.To.City.ToLower().Contains(fixedKeyword) || 
                    f.To.AirportCode.ToLower().Contains(fixedKeyword))
                {
                    airportList.Add(f.To);
                }

                if (f.From.Country.ToLower().Contains(fixedKeyword) ||
                    f.From.City.ToLower().Contains(fixedKeyword) ||
                    f.From.AirportCode.ToLower().Contains(fixedKeyword))
                {
                    airportList.Add(f.From);
                }
            }

            return airportList.ToArray();
        }

        public bool IsValidFlightSearchRequest(FlightSearchRequest request)
        {
            return request.From == null || request.To == null ||
                   request.DepartureDate == null || request.From == request.To;
        }

        public List<Flight> SearchFlights(FlightSearchRequest request)
        {
            return _context.Flights.Where(f => f.From.AirportCode == request.From && f.To.AirportCode == request.To && DateTime.Parse((string)f.DepartureTime).Date == DateTime.Parse((string)request.DepartureDate)).ToList();
        }
    }
}
