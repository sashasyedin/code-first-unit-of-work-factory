using CuttingEdge.Conditions;
using Quizmaster.DataAccess.Contracts;

namespace Quizmaster.DataAccess
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDbContext _context;

        public UnitOfWorkFactory(IDbContext context)
        {
            Condition.Requires(context, nameof(context)).IsNotNull();

            this._context = context;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(this._context);
        }
    }
}
