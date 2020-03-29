using IoCTest.Integrations.AzureStorage.Clients.Abstracts;
using IoCTest.Integrations.AzureStorage.Interfaces;
using IoCTest.Integrations.AzureStorage.Models;
using Microsoft.Azure.Storage.Queue;

namespace IoCTest.Integrations.AzureStorage.Clients
{
	public class QueueService : QueueClient<QueueModel>, IQueueService, IQueueClient<QueueModel>
	{
		public QueueService(CloudQueueClient cloudQueueClient)
			: base(cloudQueueClient, "queue-name")

		{
		}
	}
}
