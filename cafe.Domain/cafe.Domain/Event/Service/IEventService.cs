using cafe.Domain.Event.DTO;

namespace cafe.Domain.Event.Service
{
	public interface IEventService
	{
		Task<ICollection<ReadEventDTO>> GetUpcommingEvents();

		Task<ReadEventDTO> CreateEvent(CreateEventDTO dto);
	}
}