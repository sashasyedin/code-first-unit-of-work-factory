using System.Data;
using System.Data.Entity;
using Quizmaster.Common.Contracts;

namespace Quizmaster.DataAccess
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IContextFactory<DbContext> _contextFactory;
        private readonly IsolationLevel _isolationLevel;

        public UnitOfWorkFactory(IContextFactory<DbContext> contextFactory, IsolationLevel isolationLevel)
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
