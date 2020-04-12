using IoCTest.Integrations.AzureStorage.Clients.Abstracts;
using IoCTest.Integrations.AzureStorage.Interfaces;
using IoCTest.Integrations.AzureStorage.Models;
using IoCTest.Integrations.AzureStorage.Options;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Extensions.Options;

namespace IoCTest.Integrations.AzureStorage.Clients
{
public class QueueService : QueueClient<QueueModel>, IQueueService, IQueueClient<QueueModel>
{
	public QueueService(CloudQueueClient cloudQueueClient, IOptionsSnapshot<AzureStorageOptions> options)
		: base(cloudQueueClient, options.Value.QueueName)

	{
	}
}
}
