using cafe.Common;
using cafe.Domain.Client.Entity;
using cafe.Domain.Client.Repository;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Client.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly CafeDbContext _context;
        private readonly LanguageService _localization;
        public ClientRepository(CafeDbContext context, LanguageService localization)
        {
            _context = context;
            _localization = localization;
        }

        public async Task<ClientEntity> Create(ClientEntity client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }


        public async Task Delete(ClientEntity client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }


        public async Task<ICollection<ClientEntity>> GetAllRecords()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task MarkClientDeleted(ClientEntity client)
        {
            client.Deleted = true;
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ClientEntity> Update(ClientEntity client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return client;
        }


    }
}

