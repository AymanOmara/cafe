using cafe.Domain.Table.DTO;

namespace cafe.Domain.Table.Service
{
	public interface ITableService
    {
		Task<ICollection<ReadTableDTO>> GetAllTables();
	}
}

