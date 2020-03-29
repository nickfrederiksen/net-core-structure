using System.Threading.Tasks;
using IoCTest.Integrations.AzureStorage.Interfaces;
using Microsoft.Azure.Storage.Queue;
using Newtonsoft.Json;

namespace IoCTest.Integrations.AzureStorage.Clients.Abstracts
{
	public abstract class QueueClient<TMessage> : IQueueClient<TMessage>
	{
		private readonly CloudQueueClient client;
		private readonly string queueName;

		public QueueClient(CloudQueueClient cloudQueueClient, string queueName)
		{
			this.client = cloudQueueClient;
			this.queueName = queueName;
		}

		public async Task EnqueueMessageAsync(TMessage message)
		{
			var reference = this.client.GetQueueReference(this.queueName);

			await reference.CreateIfNotExistsAsync().ConfigureAwait(false);

			var json = JsonConvert.SerializeObject(message);
			await reference.AddMessageAsync(new CloudQueueMessage(json, isBase64Encoded: false)).ConfigureAwait(false);
		}
	}
}
