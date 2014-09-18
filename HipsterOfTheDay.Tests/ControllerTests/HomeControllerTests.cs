using FluentAssertions;
using HipsterOfTheDay.Features.Home;
using HispterOfTheDay.Domain.Services;
using Machine.Specifications;
using System.Web.Mvc;
using Rhino.Mocks;

namespace HipsterOfTheDay.Tests.ControllerTests
{

    public class when_submiting_a_valid_image
    {
        Because of = () =>
        {
             _sut.Submit(_imageData);
        };

        It should_save_image = () =>
        {
            _imageService.AssertWasCalled(x => x.Post(_imageData));
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

    public class When_getting_the_success_page
    {
        Because of = () =>
        {
            _result = _controller.Success();
        };


        It should_return_home_page = () =>
        {
            (_result as ViewResult).ViewName.Should().Be("Success");
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

    public class when_displaying_the_latest_image
    {
        Because of = () =>
        {
            _result = _sut.LatestHipster();
        };

        It should_display_the_latest_hipster_page = () =>
        {
            (_result as ViewResult).ViewName.Should().Be("Latest");
        };

        Establish context = () =>
        {
            _imageService = MockRepository.GenerateMock<IImageService>();
            _sut = new HomeController(_imageService);
        };


        static ActionResult _result;
        static HomeController _sut;
        static IImageService _imageService;
    }
}
