﻿using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Core
{
    public interface IEntityService<T> where T : Entity
    {
        IQueryable<T> Query();
        IEnumerable<T> Get();
        T GetByID(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}