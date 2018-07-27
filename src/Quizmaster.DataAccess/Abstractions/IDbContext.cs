using Quizmaster.Entities.Abstractions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Quizmaster.DataAccess.Abstractions
{
    public interface IDbContext
    {
        string ConnectionString { get; }

        Database Database { get; }

        void Dispose();

        DbEntityEntry Entry(object o);

        int SaveChanges();

        IDbSet<T> Set<T>() where T : class, IEntity;
    }
}
