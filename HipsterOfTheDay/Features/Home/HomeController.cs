using System.Web.Mvc;
using HispterOfTheDay.Domain.Services;

namespace HipsterOfTheDay.Features.Home
{
    public class HomeController : Controller
    {
        readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public ActionResult Index()
        {
            return View("Index");
        }
    }
}