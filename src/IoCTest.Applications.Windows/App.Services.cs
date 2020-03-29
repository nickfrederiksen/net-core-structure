using Autofac;
using Autofac.Extensions.DependencyInjection;
using IoCTest.Infrastructure.DAL;
using IoCTest.Integrations.AzureStorage;
using IoCTest.Integrations.Email;
using IoCTest.Integrations.Email.Interfaces;
using IoCTest.Integrations.Email.Services;
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

			services.AddScoped<IEmailClient, EmailClient>();

			this.ConfigureServices(services);

			containerBuilder.Populate(services);

			ServiceContainer = containerBuilder.Build();
		}
		private void ConfigureServices(IServiceCollection services)
		{
			services.AddEmailServices();
			services.AddDatabaseAccess();
			services.AddStorage();
		}
	}
}
