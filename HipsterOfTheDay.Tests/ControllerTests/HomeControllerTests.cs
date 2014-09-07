﻿using System.Web;
using FluentAssertions;
using HipsterOfTheDay.Features.Home;
using Machine.Specifications;
using System.Web.Mvc;
using Machine.Specifications.Model;
using Rhino.Mocks;


namespace HipsterOfTheDay.Tests.ControllerTests
{
    public class HomeControllerTests
    {
        public class When_getting_the_home_page
        {
            public Because of = () =>
            {
                _result = _controller.Index();
            };


            public It should_return_home_page = () =>
            {
                (_result as ViewResult).ViewName.Should().Be("Index");
            };


            public Establish context = () =>
            {
                _controller = new HomeController();
            };

            private static HomeController _controller;
            private static ActionResult _result;
        }

        public class When_sumbitting_a_photo
        {
            public Because of = () =>
            {
                _result = _controller.Submit(_dataUrl);
            };


            public It should_save_image_to_folder = () =>
            {
                _result.Should().HaveLength(47);
            };


            public Establish context = () =>
            {
                _dataUrl = "yoloimage";
                _image = new ImageDataUrl(_dataUrl);
                _stubbedFileName = MockRepository.GenerateStub<IImageDataUrl>();
                _controller = new HomeController();
                _fileName = new ImageDataUrl(_dataUrl).SaveTo("C:\\hipster");
                _url = ("C:\\hipster" + _fileName);
                _stubbedFileName.Stub(x => x.SaveTo("C:\\hipster")).Return(_fileName);
            };

            private static HomeController _controller;
            private static string _result;
            private static string _dataUrl;
            private static ImageDataUrl _image;
            private static IImageDataUrl _stubbedFileName;
            private static string _fileName;
            private static string _url;
        }
    }
}
