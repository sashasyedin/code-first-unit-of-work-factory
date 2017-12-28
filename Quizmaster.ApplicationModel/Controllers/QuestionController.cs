using System.Web.Mvc;
using CuttingEdge.Conditions;
using Newtonsoft.Json;
using Quizmaster.Business.Contracts;

namespace Quizmaster.ApplicationModel.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            Condition.Requires(questionService, nameof(questionService)).IsNotNull();

            this._questionService = questionService;
        }

        public ContentResult ListQuestions()
        {
            var questions = this._questionService.ListQuestions();

            var list = JsonConvert.SerializeObject(
                questions,
                Formatting.None,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return this.Content(list, "application/json");
        }
    }
}
