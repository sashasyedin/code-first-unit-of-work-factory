using Quizmaster.DataAccess.Abstractions;
using Quizmaster.Entities;
using Quizmaster.Entities.Abstractions;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Quizmaster.DataAccess
{
    public class QuizmasterContext : DbContext, IDbContext
    {
        static QuizmasterContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<QuizmasterContext>());
        }

        public QuizmasterContext(string connectionString)
            : base(connectionString)
        {
            ConnectionString = Database.Connection.ConnectionString;
        }

        public string ConnectionString { get; private set; }

        public new IDbSet<T> Set<T>()
            where T : class, IEntity
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>()
                .HasOptional(q => q.Section)
                .WithMany(s => s.Questions)
                .HasForeignKey(q => q.SectionId);

            modelBuilder.Entity<Answer>()
                .HasRequired(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
