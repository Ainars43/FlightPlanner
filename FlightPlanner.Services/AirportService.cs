using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Core;
using FlightPlanner.Core.Models;
using FlightPlanner.Data;

namespace FlightPlanner.Services
{
    public class AirportService : EntityService<Airport>, IAirportService
    {
        public AirportService(IFlightPlannerDbContext context) : base(context)
        {
        }

        public List<Airport> SearchAirports(string search)
        {
            return Query().Where(f =>
                f.AirportCode.ToUpper().Contains(search.Trim().ToUpper()) ||
                f.City.ToUpper().Contains(search.Trim().ToUpper()) ||
                f.Country.ToUpper().Contains(search.Trim().ToUpper())).ToList();
        }
    }
}