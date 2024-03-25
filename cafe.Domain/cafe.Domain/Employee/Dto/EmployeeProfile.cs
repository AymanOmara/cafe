using AutoMapper;
using cafe.Domain.Category.DTO;
using cafe.Domain.Employee.entity;

namespace cafe.Domain.Employee.Dto
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<SalaryDeductionEntity, ReadSalaryItemDto>().ReverseMap();
            CreateMap<SalaryIncentiveEntity, ReadSalaryItemDto>().ReverseMap();
            CreateMap<WriteSalaryItemDTO, SalaryDeductionEntity>();
            CreateMap<ReadAdvancePaymentDTO, PayAdvance>();            
            CreateMap<WriteSalaryItemDTO, SalaryIncentiveEntity>();
            CreateMap<EmployeeEntity, ReadEmployeeDTO>().ReverseMap();
            CreateMap<CreateEmployeeDTO, EmployeeEntity>();
            CreateMap<UpdateEmployeeDTO, EmployeeEntity>().ReverseMap();
            CreateMap<PayAdvance, WriteSalaryAdvance>().ReverseMap();
            CreateMap<PayAdvance, ReadAdvancePaymentDTO>().ReverseMap();
        }
    }
}

