using FlightPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Core.Models;
using Microsoft.EntityFrameworkCore;
using FlightPlanner.Core.Requests;
using FlightPlanner.Core.Services;
using MoreLinq;

namespace FlightPlanner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(IFlightPlannerDbContext context
        ) : base(context)
        {
        }

        public Flight GetFlight(int id)
        {
            return Query().Include(f => f.From).Include(f => f.To).SingleOrDefault(f => f.Id == id);
        }

        public bool FlightAlreadyExists(FlightRequest request)
        {
            return Query().Any(f => f.DepartureTime == request.DepartureTime 
            && f.ArrivalTime == request.ArrivalTime 
            && f.Carrier == request.Carrier 
            && string.Equals(f.From.AirportCode.Trim().ToLower(),
                request.From.Airport.Trim().ToLower()) 
            && string.Equals(f.To.AirportCode.Trim().ToLower(),
                request.To.Airport.Trim().ToLower()));
        }

        public bool IsValidFlightSearchRequest(FlightSearchRequest request)
        {
            if (string.IsNullOrEmpty(request.From) || string.IsNullOrEmpty(request.To))
            {
                return false;
            }

            return request.From.Trim().ToLower() != request.To.Trim().ToLower();
        }

        public List<Flight> SearchFlights(FlightSearchRequest request)
        {
            var result = Query().Include(f => f.From).Include(f => f.To).ToList().Where(f => f.From.AirportCode == request.From && f.To.AirportCode == request.To && DateTime.Parse((string)f.DepartureTime).Date == DateTime.Parse((string)request.DepartureDate)).ToList();

            return result.DistinctBy(m => new { m.From.AirportCode, m.DepartureTime }).ToList();
        }

        public void DeleteFlightById(int id)
        {
            var flight = GetFlight(id);
            if (flight != null)
            {
                Delete(flight);
            }
        }
    }
}
