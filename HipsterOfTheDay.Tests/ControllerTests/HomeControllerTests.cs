using System;
using System.Configuration;
using FluentAssertions;
using HipsterOfTheDay.Features.Home;
using HispterOfTheDay.Domain.Services;
using Machine.Specifications;
using System.Web.Mvc;
using Rhino.Mocks;

namespace HipsterOfTheDay.Tests.ControllerTests
{

    class when_submiting_a_valid_image
    {
        Because of = () =>
        {
            _result = _sut.Submit(_imageData);
        };

        It should_save_image = () =>
        {
            _imageService.AssertWasCalled(x => x.Post(_imageData));
        };

        It should_return_sucess_view = () =>
        {
            (_result as ViewResult).ViewName.Should().Be("Success");
        };

        Establish context = () =>
        {
            _imageData = "someBigOlString";
            _imageService = MockRepository.GenerateStub<IImageService>();
            _sut = new HomeController(_imageService);
        };

        static string _imageData;
        static HomeController _sut;
        static IImageService _imageService;
        static ActionResult _result;
    }

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
           _imageService = MockRepository.GenerateMock<IImageService>();
           _controller = new HomeController(_imageService);
       };

        private static HomeController _controller;
        private static ActionResult _result;
        static IImageService _imageService;
    }

    public class When_sumbitting_a_photo
    {
        Because of = () =>
       {
           _result = _controller.SubmitOld(_dataUrl);
       };


        It should_save_image_to_folder = () =>
       {
           _result.Should().HaveLength(47);
       };


        Establish context = () =>
        {
            _imageService = MockRepository.GenerateMock<IImageService>();
            _dataUrl = "yoloimage";
            _image = new ImageDataUrl(_dataUrl);
            _stubbedFileName = MockRepository.GenerateStub<IImageDataUrl>();
            _controller = new HomeController(_imageService);
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
        static IImageService _imageService;
        static IImageDataUrl _fileName;
    }

    public class When_sumbitting_a_null_canvas_item
    {
        Because of = () =>
       {
           _result = Catch.Exception(() => _controller.SubmitOld(_dataUrl));
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

    class when_displaying_the_latest_image
    {
        Because of = () =>
        {
            _result = _sut.LatestHipster();
        };

        It should_display_the_latest_hipster_page = () =>
        {
            (_result as ViewResult).ViewName.Should().Be("latest");
        };


        Establish context = () =>
        {
            _sut = new HomeController(_imageService);
        };


        static ActionResult _result;
        static HomeController _sut;
        static IImageService _imageService;
    }
}
