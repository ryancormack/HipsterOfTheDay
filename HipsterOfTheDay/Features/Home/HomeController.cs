using System;
using System.Web.Mvc;

namespace HipsterOfTheDay.Features.Home
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public string Submit(string dataUrl)
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
    }
}