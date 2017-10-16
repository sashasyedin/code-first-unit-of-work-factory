using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;
using Quizmaster.Business.Contracts;
using Quizmaster.DataAccess.Contracts;
using Quizmaster.Entities;

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

        IEnumerable<Question> IQuestionService.ListQuestions()
        {
            using (var unitOfWork = this._unitOfWorkFactory.Create())
            {
                var questions = this._questionRepository.GetAll().ToList();
                return questions;
            }
        }
    }
}
