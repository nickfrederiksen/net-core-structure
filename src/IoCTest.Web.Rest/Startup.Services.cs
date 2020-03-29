using IoCTest.Infrastructure.DAL;
using IoCTest.Integrations.AzureStorage;
using IoCTest.Integrations.Email;
using Microsoft.Extensions.DependencyInjection;

namespace IoCTest.Web.Rest
{
	public partial class Startup
	{
		private void RegisterServices(IServiceCollection services)
		{
			services.AddEmailServices();
			services.AddDatabaseAccess();
			services.AddStorage();
		}
	}
}
