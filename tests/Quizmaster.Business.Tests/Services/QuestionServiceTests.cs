using Moq;
using Quizmaster.Business.Contracts.Models;
using Quizmaster.Business.Contracts.Services;
using Quizmaster.Business.Services;
using Quizmaster.DataAccess.Abstractions;
using Quizmaster.Entities;
using Quizmaster.Tests;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Quizmaster.Business.Tests.Services
{
    public class QuestionServiceTests : UnitTestContainer
    {
        private readonly Mock<IRepository<Question>> _questionRepository;

        private readonly Mock<IUnitOfWorkFactory> _unitOfWorkFactory;

        private readonly IQuestionService _questionService;

        #region ListQuestions members

        private int _callsToQuestionsGetAll;

        private IEnumerable<Question> _questions;

        #endregion ListQuestions members

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionServiceTests"/> class.
        /// </summary>
        public QuestionServiceTests()
        {
            base.TestInitialise();

            this._questionRepository = new Mock<IRepository<Question>>();
            this._unitOfWorkFactory = new Mock<IUnitOfWorkFactory>();

            this._questionService = new QuestionService(
                this._unitOfWorkFactory.Object,
                this._questionRepository.Object);
        }

        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [Fact]
        public void ListQuestions_WhenGetAllReturnsEmptyList_ExpectQuestionNotFoundResult()
        {
            this._callsToQuestionsGetAll = 1;
            this._questions = Enumerable.Empty<Question>();
            this.Stub();

            var actual = this._questionService.ListQuestions();

            Assert.NotNull(actual);
            Assert.False(actual.Success);
            Assert.Equal(ListQuestionsResult.QuestionNotFound, actual.Result);
            this.AssertCore();
        }

        /// <summary>
        /// Tests the operation under the specified circumstances.
        /// </summary>
        [Fact]
        public void ListQuestions_UnderValidCircumstances_ExpectSuccess()
        {
            this._callsToQuestionsGetAll = 1;

            this._questions = new[]
            {
                new Question { ID = 1, Name = "Test_Q1" },
                new Question { ID = 2, Name = "Test_Q2" },
                new Question { ID = 3, Name = "Test_Q3" }
            };

            this.Stub();

            var actual = this._questionService.ListQuestions();

            Assert.NotNull(actual);
            Assert.NotNull(actual.Questions);
            Assert.Equal(3, actual.Questions.Count());
            Assert.True(actual.Success);
            this.AssertCore();
        }

        /// <summary>
        /// Performs assertions common to all tests.
        /// </summary>
        protected override void AssertCore()
        {
            base.AssertCore();

            this._questionRepository.Verify(repository => repository.GetAll(),
                Times.Exactly(this._callsToQuestionsGetAll));
        }

        /// <summary>
        /// Sets up the mocks used in this test class.
        /// </summary>
        protected override void Stub()
        {
            base.Stub();

            this._questionRepository
                .Setup(repository => repository.GetAll())
                .Returns(this._questions);
        }
    }
}
