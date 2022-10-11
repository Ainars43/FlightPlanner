namespace FlightPlanner.Services.Validators
{
    public class AirportToNameValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.To?.AirportCode);
        }
    }
}
