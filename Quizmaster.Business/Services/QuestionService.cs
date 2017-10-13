using System;
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
        private readonly IRepository<Section> _sectionRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public QuestionService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IRepository<Section> sectionRepository,
            IRepository<Question> questionRepository)
        {
            Condition.Requires(unitOfWorkFactory, nameof(unitOfWorkFactory)).IsNotNull();
            Condition.Requires(sectionRepository, nameof(sectionRepository)).IsNotNull();
            Condition.Requires(questionRepository, nameof(questionRepository)).IsNotNull();

            this._questionRepository = questionRepository;
            this._sectionRepository = sectionRepository;
            this._unitOfWorkFactory = unitOfWorkFactory;
        }

        IEnumerable<Question> IQuestionService.ListQuestions(int sectionID)
        {
            var questions = null as IList<Question>;

            using (var unitOfWork = this._unitOfWorkFactory.Create())
            {
                try
                {
                    questions = (from question in this._questionRepository.GetAll()
                                 join section in this._sectionRepository.GetAll() on question.SectionId equals section.ID
                                 where
                                 section.ID == sectionID
                                 select question).ToList();

                    unitOfWork.SaveChanges();
                    unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }

            return questions;
        }
    }
}
