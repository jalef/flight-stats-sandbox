using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FlightStatsSandbox.Helpers;
using FlightStatsSandbox.Helpers.Impl;
using FlightStatsSandbox.Services;
using FlightStatsSandbox.Services.Impl;

namespace FlightStatsSandbox.Regimes
{
    public class DevelopmentInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //register services
			container.Register(Component.For<IGetData>()
							   .ImplementedBy<GetFidsData>());
            
			//register helpers
			container.Register(Component.For<IApiUrlBuilder>()
							   .ImplementedBy<FidsApiUrlBuilder>());

			container.Register(Component.For<IAppSettings>()
							   .ImplementedBy<FidsAppSettings>());

			
            //register controllers     
			container.Register(Classes.FromThisAssembly()
				.Pick().If(t => t.Name.EndsWith("Controller", StringComparison.CurrentCulture))
				.Configure(configurer => configurer.Named(configurer.Implementation.Name))
				.LifestylePerWebRequest());
			
        }
    }
}