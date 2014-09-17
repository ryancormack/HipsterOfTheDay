using Castle.MicroKernel;
using Raven.Client;
using Raven.Client.Document;

namespace HipsterOfTheDay.Infrastructure.Factories
{
    public static class DocumentStoreFactory
    {
        public static IDocumentStore CreateDocumentStore()
        {
            var documentStore = new DocumentStore { ConnectionStringName = "HipsterOfTheDayLocal" };
            documentStore.Initialize();
            //IndexCreation.CreateIndexes(typeof(Post).Assembly, store);
            return documentStore;
        }

        public static IDocumentSession GetDocumentSession(IKernel kernel)
        {
            var store = kernel.Resolve<IDocumentStore>();
            return store.OpenSession();
        }
    }
}