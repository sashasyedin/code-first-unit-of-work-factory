namespace Quizmaster.Common.Contracts
{
    public interface IContextFactory
    {
        T GetCurrentContext<T>();
    }
}
