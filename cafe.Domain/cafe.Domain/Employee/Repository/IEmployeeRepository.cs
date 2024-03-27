using cafe.Domain.Common;

namespace cafe.Domain.Employee.Repository
{
	public interface IEmployeeRepository: IUnitOfWorkRepository<EmployeeEntity>
    {
        Task<EmployeeEntity> PaySalary(EmployeeEntity employeeEntity);
    }
}

