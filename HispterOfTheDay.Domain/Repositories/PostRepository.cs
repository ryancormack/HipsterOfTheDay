using Raven.Client;

namespace HispterOfTheDay.Domain.Repositories
{
    public class PostRepository : IPostRepository
    {
        readonly IDocumentStore _documentStore;

        public PostRepository(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }
    }
}
