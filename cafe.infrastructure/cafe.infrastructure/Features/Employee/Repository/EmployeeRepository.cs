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

        public void DeleteEmployee(EmployeeEntity employeeEntity)
        {
            _context.Employees.Remove(employeeEntity);
            _context.SaveChanges();
        }

        public ICollection<EmployeeEntity> GetAllEmployees()
        {
            return _context.Employees.Include(emp=>emp.Deductions).Include(emp=> emp.Incentive).ToList();
        }

        public EmployeeEntity UpdateEmployee(EmployeeEntity employeeEntity)
        {
            foreach (var deduction in employeeEntity.Deductions)
            {
                if (deduction.Id == 0)
                {
                    _context.Entry(deduction).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(deduction).State = EntityState.Modified;
                }
            }
            foreach (var incentive in employeeEntity.Incentive)
            {
                if (incentive.Id == 0)
                {
                    _context.Entry(incentive).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(incentive).State = EntityState.Modified;
                }
            }
            _context.Entry(employeeEntity).State = EntityState.Modified;
            _context.SaveChanges();
            return employeeEntity;
        }
    }
}

