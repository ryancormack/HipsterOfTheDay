using HispterOfTheDay.Domain.Model;

namespace HispterOfTheDay.Domain.Services
{
    public interface IImageService : IService
    {
        void Post(string imageData, double longitude, double latitude);

        Image GetLatestImage();
    }

}
