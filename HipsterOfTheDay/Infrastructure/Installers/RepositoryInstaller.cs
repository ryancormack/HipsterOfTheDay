using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HispterOfTheDay.Domain.Repositories;

namespace HipsterOfTheDay.Infrastructure.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var domainAssembly = Assembly.GetAssembly(typeof(IRepository));

            container.Register(
                Classes.FromAssembly(domainAssembly)
                    .BasedOn(typeof(IRepository))
                    .WithService
                    .DefaultInterfaces()
                    .LifestylePerWebRequest()
                );
        }
    }
}