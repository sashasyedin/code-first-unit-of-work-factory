using Quizmaster.Common.Contracts;
using Quizmaster.Common.Entities;

namespace Quizmaster.Business.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Section> _sectionRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public QuestionService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IRepository<Section> sectionRepository,
            IRepository<Question> questionRepository)
        {
            this._questionRepository = questionRepository;
            this._sectionRepository = sectionRepository;
            this._unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
