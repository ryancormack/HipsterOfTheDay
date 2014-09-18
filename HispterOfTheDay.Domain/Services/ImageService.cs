using HispterOfTheDay.Domain.Model;
using HispterOfTheDay.Domain.Repositories;

namespace HispterOfTheDay.Domain.Services
{
    public class ImageService : IImageService
    {
        readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public void Post(string imageData)
        {
           _imageRepository.Save(new Image{ImageData = imageData});
        }

        public string GetLatestImageData()
        {
            var latestDoucheHipsterImageString = _imageRepository.GetLatestImageData();
            return latestDoucheHipsterImageString;
        }
    }
}
