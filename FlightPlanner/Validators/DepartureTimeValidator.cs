namespace FlightPlanner.Validators
{
    public class DepartureTimeValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.DepartureTime);
        }
    }
}
