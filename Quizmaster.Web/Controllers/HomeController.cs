using System.Web.Mvc;
using Quizmaster.Business.Contracts;
using Quizmaster.Business.Services;
using Quizmaster.DataAccess;
using Quizmaster.Entities;

namespace Quizmaster.Web.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWorkFactory _unitOfWorkFactory;
        private Repository<Question> _questionRepository;

        public HomeController()
        {
            var context = new QuizmasterContext("QuizmasterConnection");

            this._unitOfWorkFactory = new UnitOfWorkFactory(context);
            this._questionRepository = new Repository<Question>(context);

            var service = new QuestionService(this._unitOfWorkFactory, this._questionRepository);

            var res = ((IQuestionService)service).ListQuestions();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
