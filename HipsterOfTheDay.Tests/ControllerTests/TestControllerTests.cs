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
            Because of = () =>
           {
               _result = _controller.Index();
           };


            It should_return_home_page = () =>
           {
               (_result as ViewResult).ViewName.Should().Be("Test");
           };


            Establish context = () =>
           {
               _controller = new TestController();
           };

            private static TestController _controller;
            private static ActionResult _result;
        }

        public class When_submitting_text_it_should_save_to_raven
        {
            Because of = () =>
           {

           };

            It should_return_submit_the_text = () =>
           {

           };

            Establish context = () =>
           {
               _controller = new TestController();
           };

            private static TestController _controller;
        }
    }
}
