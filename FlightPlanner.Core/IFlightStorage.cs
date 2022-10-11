using System.Collections.Generic;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Core
{
    public interface IFlightStorage
    {
        Flight GetFlight(int id);
        bool FlightAlreadyExists(Flight flight);
        Airport[] FindAirports(string keyword);
        bool IsValidFlightSearchRequest(FlightSearchRequest request);
        List<Flight> SearchFlights(FlightSearchRequest request);
    }
}
