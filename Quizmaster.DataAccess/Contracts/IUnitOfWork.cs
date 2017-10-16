using System;

namespace Quizmaster.DataAccess.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
