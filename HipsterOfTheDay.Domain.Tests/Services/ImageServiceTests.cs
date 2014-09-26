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
            _sut.Post(_imageData);  
        };

        It should_save_image = () =>
        {
            _imageRepository.AssertWasCalled(x=>x.Save(_image));
        };

        Establish context = () =>
        {
            _imageData = "someBigString";
            _image = new Image{ ImageData = _imageData };
            _imageRepository = MockRepository.GenerateStub<IImageRepository>();
            _sut = new ImageService(_imageRepository);
        };

        static IImageService _sut;
        static IImageRepository _imageRepository;
        static string _imageData;
        static Image _image;
    }

    class when_getting_latest_image_string
    {
        Because of = () =>
        {
            _sut.GetLatestImageData();
        };

        It should_get_the_latest_image_base_string = () =>
        {
            _imageRepository.AssertWasCalled(x => x.GetLatestImage());
        };

        Establish context = () =>
        {
            _imageRepository = MockRepository.GenerateStub<IImageRepository>();
            _sut = new ImageService(_imageRepository);
            _imageRepository.Stub(x => x.GetLatestImage()).Return(new Image() { ImageData = "YoureADoucheHipster" });
        };

        static IImageService _sut;
        static IImageRepository _imageRepository;
    }
}
