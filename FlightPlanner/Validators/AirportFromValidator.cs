namespace FlightPlanner.Validators
{
    public class AirportFromValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return flight?.From != null;
        }
    }
}
