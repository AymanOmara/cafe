using cafe.Domain.Client.Entity;
using cafe.Domain.Common;

namespace cafe.Domain.Client.Repository
{
    public interface IClientRepository : IGenericRepository<ClientEntity>
	{
        Task MarkClientDeleted(ClientEntity client);
    }
}