using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace IoCTest.Applications.Windows
{
	public partial class App
	{
		public static IContainer ServiceContainer { get; private set; }
		private void ConfigureServices()
		{
			var containerBuilder = new ContainerBuilder();
			IServiceCollection services = new ServiceCollection();

			this.ConfigureServices(services);

			containerBuilder.Populate(services);

			ServiceContainer = containerBuilder.Build();
		}
		private void ConfigureServices(IServiceCollection services)
		{
			// TODO: Configure services!
		}
	}
}
