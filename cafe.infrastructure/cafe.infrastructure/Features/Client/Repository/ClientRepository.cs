using cafe.Domain.Client.Entity;
using cafe.Domain.Client.Repository;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Client.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly CafeDbContext _context;
        public ClientRepository(CafeDbContext context)
        {
            _context = context;
        }

        public ClientEntity AddClient(ClientEntity client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return client;
        }

        public async Task DeleteClient(ClientEntity client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public ICollection<ClientEntity> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public async Task MarkClientDeleted(ClientEntity client)
        {
            client.Deleted = true;
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ClientEntity> UpdateClient(ClientEntity client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return client;
        }
    }
}

