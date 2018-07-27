namespace Quizmaster.DataAccess.Abstractions
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
