using IoCTest.Integrations.AzureStorage.Clients;
using IoCTest.Integrations.AzureStorage.Interfaces;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Extensions.DependencyInjection;

namespace IoCTest.Integrations.AzureStorage
{
	public static class StorageConfigurator
	{
		public static void AddStorage(this IServiceCollection services)
		{
			services.AddSingleton(provider => CloudStorageAccount.Parse("connection string"));
			services.AddScoped(provider => provider.GetRequiredService<CloudStorageAccount>().CreateCloudQueueClient());

			services.AddScoped<IQueueService, QueueService>();
		}
	}
}
