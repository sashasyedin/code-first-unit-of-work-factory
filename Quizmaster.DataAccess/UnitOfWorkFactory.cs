using System.Data;
using Quizmaster.Common.Contracts;

namespace Quizmaster.DataAccess
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IContextFactory _contextFactory;
        private readonly IsolationLevel _isolationLevel;

        public UnitOfWorkFactory(IContextFactory contextFactory, IsolationLevel isolationLevel)
        {
            this._contextFactory = contextFactory;
            this._isolationLevel = isolationLevel;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(this._contextFactory, this._isolationLevel);
        }
    }
}
