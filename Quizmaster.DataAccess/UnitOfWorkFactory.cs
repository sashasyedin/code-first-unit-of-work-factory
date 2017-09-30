using System;
using System.Transactions;
using Quizmaster.Common.Contracts;

namespace Quizmaster.DataAccess
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        public IUnitOfWork Create()
        {
            return this.Create(IsolationLevel.ReadCommitted);
        }
    }
}
