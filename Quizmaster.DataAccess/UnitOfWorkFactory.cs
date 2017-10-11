using System.Data;
using System.Data.Entity;
using CuttingEdge.Conditions;
using Quizmaster.Common.Contracts;

namespace Quizmaster.DataAccess
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly DbContext _context;
        private readonly IsolationLevel _isolationLevel;

        public UnitOfWorkFactory(DbContext context, IsolationLevel isolationLevel)
        {
            Condition.Requires(context, nameof(context)).IsNotNull();
            Condition.Requires(isolationLevel, nameof(isolationLevel)).IsNotEqualTo(IsolationLevel.Unspecified);

            this._context = context;
            this._isolationLevel = isolationLevel;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(this._context, this._isolationLevel);
        }
    }
}
