using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Services
{
    public interface IDbService
    {
        IQueryable<T> Query<T>() where T : Entity;
        IEnumerable<T> Get<T>() where T : Entity;
        T GetByID<T>(int id) where T : Entity;
        ServiceResult Create<T>(T entity) where T : Entity;
        ServiceResult Update<T>(T entity) where T : Entity;
        ServiceResult Delete<T>(T entity) where T : Entity;
    }
}