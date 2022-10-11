namespace FlightPlanner.Validators
{
    public class AirportToCityValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.To?.City);
        }
    }
}
