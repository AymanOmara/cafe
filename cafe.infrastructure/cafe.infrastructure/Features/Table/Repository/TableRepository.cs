using cafe.Domain.Table.Entity;
using cafe.Domain.Table.Repository;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Table.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly CafeDbContext _context;
        public TableRepository(CafeDbContext context)
        {
            _context = context;
        }

        public async Task<TableEntity> CreateTable(TableEntity entity)
        {
            _context.Tables.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task ChangeDeleteStatus(int tableId,bool status)
        {
            var allTables = await GetAllTables();
            var table = allTables.FirstOrDefault(table => table.Id == tableId);
            if (table != null) {
                table.Deleted = status;
                _context.Entry(table).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async  Task<ICollection<TableEntity>> GetAllTables()
        {
            return await _context.Tables.Include(table => table.Client).ToListAsync();
        }

        public async Task<TableEntity?> GetTableByClientId(int clientId)
        {
            var tables = await GetAllTables();
            var result =  tables.FirstOrDefault(table => table.ClientId == clientId);
            return result;
        }
    }
}

