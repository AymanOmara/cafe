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
            SalaryItemsCleaner(employeeEntity);
            _context.Employees.Remove(employeeEntity);
            _context.SaveChanges();
        }

        public ICollection<EmployeeEntity> GetAllEmployees()
        {
            return _context.Employees.Include(emp => emp.Deductions).Include(emp => emp.Incentive).Include(emp => emp.Advance).ToList();
        }

        public EmployeeEntity PaySalary(EmployeeEntity employeeEntity)
        {
            SalaryItemsCleaner(employeeEntity);
            _context.SaveChanges();
            return employeeEntity;
        }

        public EmployeeEntity UpdateEmployee(EmployeeEntity employeeEntity)
        {
            SalaryItemUpdate(employeeEntity);
            _context.Entry(employeeEntity).State = EntityState.Modified;
            _context.SaveChanges();
            return employeeEntity;
        }

        private void SalaryItemsCleaner(EmployeeEntity employeeEntity) {

            foreach (var advance in employeeEntity.Advance)
            {
                _context.Entry(advance).State = EntityState.Deleted;
            }

            foreach (var deduction in employeeEntity.Deductions)
            {
                _context.Entry(deduction).State = EntityState.Deleted;
            }

            foreach (var incentive in employeeEntity.Incentive)
            {
                _context.Entry(incentive).State = EntityState.Deleted;
            }
            employeeEntity?.Advance?.Clear();
            employeeEntity?.Deductions?.Clear();
            employeeEntity?.Incentive?.Clear();
        }

        private void SalaryItemUpdate(EmployeeEntity employeeEntity) {
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
            foreach (var advance in employeeEntity.Advance)
            {
                if (advance.Id == 0)
                {
                    _context.Entry(advance).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(advance).State = EntityState.Modified;
                }
            }
        }
    }
}

