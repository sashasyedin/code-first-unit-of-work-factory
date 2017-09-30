using System.Transactions;

namespace Quizmaster.Common.Helpers
{
    public static class TransactionScopeBuilder
    {
        public static TransactionScope Create(IsolationLevel isolationLevel)
        {
            var options = new TransactionOptions
            {
                IsolationLevel = isolationLevel,
                Timeout = TransactionManager.DefaultTimeout
            };

            return new TransactionScope(TransactionScopeOption.Required, options);
        }
    }
}
