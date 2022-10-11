namespace FlightPlanner.Validators
{
    public class AirportFromCityValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.From?.City);
        }
    }
}
