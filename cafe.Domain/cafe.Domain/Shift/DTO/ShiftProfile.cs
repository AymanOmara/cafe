using AutoMapper;
using cafe.Domain.Shift.Entity;

namespace cafe.Domain.Shift.DTO
{
    public class ShiftProfile : Profile
    {
        public ShiftProfile()
        {
            CreateMap<ReadShiftDTO, ShiftEntity>().ReverseMap();

            CreateMap<ShiftEntity, ShiftDetailsDTO>().ReverseMap();
        }
    }
}