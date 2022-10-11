using System.Collections.Generic;

namespace FlightPlanner.Interfaces
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
