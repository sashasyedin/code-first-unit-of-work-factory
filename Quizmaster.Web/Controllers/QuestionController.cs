using System.Web.Mvc;
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

        public JsonResult ListQuestions()
        {
            var questions = _questionService.ListQuestions();
            return Json(questions, JsonRequestBehavior.AllowGet);
        }
    }
}
