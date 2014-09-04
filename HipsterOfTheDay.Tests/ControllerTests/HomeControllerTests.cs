using FluentAssertions;
using HipsterOfTheDay.Features.Home;
using Machine.Specifications;
using System.Web.Mvc;


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
                //_controller = new HomeController();
            };

            private static HomeController _controller;
            private static ActionResult _result;
        }
    }
}
