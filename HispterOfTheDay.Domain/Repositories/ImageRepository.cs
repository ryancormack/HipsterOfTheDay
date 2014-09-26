using System.Linq;
using HispterOfTheDay.Domain.Model;
using Raven.Client;
using Raven.Client.Linq;

namespace HispterOfTheDay.Domain.Repositories
{
    public class ImageRepository : IImageRepository
    {
        readonly IDocumentSession _documentSession;

        public ImageRepository(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public void Save(Image image)
        {
            _documentSession.Store(image);
            _documentSession.SaveChanges();
        }

        public Image GetLatestImage()
        {
            var images = _documentSession.Query<Image>().OrderBy(image => image.CaptureTime);
            return images.ToList().Last();
        }
    }
}
