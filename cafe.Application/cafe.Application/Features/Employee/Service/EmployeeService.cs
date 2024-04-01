using AutoMapper;
using cafe.Common;
using cafe.Domain.Common;
using cafe.Domain.Employee;
using cafe.Domain.Employee.Dto;
using cafe.Domain.Employee.Service;

namespace cafe.Application.Features.Employee.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        private readonly LanguageService _localization;

        public EmployeeService(IMapper mapper, IUnitOfWork unitOfWork, LanguageService localization)
		{
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _localization = localization;
		}

        public async Task<ReadEmployeeDTO> CreateEmployee(CreateEmployeeDTO dto)
        {
            var entity = _mapper.Map<EmployeeEntity>(dto);
            var result = await _unitOfWork.Employees.Create(entity);
            return _mapper.Map<ReadEmployeeDTO>(result);
        }

        public async Task DeleteEmployee(ReadEmployeeDTO dto)
        {
            var entity = _mapper.Map<EmployeeEntity>(dto);
            await _unitOfWork.Employees.Delete(entity);
        }

        public async Task<ICollection<ReadEmployeeDTO>> GetAllEmployees()
        {
            var result = await _unitOfWork.Employees.GetAllRecords();
            return _mapper.Map<List<ReadEmployeeDTO>>(result);
        }

        public async Task<ReadEmployeeDTO> PaySalary(UpdateEmployeeDTO dto)
        {
            var entity = _mapper.Map<EmployeeEntity>(dto);
            var result = await _unitOfWork.Employees.PaySalary(entity);
            return _mapper.Map<ReadEmployeeDTO>(result);
        }

        public async Task<ReadEmployeeDTO> UpdateEmployee(UpdateEmployeeDTO dto)
        {
            var entity = _mapper.Map<EmployeeEntity>(dto);
            var result = await _unitOfWork.Employees.Update(entity);
            return _mapper.Map<ReadEmployeeDTO>(result);
        }
    }
}

