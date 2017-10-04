namespace Quizmaster.Common.Contracts
{
    public interface IContextFactory<T>
    {
        T GetCurrentContext();
    }
}
