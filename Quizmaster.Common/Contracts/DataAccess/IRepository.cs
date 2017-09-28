using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Quizmaster.Common.Contracts
{
    public interface IRepository<T>
        where T : IEntity
    {
        int Add(T model);

        bool Delete(int id);

        T Get(int id);

        T Get(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);

        bool Update(T model);
    }
}
