using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Requests;

namespace FlightPlanner.Services.Validators
{
    public class AirportToValidator : IValidator
    {
        public bool Validate(FlightRequest request)
        {
            return request?.To != null;
        }
    }
}
