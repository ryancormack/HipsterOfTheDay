using HispterOfTheDay.Domain.Model;
using Raven.Client;

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
    }
}
