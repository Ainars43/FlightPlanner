namespace FlightPlanner.Validators
{
    public class AirportFromNameValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.From?.AirportCode);
        }
    }
}
