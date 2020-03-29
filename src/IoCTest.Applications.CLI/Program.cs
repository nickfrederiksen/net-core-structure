using System.Threading.Tasks;
using IoCTest.Infrastructure.DAL;
using IoCTest.Integrations.AzureStorage;
using IoCTest.Integrations.Email;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IoCTest.Applications.CLI
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var builder = Host.CreateDefaultBuilder(args);
			builder.ConfigureServices((hostContext, services) =>
			{
				services.AddSingleton<IHostedService, HostedConsoleService>();
				services.AddEmailServices();
				services.AddDatabaseAccess();
				services.AddStorage();
			});

			await builder.RunConsoleAsync();
		}
	}
}
