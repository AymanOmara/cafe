using AutoMapper;
using cafe.Domain.Event.Entity;

namespace cafe.Domain.Event.DTO
{
    public class EventDTOProfile : Profile
    {
        public EventDTOProfile()
        {
            CreateMap<ReadEventDTO, EventEntity>().ReverseMap();

            CreateMap<CreateEventDTO, EventEntity>();
        }
    }
}