using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Requests;

namespace FlightPlanner.Services.Validators
{
    public class AirportNameDuplicationValidator : IValidator
    {
        public bool Validate(FlightRequest request)
        {
            if (request.From == null || request.To == null || request.From.Airport == null || request.To.Airport == null)
            {
                return false;
            }

            return request.From.Airport.Trim().ToLower() != request.To.Airport.Trim().ToLower();
        }
    }
}
