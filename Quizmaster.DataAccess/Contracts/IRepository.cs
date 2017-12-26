﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Quizmaster.Entities.Contracts;

namespace Quizmaster.DataAccess.Contracts
{
    public interface IRepository<T>
        where T : IEntity
    {
        T Add(T entity);

        void Delete(T entity);

        T Get(object id);

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();

        void Update(T entity);
    }
}