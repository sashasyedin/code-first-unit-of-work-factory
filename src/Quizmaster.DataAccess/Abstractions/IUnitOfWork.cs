using System;

namespace Quizmaster.DataAccess.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
