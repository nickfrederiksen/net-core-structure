using IoCTest.Infrastructure.DAL.Interfaces;
using IoCTest.Infrastructure.DAL.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace IoCTest.Infrastructure.DAL
{
	public static class DALConfigurator
	{
		public static void AddDatabaseAccess(this IServiceCollection services, Action<DALOptions> dalOptions)
		{
			services.Configure(dalOptions);

			services.AddDbContext<IDatabaseContext, DatabaseContext>(
				(provider, optionsBuilder) =>
				{
					var options = provider.GetRequiredService<IOptionsMonitor<DALOptions>>();
					optionsBuilder.UseSqlServer(options.CurrentValue.ConnectionString);
				});
		}
	}
}
