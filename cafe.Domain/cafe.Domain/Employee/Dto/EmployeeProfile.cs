using AutoMapper;
using cafe.Domain.Category.DTO;

namespace cafe.Domain.Employee.Dto
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<SalaryDeductionEntity, ReadSalaryItemDto>();
            CreateMap<SalaryIncentiveEntity, ReadSalaryItemDto>();
            CreateMap<WriteSalaryItemDTO, SalaryDeductionEntity>();
            CreateMap<WriteSalaryItemDTO, SalaryIncentiveEntity>();
            CreateMap<EmployeeEntity, ReadEmployeeDTO>();
            CreateMap<CreateEmployeeDTO, EmployeeEntity>();
        }
    }
}

