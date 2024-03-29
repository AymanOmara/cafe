using AutoMapper;
using cafe.Domain.Shift.Entity;

namespace cafe.Domain.Shift.DTO
{
    public class ShiftProfile : Profile
    {
        public ShiftProfile()
        {
            CreateMap<ReadShiftsDTO, ShiftEntity>();

            CreateMap<ShiftEntity, ShiftDetailsDTO>().ReverseMap();


        }
    }
}

