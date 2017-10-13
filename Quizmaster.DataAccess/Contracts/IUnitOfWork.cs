using System;

namespace Quizmaster.DataAccess.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();

        void SaveChanges();
    }
}
