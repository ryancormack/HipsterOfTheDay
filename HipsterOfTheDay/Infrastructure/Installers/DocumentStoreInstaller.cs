using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HipsterOfTheDay.Infrastructure.Factories;
using Raven.Client;

namespace HipsterOfTheDay.Infrastructure.Installers
{
    public class DocumentStoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDocumentStore>().Instance(DocumentStoreFactory.CreateDocumentStore()).LifestyleSingleton(),
                Component.For<IDocumentSession>().UsingFactoryMethod(DocumentStoreFactory.GetDocumentSession).LifestylePerWebRequest());
        }
    }
}