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

        public ReadEmployeeDTO CreateEmployee(CreateEmployeeDTO dto)
        {
            var entity = _mapper.Map<EmployeeEntity>(dto);
            var result = _repository.CreateEmployee(entity);
            return _mapper.Map<ReadEmployeeDTO>(result);
        }

        public void DeleteEmployee(ReadEmployeeDTO dto)
        {
            var entity = _mapper.Map<EmployeeEntity>(dto);
            _repository.DeleteEmployee(entity);
        }

        public ICollection<ReadEmployeeDTO> GetAllEmployees()
        {
            var result = _repository.GetAllEmployees();
            return _mapper.Map<List<ReadEmployeeDTO>>(result);
        }

        public ReadEmployeeDTO UpdateEmployee(UpdateEmployeeDTO dto)
        {
            var entity = _mapper.Map<EmployeeEntity>(dto);
            var result = _repository.UpdateEmployee(entity);
            return _mapper.Map<ReadEmployeeDTO>(result);
        }
    }
}

