using System;

namespace Quizmaster.Common.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
