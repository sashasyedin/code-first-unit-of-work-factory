namespace Quizmaster.Common.Contracts
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
