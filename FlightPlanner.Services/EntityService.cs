using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner.Data;

namespace FlightPlanner.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(IFlightPlannerDbContext context) : base(context)
        {
        }

        public ServiceResult Create(T entity)
        {
            return Create<T>(entity);
        }

        public ServiceResult Delete(T entity)
        {
            return Delete<T>(entity);
        }

        public IEnumerable<T> Get()
        {
            return Get<T>();
        }

        public T GetByID(int id)
        {
            return GetByID<T>(id);
        }

        public IQueryable<T> Query()
        {
            return Query<T>();
        }

        public ServiceResult Update(T entity)
        {
            return Update<T>(entity);
        }
    }
}
