using Quizmaster.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Quizmaster.DataAccess.Abstractions
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
