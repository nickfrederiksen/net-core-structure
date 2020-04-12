using Autofac;
using Autofac.Extensions.DependencyInjection;
using IoCTest.Infrastructure.DAL;
using IoCTest.Integrations.AzureStorage;
using IoCTest.Integrations.Email;
using IoCTest.Integrations.Email.Interfaces;
using IoCTest.Integrations.Email.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
			var settings = this.LoadSettings();
			services.AddEmailServices(
					options =>
					{
						if (settings.TryGetValue("email-BCC", out var bcc))
						{
							options.BCC = bcc.Split(',');
						}
						if (settings.TryGetValue("email-CC", out var ccc))
						{
							options.CC = ccc.Split(',');
						}
						if (settings.TryGetValue("email-To", out var to))
						{
							options.To = to.Split(',');
						}

						options.Host = settings["email-Host"];
						options.Username = settings["email-Username"];
						options.Password = settings["email-Password"];
						options.SenderEmail = settings["email-SenderEmail"];
						options.SenderName = settings["email-SenderName"];
						options.ReplyTo = settings["email-ReplyTo"];
					});
			services.AddDatabaseAccess(
					options =>
					{
						options.ConnectionString = settings["dal-ConnectionString"];
					});
			services.AddStorage(
				options =>
				{
					options.ConnectionString = settings["azureStorage-ConnectionString"];
					options.QueueName = settings["azureStorage-QueueName"];
				});
		}

		private IReadOnlyDictionary<string, string> LoadSettings()
		{
			var lines = File.ReadAllLines("./config.ini");
			var values = lines.Select(l => l.Split("=")).ToDictionary(k => k[0], v => v[1]);

			return values;
		}
	}
}
