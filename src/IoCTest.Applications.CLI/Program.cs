using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace IoCTest.Applications.CLI
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var builder = Host.CreateDefaultBuilder(args)
				.ConfigureServices((hostContext, services) =>
				{
					services.AddSingleton<IHostedService, HostedConsoleService>();
					// TODO: Register services
				});

			await builder.RunConsoleAsync();

		}
	}
}
