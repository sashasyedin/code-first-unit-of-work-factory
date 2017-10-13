using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Quizmaster.DataAccess.Contracts;

namespace Quizmaster.DataAccess
{
    public class QuizmasterContext : DbContext, IDbContext
    {
        static QuizmasterContext()
        {
            Database.SetInitializer<QuizmasterContext>(null);
        }

        public QuizmasterContext(string connectionString)
            : base(connectionString)
        {
            ConnectionString = Database.Connection.ConnectionString;
        }

        public string ConnectionString { get; private set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
