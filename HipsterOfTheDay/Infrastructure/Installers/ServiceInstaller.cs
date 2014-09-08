using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using HispterOfTheDay.Domain.Services;

namespace HipsterOfTheDay.Infrastructure.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var domainAssembly = Assembly.GetAssembly(typeof(IService));

            container.Register(
                Classes.FromAssembly(domainAssembly)
                    .BasedOn(typeof(IService))
                    .WithService
                    .DefaultInterfaces()
                    .LifestylePerWebRequest()
                );
        }
    }
}