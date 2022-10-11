namespace FlightPlanner.Validators
{
    public class AirportToCountryValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.To?.Country);
        }
    }
}
