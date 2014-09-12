using System;
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
        public ActionResult Submit(string imageData)
        {
            _imageService.Post(imageData);

            return View("Success");
        }

        [HttpPost]
        public string SubmitOld(string dataUrl)
        {
            try
            {
                var image = new ImageDataUrl(dataUrl);
                var fileName = image.SaveTo("C:\\hipster");
                var url = ("C:\\hipster" + fileName);
                return url;
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }

        public ActionResult LatestHipster()
        {
            var model = new LatestHipsterViewModel();
            return View("latest", model);
        }
    }
}
