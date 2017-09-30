using System;
using System.Data.Entity;
using Quizmaster.Common.Contracts;

namespace Quizmaster.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing == false)
                return;

            if (this._context != null)
                this._context.Dispose();
        }
    }
}
