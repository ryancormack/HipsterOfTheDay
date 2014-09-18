using System.Web.Mvc;
using HispterOfTheDay.Domain.Services;

namespace HipsterOfTheDay.Features.Home
{
    public class HomeController : Controller
    {

        readonly IImageService _imageService;

        public HomeController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public void Submit(string imageData)
        {
            _imageService.Post(imageData);
        }

        public ActionResult LatestHipster()
        {
            var model = new LatestHipsterViewModel { LatestHipsterImageData = _imageService.GetLatestImageData() };
            return View("Latest", model);
        }

        public ActionResult Success()
        {
            return View("Success");
        }
    }
}
