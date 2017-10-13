namespace Quizmaster.DataAccess.Contracts
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
