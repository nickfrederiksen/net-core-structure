using IoCTest.Infrastructure.DAL;
using IoCTest.Integrations.AzureStorage;
using IoCTest.Integrations.Email;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(IoCTest.AzureFunctions.EmailService.Startup))]
namespace IoCTest.AzureFunctions.EmailService
{
	public class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			ConfigureServices(builder.Services);
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddEmailServices();
			services.AddDatabaseAccess();
			services.AddStorage();
		}
	}
}
