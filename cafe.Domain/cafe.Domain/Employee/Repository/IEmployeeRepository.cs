namespace cafe.Domain.Employee.Repository
{
	public interface IEmployeeRepository
	{
		ICollection<EmployeeEntity> GetAllEmployees();

		EmployeeEntity CreateEmployee(EmployeeEntity employeeEntity);
    }
}

