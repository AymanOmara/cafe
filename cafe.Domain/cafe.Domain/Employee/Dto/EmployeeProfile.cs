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
            CreateMap<ReadEmployeeDTO, EmployeeEntity>();
            CreateMap<CreateEmployeeDTO, EmployeeEntity>();
            CreateMap<UpdateEmployeeDTO, EmployeeEntity>();
            CreateMap<EmployeeEntity, UpdateEmployeeDTO>();
            CreateMap<ReadSalaryItemDto, SalaryIncentiveEntity>();
            CreateMap<ReadSalaryItemDto, SalaryDeductionEntity>();

        }
    }
}

