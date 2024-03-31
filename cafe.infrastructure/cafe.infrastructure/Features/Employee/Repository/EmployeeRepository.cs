using cafe.Domain.Employee;
using cafe.Domain.Employee.Repository;
using cafe.Domain.Transaction.Entity;
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

        public async Task<EmployeeEntity> Create(EmployeeEntity employeeEntity)
        {
            _context.Employees.Add(employeeEntity);
            await _context.SaveChangesAsync();
            return employeeEntity;
        }

        public async Task Delete(EmployeeEntity employeeEntity)
        {
            SalaryItemsCleaner(employeeEntity);
            _context.Employees.Remove(employeeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<EmployeeEntity>> GetAllRecords()
        {
            return await _context.Employees.Include(emp => emp.Deductions).Include(emp => emp.Incentive).Include(emp => emp.Advance).ToListAsync();
        }

        public async Task<EmployeeEntity> PaySalary(EmployeeEntity employeeEntity)
        {
            SalaryItemsCleaner(employeeEntity);
            await _context.SaveChangesAsync();
            return employeeEntity;
        }

        public async Task<EmployeeEntity> Update(EmployeeEntity employeeEntity)
        {
            foreach (var advance in employeeEntity.Advance)
            {
                if (advance.Id == 0)
                {
                    if (advance.Amount > 0)
                    {
                        await AddTransaction(advance.Amount);
                    }
                }
                else
                {
                    var currentEmployee = await _context.Employees.Include(adv => adv.Advance).AsNoTracking().FirstOrDefaultAsync(emp => emp.Id == employeeEntity.Id);
                    var currentAdvance = currentEmployee.Advance.FirstOrDefault(adv => advance.Id == adv.Id);
                    var totalAdance =  advance.Amount - currentAdvance.Amount;
                    if (totalAdance != 0)
                    {
                        await AddTransaction(totalAdance);
                    }
                }
            }

            SalaryItemUpdate(employeeEntity);
            _context.Entry(employeeEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            
            return employeeEntity;
        }


        private void SalaryItemsCleaner(EmployeeEntity employeeEntity)
        {
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

        private async void SalaryItemUpdate(EmployeeEntity employeeEntity)
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

        private async Task AddTransaction(decimal Amount)
        {
            var currentShift = await _context.Shifts.FirstOrDefaultAsync(shift=> shift.Closed == false);
            var transaction = new TransactionEntity() {TransactionType = TransactionType.SalaryAdvance ,Shift= currentShift,Amount = Amount };
            await _context.TransactionsEntity.AddAsync(transaction);
        }
    }
}