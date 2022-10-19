using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
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
            search = search.Trim().ToUpper();
            return Query().Where(f =>
                f.AirportCode.ToUpper().Contains(search) ||
                f.City.ToUpper().Contains(search) ||
                f.Country.ToUpper().Contains(search)).ToList();
        }
    }
}