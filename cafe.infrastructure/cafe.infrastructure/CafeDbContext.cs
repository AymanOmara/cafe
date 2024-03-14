using cafe.Domain.Category;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure
{
	public class CafeDbContext:DbContext
	{
        public CafeDbContext(DbContextOptions<CafeDbContext> options) : base(options)
        {

        }

        public DbSet<CategoryEntity> Catgeories { get; set; }

    }
}

