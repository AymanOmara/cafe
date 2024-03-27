using cafe.Domain.Table.Entity;

namespace cafe.Domain.Table.Repository
{
    public interface ITableRepository
    {
        Task<ICollection<TableEntity>> GetAllTables();

        Task<TableEntity> CreateTable(TableEntity entity);

        Task<TableEntity?> GetTableByClientId(int clientId);

        Task ChangeDeleteStatus(int tableId, bool status);
    }
}

