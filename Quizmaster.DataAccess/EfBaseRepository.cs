using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Quizmaster.Common.Contracts;

namespace Quizmaster.DataAccess
{
    public abstract class EfBaseRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        private readonly DbContext _context;
        private IDbSet<T> _entities;

        public EfBaseRepository(DbContext context)
        {
            this._context = context;
        }

        public virtual T Add(T entity)
        {
            return this.Entities.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            this.Entities.Remove(entity);
        }

        public virtual T Get(object id)
        {
            return this.Entities.Find(id);
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return this.Entities.Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.Entities;
        }

        public virtual void Update(T entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (this._entities == null)
                {
                    this._entities = this._context.Set<T>();
                }

                return this._entities;
            }
        }
    }
}
