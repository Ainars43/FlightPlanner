using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Interfaces
{
    public interface IValidator
    {
        bool Validate(Flight flight);
    }
}