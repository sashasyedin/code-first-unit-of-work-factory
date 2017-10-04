namespace Quizmaster.Common.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();

        void Rollback();

        void SaveChanges();
    }
}
