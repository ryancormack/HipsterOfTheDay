using FluentAssertions;
using HispterOfTheDay.Domain.Model;
using HispterOfTheDay.Domain.Repositories;
using HispterOfTheDay.Domain.Services;
using Machine.Specifications;
using Rhino.Mocks;

namespace HipsterOfTheDay.Domain.Tests.Services
{
    class when_posting_an_image
    {
        Because of = () =>
        {
            _sut.Post(_imageData, _latitude, _longitude);  
        };

        It should_save_image = () =>
        {
            _imageRepository.AssertWasCalled(x=>x.Save(_image));
        };

        Establish context = () =>
        {
            _imageData = "someBigString";
            _image = new Image{ ImageData = _imageData, Latitude = _latitude, Longitude = _longitude};
            _imageRepository = MockRepository.GenerateStub<IImageRepository>();
            _sut = new ImageService(_imageRepository);
        };

        static IImageService _sut;
        static IImageRepository _imageRepository;
        static string _imageData;
        static Image _image;
        private static double _latitude;
        private static double _longitude;
    }

    class when_getting_latest_image_string
    {
        Because of = () =>
        {
            _sut.GetLatestImage();
        };

        It should_get_the_latest_image = () =>
        {
            _imageRepository.AssertWasCalled(x => x.GetLatestImage());
        };

        Establish context = () =>
        {
            _imageRepository = MockRepository.GenerateStub<IImageRepository>();
            _sut = new ImageService(_imageRepository);
            _imageRepository.Stub(x => x.GetLatestImage()).Return(new Image() { ImageData = "YoureADoucheHipster", Latitude = 1.1, Longitude = 2.2});
        };

        static IImageService _sut;
        static IImageRepository _imageRepository;
    }
}
