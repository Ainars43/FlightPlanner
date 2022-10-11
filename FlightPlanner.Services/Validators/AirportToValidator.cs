namespace FlightPlanner.Services.Validators
{
    public class AirportToValidator : IValidator
    {
        public bool Validate(Flight flight)
        {
            return flight?.To != null;
        }
    }
}
