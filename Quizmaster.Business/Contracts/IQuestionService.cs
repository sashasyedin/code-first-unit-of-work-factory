using System.Collections.Generic;
using Quizmaster.Entities;

namespace Quizmaster.Business.Contracts
{
    public interface IQuestionService
    {
        IEnumerable<Question> ListQuestions();
    }
}
