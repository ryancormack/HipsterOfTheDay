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
        public void Submit(string imageData, double latitude, double longitude)
        {
            _imageService.Post(imageData, latitude, longitude);
        }

        public ActionResult LatestHipster()
        {
            var model = new LatestHipsterViewModel { LatestHipsterImage = _imageService.GetLatestImage()};
            return View("Latest", model);
        }

        public ActionResult Success()
        {
            return View("Success");
        }
    }
}
