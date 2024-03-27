using cafe.Domain.Client.DTO;

namespace cafe.Domain.Client.Service
{
	public interface IClientService
	{
		Task<ICollection<ReadClientDTO>> GetAllClients();

		Task<ReadClientDTO> AddClient(WriteClientDTO dto);

        Task<ReadClientDTO> UpdateClient(UpdateClientDTO dto);

        Task DeleteClient(UpdateClientDTO dto);
    }
}

