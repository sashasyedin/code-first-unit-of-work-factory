using CuttingEdge.Conditions;
using Quizmaster.Business.Contracts.Models;
using Quizmaster.Business.Contracts.Services;
using Quizmaster.DataAccess.Abstractions;
using Quizmaster.Entities;
using System.Linq;

namespace Quizmaster.Business.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public QuestionService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IRepository<Question> questionRepository)
        {
            Condition.Requires(unitOfWorkFactory, nameof(unitOfWorkFactory)).IsNotNull();
            Condition.Requires(questionRepository, nameof(questionRepository)).IsNotNull();

            this._questionRepository = questionRepository;
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        ListQuestionsResponse IQuestionService.ListQuestions()
        {
            using (var unitOfWork = this._unitOfWorkFactory.Create())
            {
                var questions = this._questionRepository.GetAll().ToList();

                if (questions == null
                    || questions.Any() == false)
                {
                    return new ListQuestionsResponse { Result = ListQuestionsResult.QuestionNotFound };
                }

                return new ListQuestionsResponse
                {
                    Questions = questions,
                    Result = ListQuestionsResult.Success
                };
            }
        }
    }
}
