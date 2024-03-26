using cafe.Domain.Employee.Dto;

namespace cafe.Domain.Employee.Service
{
    public interface IEmployeeService
    {
        ICollection<ReadEmployeeDTO> GetAllEmployees();

        ReadEmployeeDTO CreateEmployee(CreateEmployeeDTO dto);

        ReadEmployeeDTO UpdateEmployee(UpdateEmployeeDTO dto);

        ReadEmployeeDTO PaySalary(UpdateEmployeeDTO dto);

        void DeleteEmployee(ReadEmployeeDTO dto);
    }
}

