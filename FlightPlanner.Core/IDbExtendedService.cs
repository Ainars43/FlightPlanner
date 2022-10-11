namespace FlightPlanner.Core
{
    public interface IDbExtendedService : IDbService
    {
        void DeleteAll();
    }
}