using IoCTest.Integrations.AzureStorage.Models;

namespace IoCTest.Integrations.AzureStorage.Interfaces
{
    public interface IQueueService : IQueueClient<QueueModel>
    {
        
    }
}
