namespace HispterOfTheDay.Domain.Services
{
    public interface IImageService : IService
    {
        void Post(string imageData);

        string GetLatestImageData();
    }

}
