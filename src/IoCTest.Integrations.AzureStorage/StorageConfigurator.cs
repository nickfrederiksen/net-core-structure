using IoCTest.Integrations.AzureStorage.Clients;
using IoCTest.Integrations.AzureStorage.Interfaces;
using IoCTest.Integrations.AzureStorage.Options;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace IoCTest.Integrations.AzureStorage
{
	public static class StorageConfigurator
	{
		public static void AddStorage(this IServiceCollection services, Action<AzureStorageOptions> configureStorage)
		{
			services.Configure(configureStorage);

			services.AddSingleton(provider =>
			{
				var options = provider.GetRequiredService<IOptionsMonitor<AzureStorageOptions>>();

				return CloudStorageAccount.Parse(options.CurrentValue.ConnectionString);
			});

			services.AddScoped(provider => provider.GetRequiredService<CloudStorageAccount>().CreateCloudQueueClient());

			services.AddScoped<IQueueService, QueueService>();
		}
	}
}
