using AutoMapper;
using cafe.Domain.Employee;
using cafe.Domain.Employee.Dto;
using cafe.Domain.Employee.Repository;
using cafe.Domain.Employee.Service;

namespace cafe.Application.Features.Employee.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _repository;
		public EmployeeService(IMapper mapper,IEmployeeRepository repository)
		{
            _mapper = mapper;
            _repository = repository;
		}

        public async Task<ReadEmployeeDTO> CreateEmployee(CreateEmployeeDTO dto)
        {
            var entity = _mapper.Map<EmployeeEntity>(dto);
            var result = await _repository.Create(entity);
            return _mapper.Map<ReadEmployeeDTO>(result);
        }

        public async Task DeleteEmployee(ReadEmployeeDTO dto)
        {
            var entity = _mapper.Map<EmployeeEntity>(dto);
            await _repository.Delete(entity);
        }

        public async Task<ICollection<ReadEmployeeDTO>> GetAllEmployees()
        {
            var result = await _repository.GetAllRecords();
            return _mapper.Map<List<ReadEmployeeDTO>>(result);
        }

        public async Task<ReadEmployeeDTO> PaySalary(UpdateEmployeeDTO dto)
        {
            var entity = _mapper.Map<EmployeeEntity>(dto);
            var result = await _repository.PaySalary(entity);
            return _mapper.Map<ReadEmployeeDTO>(result);
        }

        public async Task<ReadEmployeeDTO> UpdateEmployee(UpdateEmployeeDTO dto)
        {
            var entity = _mapper.Map<EmployeeEntity>(dto);
            var result = await _repository.Update(entity);
            return _mapper.Map<ReadEmployeeDTO>(result);
        }
    }
}

