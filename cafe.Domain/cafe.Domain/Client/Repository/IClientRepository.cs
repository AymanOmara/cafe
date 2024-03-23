using cafe.Domain.Client.Entity;

namespace cafe.Domain.Client.Repository
{
	public interface IClientRepository
	{
		ICollection<ClientEntity> GetAllClients();

        ClientEntity AddClient(ClientEntity client);

        Task<ClientEntity> UpdateClient(ClientEntity client);

        Task DeleteClient(ClientEntity client);

        Task MarkClientDeleted(ClientEntity client);
    }
}