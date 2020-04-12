using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCTest.Integrations.AzureStorage.Options
{
	public class AzureStorageOptions
	{
		public string ConnectionString { get; set; }

		public string QueueName { get; set; }
	}
}
