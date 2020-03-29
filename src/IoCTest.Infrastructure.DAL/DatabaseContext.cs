using IoCTest.Infrastructure.DAL.Entities;
using IoCTest.Infrastructure.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IoCTest.Infrastructure.DAL
{
	public class DatabaseContext : DbContext, IDatabaseContext
	{
		public DatabaseContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<SomeEntity> SomeEntities { get; set; }
	}
}
