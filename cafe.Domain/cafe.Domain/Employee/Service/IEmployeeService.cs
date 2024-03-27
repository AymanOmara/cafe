using cafe.Domain.Employee.Dto;

namespace cafe.Domain.Employee.Service
{
    public interface IEmployeeService
    {
        Task<ICollection<ReadEmployeeDTO>> GetAllEmployees();

        Task<ReadEmployeeDTO> CreateEmployee(CreateEmployeeDTO dto);

        Task<ReadEmployeeDTO> UpdateEmployee(UpdateEmployeeDTO dto);

        Task<ReadEmployeeDTO> PaySalary(UpdateEmployeeDTO dto);

        Task DeleteEmployee(ReadEmployeeDTO dto);
    }
}

