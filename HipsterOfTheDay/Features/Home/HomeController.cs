using System.Web.Mvc;

namespace HipsterOfTheDay.Features.Home
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }

}