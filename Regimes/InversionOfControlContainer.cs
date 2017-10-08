using System;
using System.Web.Mvc;
using Castle.Windsor;
using FlightStatsSandbox.Factories;

namespace FlightStatsSandbox.Regimes
{
    public static class InversionOfControlContainer
    {
        public static void SetUp()
        {
			var container = new WindsorContainer();

			container.Install(new DevelopmentInstaller());

			ControllerFactory controllerFactory = new ControllerFactory(container.Kernel);
			ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
