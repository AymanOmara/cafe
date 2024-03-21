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

        public TableEntity CreateTable(TableEntity entity)
        {
            _context.Tables.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task ChangeDeleteStatus(int tableId,bool status)
        {
            var table = GetAllTables().FirstOrDefault(table => table.Id == tableId);
            if (table != null) {
                table.Deleted = status;
                _context.Entry(table).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<TableEntity> GetAllTables()
        {
            return _context.Tables.Include(table => table.Client);
        }

        public async Task<TableEntity?> GetTableByClientId(int clientId)
        {
            var result = await GetAllTables().FirstOrDefaultAsync(table => table.ClientId == clientId);
            return result;
        }
    }
}

