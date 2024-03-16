using cafe.Domain.Employee.Dto;

namespace cafe.Domain.Employee.Service
{
    public interface IEmployeeService
    {
        ICollection<ReadEmployeeDTO> GetAllEmployees();
        ReadEmployeeDTO CreateEmployee(CreateEmployeeDTO dto);
    }
}

