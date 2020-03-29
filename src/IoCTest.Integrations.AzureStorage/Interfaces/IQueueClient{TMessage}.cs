using System.Threading.Tasks;

namespace IoCTest.Integrations.AzureStorage.Interfaces
{
	public interface IQueueClient<TMessage>
	{
		Task EnqueueMessageAsync(TMessage message);
	}
}