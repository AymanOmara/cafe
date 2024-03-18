using cafe.Domain.Table.Entity;

namespace cafe.Domain.Table.Repository
{
	public interface ITableRepository
	{
		ICollection<TableEntity> GetAllTables();
	}
}

