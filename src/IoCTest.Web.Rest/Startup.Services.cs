using IoCTest.Infrastructure.DAL;
using IoCTest.Integrations.AzureStorage;
using IoCTest.Integrations.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoCTest.Web.Rest
{
	public partial class Startup
	{
		private void RegisterServices(IServiceCollection services)
		{
			services.AddStorage(
				options =>
				{
					this.Configuration.Bind("azureStorage", options);
					options.ConnectionString = this.Configuration.GetConnectionString("azureStorage");
				});
			services.AddEmailServices(options => this.Configuration.Bind("email", options));
			services.AddDatabaseAccess(
				options =>
				{
					options.ConnectionString = this.Configuration.GetConnectionString("dal");
				});
		}
	}
}
