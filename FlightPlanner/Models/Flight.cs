namespace FlightPlanner.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public Airport From { get; set; }
        public Airport To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

        public bool Equals(Flight flight)
        {
            return flight.From.Equals(From)
                && flight.To.Equals(To)
                && flight.Carrier == Carrier
                && flight.DepartureTime == DepartureTime
                && flight.ArrivalTime == ArrivalTime;
        }
    }
}
