using cafe.Domain.Table.Entity;
using cafe.Domain.Table.Repository;

namespace cafe.infrastructure.Features.Table.Repository
{
	public class TableRepository: ITableRepository
	{
        private readonly CafeDbContext _context;
		public TableRepository(CafeDbContext context)
		{
            _context = context;
		}

        public ICollection<TableEntity> GetAllTables()
        {
            return _context.Tables.ToList();
        }
    }
}

