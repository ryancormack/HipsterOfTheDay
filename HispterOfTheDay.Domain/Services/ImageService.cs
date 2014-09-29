using System;
using HispterOfTheDay.Domain.Helpers;
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

        public void Post(string imageData, double longitude, double latitude)
        {
           _imageRepository.Save(new Image{ImageData = imageData, CaptureTime = DateTime.UtcNow});
        }

        public string GetLatestImageData()
        {
            var latestDoucheHipsterImage = _imageRepository.GetLatestImage();
            return latestDoucheHipsterImage.ImageData;
        }
    }
}
