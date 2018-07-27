using CuttingEdge.Conditions;
using Quizmaster.DataAccess.Abstractions;
using Quizmaster.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Quizmaster.DataAccess
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        private readonly IDbContext _context;
        private readonly IDbSet<T> _entities;

        public Repository(IDbContext context)
        {
            Condition.Requires(context, nameof(context)).IsNotNull();

            this._context = context;
            this._entities = context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            return this._entities.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            this._entities.Remove(entity);
        }

        public virtual T Get(object id)
        {
            return this._entities.Find(id);
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return this._entities.Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this._entities;
        }

        public virtual void Update(T entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
        }
    }
}
