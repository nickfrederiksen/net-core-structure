using IoCTest.Infrastructure.DAL;
using IoCTest.Integrations.AzureStorage;
using IoCTest.Integrations.Email;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

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
			services.AddEmailServices(
					options =>
					{
						var bcc = Environment.GetEnvironmentVariable("email-BCC");
						var cc = Environment.GetEnvironmentVariable("email-CC");
						var to = Environment.GetEnvironmentVariable("email-To");
						if (!string.IsNullOrWhiteSpace(bcc))
						{
							options.BCC = bcc.Split(',');
						}
						if (!string.IsNullOrWhiteSpace(cc))
						{
							options.CC = cc.Split(',');
						}
						if (!string.IsNullOrWhiteSpace(to))
						{
							options.To = to.Split(',');
						}

						options.Host = Environment.GetEnvironmentVariable("email-Host");
						options.Username = Environment.GetEnvironmentVariable("email-Username");
						options.Password = Environment.GetEnvironmentVariable("email-Password");
						options.SenderEmail = Environment.GetEnvironmentVariable("email-SenderEmail");
						options.SenderName = Environment.GetEnvironmentVariable("email-SenderName");
						options.ReplyTo = Environment.GetEnvironmentVariable("email-ReplyTo");
					});
			services.AddDatabaseAccess(
				options =>
				{
					options.ConnectionString = Environment.GetEnvironmentVariable("dal-ConnectionString");
				});
			services.AddStorage(
				options =>
				{
					options.ConnectionString = Environment.GetEnvironmentVariable("azureStorage-ConnectionString");
					options.QueueName = Environment.GetEnvironmentVariable("azureStorage-QueueName");
				});
		}
	}
}
