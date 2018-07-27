using System.Web.Mvc;

namespace Quizmaster.ApplicationModel.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
