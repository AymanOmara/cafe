namespace cafe.Domain.Employee.Repository
{
	public interface IEmployeeRepository
	{
		ICollection<EmployeeEntity> GetAllEmployees();

		EmployeeEntity CreateEmployee(EmployeeEntity employeeEntity);

        EmployeeEntity UpdateEmployee(EmployeeEntity employeeEntity);

        EmployeeEntity PaySalary(EmployeeEntity employeeEntity);

        void DeleteEmployee(EmployeeEntity employeeEntity);
    }
}

