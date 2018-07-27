using Quizmaster.Business.Contracts.Models;

namespace Quizmaster.Business.Contracts.Services
{
    public interface IQuestionService
    {
        ListQuestionsResponse ListQuestions();
    }
}
