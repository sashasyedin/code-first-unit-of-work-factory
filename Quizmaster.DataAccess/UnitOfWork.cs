using System;
using System.Data;
using System.Data.Entity;
using Quizmaster.Common.Contracts;

namespace Quizmaster.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;
        private readonly DbContextTransaction _transaction;

        public UnitOfWork(IContextFactory contextFactory, IsolationLevel isolationLevel)
        {
            this._context = contextFactory.GetCurrentContext<DbContext>();
            this._transaction = this._context.Database.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            this._transaction.Commit();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            this._transaction.Rollback();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (disposing == false)
                return;

            this._transaction?.Dispose();
            this._context?.Dispose();
        }
    }
}
