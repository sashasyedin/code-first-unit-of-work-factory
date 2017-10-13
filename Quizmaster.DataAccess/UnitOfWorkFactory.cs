using System.Data;
using CuttingEdge.Conditions;
using Quizmaster.DataAccess.Contracts;

namespace Quizmaster.DataAccess
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDbContext _context;
        private readonly IsolationLevel _isolationLevel;

        public UnitOfWorkFactory(IDbContext context, IsolationLevel isolationLevel)
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
