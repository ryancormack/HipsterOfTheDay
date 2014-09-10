using System;
using FluentAssertions;
using HipsterOfTheDay.Features.Home;
using HispterOfTheDay.Domain.Services;
using Machine.Specifications;
using System.Web.Mvc;
using Rhino.Mocks;

namespace HipsterOfTheDay.Tests.ControllerTests
{
    public class HomeControllerTests
    {
        public class When_getting_the_home_page
        {
            Because of = () =>
           {
               _result = _controller.Index();
           };


            It should_return_home_page = () =>
           {
               (_result as ViewResult).ViewName.Should().Be("Index");
           };


            Establish context = () =>
           {
               _postService = MockRepository.GenerateMock<IPostService>();
               _controller = new HomeController(_postService);
           };

            private static HomeController _controller;
            private static ActionResult _result;
            static IPostService _postService;
        }

        public class When_sumbitting_a_photo
        {
            Because of = () =>
           {
               _result = _controller.Submit(_dataUrl);
           };


            It should_save_image_to_folder = () =>
           {
               _result.Should().HaveLength(47);
           };


            Establish context = () =>
            {
                _postService = MockRepository.GenerateMock<IPostService>();
                _dataUrl = "yoloimage";
                _image = new ImageDataUrl(_dataUrl);
                _stubbedFileName = MockRepository.GenerateStub<IImageDataUrl>();
                _controller = new HomeController(_postService);
                _fileName = MockRepository.GenerateStub<IImageDataUrl>();
                //_fileName = new ImageDataUrl(_dataUrl).SaveTo("C:\\hipster");
                _url = ("C:\\hipster" + _fileName);
            };

            private static HomeController _controller;
            private static string _result;
            private static string _dataUrl;
            private static ImageDataUrl _image;
            private static IImageDataUrl _stubbedFileName;
            private static string _url;
            static IPostService _postService;
            static IImageDataUrl _fileName;
        }

        public class When_sumbitting_a_null_canvas_item
        {
            Because of = () =>
           {
               _result = Catch.Exception(() => _controller.Submit(_dataUrl));
           };

            It should_return_an_exception = () =>
           {
               _result.Should().BeOfType(typeof(NullReferenceException));
           };

            Establish context = () =>
           {
               _dataUrl = null;
           };

            private static HomeController _controller;
            private static Exception _result;
            private static string _dataUrl;
        }
    }
}
