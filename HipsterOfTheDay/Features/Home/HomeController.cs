﻿using System;
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