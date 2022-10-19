using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Requests;

namespace FlightPlanner.Services.Validators
{
    public class DepartureTimeValidator : IValidator
    {
        public bool Validate(FlightRequest request)
        {
            return !string.IsNullOrEmpty(request?.DepartureTime);
        }
    }
}
