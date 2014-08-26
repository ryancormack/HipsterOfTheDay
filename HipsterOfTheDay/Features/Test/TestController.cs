using System.Web.Mvc;

namespace HipsterOfTheDay.Features.Test
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View("Test");
        }
    }
}