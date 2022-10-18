using System.Collections.Generic;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Requests;

namespace FlightPlanner.Core
{
    public interface IFlightService : IEntityService<Flight>
    {
        Flight GetFlight(int id);
        bool FlightAlreadyExists(FlightRequest request);
        bool IsValidFlightSearchRequest(FlightSearchRequest request);
        List<Flight> SearchFlights(FlightSearchRequest request);
        void DeleteFlightById(int id);
    }
}
