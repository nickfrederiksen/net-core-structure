using IoCTest.Infrastructure.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IoCTest.Infrastructure.DAL
{
	public static class DALConfigurator
	{
		public static void AddDatabaseAccess(this IServiceCollection services)
		{
			services.AddDbContext<IDatabaseContext, DatabaseContext>();
		}
	}
}
