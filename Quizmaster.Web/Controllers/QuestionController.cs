using System.Web.Mvc;
using Newtonsoft.Json;
using Quizmaster.Business.Contracts;

namespace Quizmaster.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public ContentResult ListQuestions()
        {
            var questions = _questionService.ListQuestions();

            var list = JsonConvert.SerializeObject(
                questions,
                Formatting.None,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return Content(list, "application/json");
        }
    }
}
