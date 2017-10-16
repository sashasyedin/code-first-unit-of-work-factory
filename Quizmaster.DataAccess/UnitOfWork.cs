using System;
using CuttingEdge.Conditions;
using Quizmaster.DataAccess.Contracts;

namespace Quizmaster.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;

        public UnitOfWork(IDbContext context)
        {
            Condition.Requires(context, nameof(context)).IsNotNull();

            this._context = context;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (disposing == false)
                return;

            this._context?.Dispose();
        }
    }
}
