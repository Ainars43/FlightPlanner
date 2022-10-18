using FlightPlanner.Core.Models;
using FlightPlanner.Core.Requests;

namespace FlightPlanner.Core.Interfaces
{
    public interface IValidator
    {
        bool Validate(FlightRequest request);
    }
}