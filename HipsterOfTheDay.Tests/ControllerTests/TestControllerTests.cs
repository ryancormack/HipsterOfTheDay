using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentAssertions;
using HipsterOfTheDay.Features.Test;
using Machine.Specifications;

namespace HipsterOfTheDay.Tests.ControllerTests
{
    public class TestControllerTests
    {
        public class When_getting_the_test_page
        {
            public Because of = () =>
            {
                _result = _controller.Index();
            };


            public It should_return_home_page = () =>
            {
                (_result as ViewResult).ViewName.Should().Be("Test");
            };


            public Establish context = () =>
            {
                _controller = new TestController();
            };

            private static TestController _controller;
            private static ActionResult _result;
        }

        public class When_submitting_text_it_should_save_to_raven
        {
            public Because of = () =>
            {

            };

            public It should_return_submit_the_text = () =>
            {

            };

            public Establish context = () =>
            {
                _controller = new TestController();
            };

            private static TestController _controller;
        }
    }
}
