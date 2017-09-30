using System.Transactions;

namespace Quizmaster.Common.Contracts
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create(IsolationLevel isolationLevel);

        IUnitOfWork Create();
    }
}
