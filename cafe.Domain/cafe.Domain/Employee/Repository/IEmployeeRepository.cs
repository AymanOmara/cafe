using cafe.Domain.Common;

namespace cafe.Domain.Employee.Repository
{
	public interface IEmployeeRepository: IGenericRepository<EmployeeEntity>
    {
        Task<EmployeeEntity> PaySalary(EmployeeEntity employeeEntity);
    }
}

