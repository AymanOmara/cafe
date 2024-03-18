using cafe.Domain.Table.DTO;

namespace cafe.Domain.Table.Service
{
	public interface ITableService
    {
		ICollection<ReadTableDTO> GetAllTables();
	}
}

