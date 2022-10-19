using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Requests;

namespace FlightPlanner.Services.Validators
{
    public class AddFlightRequestValidator : IValidator
    {
        public bool Validate(FlightRequest request)
        {
            return request != null;
        }
    }
}