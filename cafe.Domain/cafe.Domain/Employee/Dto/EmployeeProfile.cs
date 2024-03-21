using AutoMapper;
using cafe.Domain.Category.DTO;

namespace cafe.Domain.Employee.Dto
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<SalaryDeductionEntity, ReadSalaryItemDto>().ReverseMap();
            CreateMap<SalaryIncentiveEntity, ReadSalaryItemDto>().ReverseMap();
            CreateMap<WriteSalaryItemDTO, SalaryDeductionEntity>();
            CreateMap<WriteSalaryItemDTO, SalaryIncentiveEntity>();
            CreateMap<EmployeeEntity, ReadEmployeeDTO>().ReverseMap();
            CreateMap<CreateEmployeeDTO, EmployeeEntity>();
            CreateMap<UpdateEmployeeDTO, EmployeeEntity>().ReverseMap();
        }
    }
}

