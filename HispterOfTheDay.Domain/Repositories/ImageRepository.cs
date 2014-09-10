using HispterOfTheDay.Domain.Model;
using Raven.Client;

namespace HispterOfTheDay.Domain.Repositories
{
    public class ImageRepository : IImageRepository
    {
        readonly IDocumentStore _documentStore;

        public ImageRepository(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public void Save(Image image)
        {
            throw new System.NotImplementedException();
        }
    }
}
