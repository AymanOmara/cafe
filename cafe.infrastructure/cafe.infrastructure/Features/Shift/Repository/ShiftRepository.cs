using cafe.Domain.Common;
using cafe.Domain.Order.Entity;
using cafe.Domain.Shift;
using cafe.Domain.Shift.Entity;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Shift
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly CafeDbContext _context;

        public ShiftRepository(CafeDbContext context)
        {
            _context = context;
        }

        public async Task<Result<bool, Exception>> CloseCurrentShift()
        {
            var isCurrentShiftOpen = await IsCurrentShiftOpen();
            if (!isCurrentShiftOpen)
            {
                return new Exception("please start shift first");
            }
            var currentShift = await _context
                .Shifts
                .FirstOrDefaultAsync(shift => shift.Closed == false);
            currentShift.Closed = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<ShiftEntity>> GetAllShifts()
        {
            var result = await _context.Shifts.ToListAsync();
            return result;
        }

        public async Task<ShiftEntity?> GetCurrentActiveShift()
        {
            var shift = await _context.Shifts.Include(a=> a.Orders).ThenInclude(or=>or.OrderItems).ThenInclude(or=>or.Meal)
                .FirstOrDefaultAsync(shift => shift.Closed == false);
            return shift;
        }

        public async Task<ICollection<OrderEntity>> GetOrdersOnShift(int shiftId)
        {
            var shift = await GetShiftDetails(shiftId);
            return shift?.Orders ?? new List<OrderEntity>() { };
        }

        public async Task<ShiftEntity?> GetShiftDetails(int shiftId)
        {
            var shift = await _context.Shifts
               .Include(s => s.Orders)
               .ThenInclude(s => s.OrderItems)
               .ThenInclude(s => s.Meal)
               .Include(s=>s.Transactions)
               .FirstOrDefaultAsync(s => s.Id == shiftId);
            return shift;
        }

        public async Task<Result<ShiftEntity, Exception>> StartNewShift()
        {
            var isCurrentShiftOpen = await IsCurrentShiftOpen();

            if (isCurrentShiftOpen)
            {
                return new Exception("please close current shift first");
            }
            var shiftEntity = new ShiftEntity() { };
            await _context.Shifts.AddAsync(shiftEntity);
            await _context.SaveChangesAsync();
            return shiftEntity;
        }

        private async Task<bool> IsCurrentShiftOpen()
        {
            return await _context.Shifts.AnyAsync(shift => shift.Closed == false);
        }
    }
}

