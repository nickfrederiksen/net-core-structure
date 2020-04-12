using System.Collections.Generic;
using System.Linq;
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
			var configurations = ParseArgs(args);

			var builder = Host.CreateDefaultBuilder(args);
			builder.ConfigureServices((hostContext, services) =>
			{
				services.AddSingleton<IHostedService, HostedConsoleService>();
				services.AddEmailServices(
					options =>
					{
						if (configurations.TryGetValue("emailBCC", out var bcc))
						{
							options.BCC = bcc.Split(',');
						}
						if (configurations.TryGetValue("emailCC", out var ccc))
						{
							options.CC = ccc.Split(',');
						}
						if (configurations.TryGetValue("emailTo", out var to))
						{
							options.To = to.Split(',');
						}

						options.Host = configurations["emailHost"];
						options.Username = configurations["emailUsername"];
						options.Password = configurations["emailPassword"];
						options.SenderEmail = configurations["emailSenderEmail"];
						options.SenderName = configurations["emailSenderName"];
						options.ReplyTo = configurations["emailReplyTo"];
					});
				services.AddDatabaseAccess(
					options =>
					{
						options.ConnectionString = configurations["dalConnectionString"];
					});

				services.AddStorage(
					options =>
					{
						options.ConnectionString = configurations["azureStorageConnectionString"];
						options.QueueName = configurations["azureStorageQueueName"];
					});
			});

			await builder.RunConsoleAsync();
		}

		private static IReadOnlyDictionary<string, string> ParseArgs(string[] args)
		{
			var values = new Dictionary<string, string>();

			for (int i = 0; i < args.Length - 1; i++)
			{
				var key = args[i];
				var value = args[i + 1];
				if (key.StartsWith('-'))
				{
					key = key.Substring(1);
					values.Add(key, value);
				}
			}

			return values;
		}
	}
}
