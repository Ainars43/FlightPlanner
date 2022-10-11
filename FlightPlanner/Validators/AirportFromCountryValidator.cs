namespace FlightPlanner.Validators
{
    public class AirportFromCountryValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.From?.Country);
        }
    }
}
