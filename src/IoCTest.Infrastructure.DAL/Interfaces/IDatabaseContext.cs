using IoCTest.Infrastructure.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace IoCTest.Infrastructure.DAL.Interfaces
{
	public interface IDatabaseContext
	{
		DbSet<SomeEntity> SomeEntities { get; }
	}
}
