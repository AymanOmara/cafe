using cafe.Domain.Client.Entity;
using cafe.Domain.Common;

namespace cafe.Domain.Client.Repository
{
    public interface IClientRepository : IUnitOfWorkRepository<ClientEntity>
	{
        Task MarkClientDeleted(ClientEntity client);
    }
}