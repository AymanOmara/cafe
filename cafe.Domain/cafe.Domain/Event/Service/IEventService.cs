using cafe.Domain.Common;
using cafe.Domain.Event.DTO;

namespace cafe.Domain.Event.Service
{
	public interface IEventService
	{
		Task<ICollection<ReadEventDTO>> GetUpcommingEvents();

		Task<BaseResponse<ReadEventDTO>> CreateEvent(CreateEventDTO dto);

        Task<BaseResponse<ReadEventDTO>> UpdateEvent(UpdateEventDTO dto);

        Task<BaseResponse<string>> Checkout(UpdateEventDTO dto);

        Task<BaseResponse<string>> CancelEvent(int id , string resaon);
    }
}