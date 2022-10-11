using Microsoft.EntityFrameworkCore;

namespace FlightPlanner
{
    public interface IFlightPlannerDbContext
    {
        DbSet<Flight> Flights { get; set; }
        DbSet<Airport> Airports { get; set; }
        
    }
}