using System.Collections.Generic;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Core
{
    public interface IAirportService : IEntityService<Airport>
    {
        List<Airport> SearchAirports(string search);
    }
}