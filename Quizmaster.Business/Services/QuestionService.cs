using Quizmaster.Common.Contracts;

namespace Quizmaster.Business.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public QuestionService(IUnitOfWorkFactory unitOfWorkFactory, IQuestionRepository questionRepository)
        {
            this._questionRepository = questionRepository;
            this._unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
