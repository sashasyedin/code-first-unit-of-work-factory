using System.Configuration;
using System.Data.Entity;
using Quizmaster.Common.Contracts;

namespace Quizmaster.DataAccess
{
    public class ContextFactory : IContextFactory<DbContext>
    {
        public DbContext GetCurrentContext()
        {
            return new DbContext(ConfigurationManager.AppSettings["ConnectionString"]);
        }
    }
}
