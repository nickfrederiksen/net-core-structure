using System.Threading;
using System.Threading.Tasks;
using IoCTest.Integrations.AzureStorage.Interfaces;
using Microsoft.Extensions.Hosting;

namespace IoCTest.Applications.CLI
{
	internal class HostedConsoleService : IHostedService
	{
		private readonly IQueueService queueService;

		public HostedConsoleService(IQueueService queueService)
		{
			this.queueService = queueService;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}