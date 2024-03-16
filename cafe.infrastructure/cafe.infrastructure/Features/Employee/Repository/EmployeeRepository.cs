using cafe.Domain.Employee;
using cafe.Domain.Employee.Repository;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Employee.Repository
{
    public class EmployeeRepository : IEmployeeRepository
	{
		private readonly CafeDbContext _context;
		public EmployeeRepository(CafeDbContext context)
		{
			_context = context;
		}

        public EmployeeEntity CreateEmployee(EmployeeEntity employeeEntity)
        {
            _context.Employees.Add(employeeEntity);
            _context.SaveChanges();
            return employeeEntity;
        }

        public ICollection<EmployeeEntity> GetAllEmployees()
        {
            return _context.Employees.Include(emp=>emp.Deductions).Include(emp=> emp.Incentive).ToList();
        }
    }
}

