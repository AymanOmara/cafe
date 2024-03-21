using cafe.Domain.Table.Entity;

namespace cafe.Domain.Table.Repository
{
	public interface ITableRepository
	{
		IQueryable<TableEntity> GetAllTables();

		TableEntity CreateTable(TableEntity entity);

		Task<TableEntity?> GetTableByClientId(int clientId);

		public  Task ChangeDeleteStatus(int tableId, bool status);
    }
}

