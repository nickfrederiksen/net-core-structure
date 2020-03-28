using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(IoCTest.AzureFunctions.EmailService.Startup))]
namespace IoCTest.AzureFunctions.EmailService
{
    public class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			// TODO: Register services.
		}
	}
}
