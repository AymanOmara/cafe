using cafe.Common;
using cafe.Domain.Common;
using cafe.Domain.Order.Entity;
using cafe.Domain.Shift;
using cafe.Domain.Shift.Entity;
using cafe.Domain.Transaction.Entity;
using cafe.Domain.Users.Repository;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Shift
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly CafeDbContext _context;
        private readonly LanguageService _localization;
        private readonly IUserNotifier _userNotifier;
        public ShiftRepository(CafeDbContext context, LanguageService localization, IUserNotifier userNotifier)
        {
            _context = context;
            _localization = localization;
            _userNotifier = userNotifier;
        }

        public async Task<Result<bool, Exception>> CloseCurrentShift()
        {
            var isCurrentShiftOpen = await IsCurrentShiftOpen();
            if (!isCurrentShiftOpen)
            {
                return new Exception(_localization.Getkey("error_start_shift_first").Value);
            }
            var currentShift = await _context
                .Shifts
                   .Include(sh => sh.Transactions)
                   .Include(sh => sh.Orders)
                   .ThenInclude(sh=>sh.OrderItems)
                .FirstOrDefaultAsync(shift => shift.Closed == false);
            //currentShift.Closed = true;
            await _context.SaveChangesAsync();
            var content = CreateEmailContent(currentShift);
            await _userNotifier.Notify("aymanomara55@gmail.com", content);
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
                return new Exception(_localization.Getkey("please_close_current_shift_first").Value);
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
        private string CreateEmailContent(ShiftEntity shift) {
            int? totalOrders = shift?.Orders?.Count;
            decimal revnue = 0;
            if (shift.Orders != null)
            {
                revnue = shift.Orders.Sum(or => or.TotalPrice);
            }

            decimal expenses = 0;
            if (shift.Transactions != null) {
                expenses = shift.Transactions.Where(trns => trns.TransactionType == TransactionType.SalaryAdvance).Sum(tras => tras.Amount);
            }
            var content = $"order number {totalOrders}\n total revenu: {revnue} \n total expenses:{expenses}\n";
            return content;
        }
    }
}

