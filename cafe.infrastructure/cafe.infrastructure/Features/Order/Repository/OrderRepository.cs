using cafe.Common;
using cafe.Domain.Common;
using cafe.Domain.Order.Entity;
using cafe.Domain.Order.Repository;
using cafe.Domain.Transaction.Entity;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Order.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CafeDbContext _context;

        private readonly LanguageService _localization;

        public OrderRepository(CafeDbContext context,LanguageService localization)
        {
            _context = context;
            _localization = localization;
        }

        public async Task<Result<OrderEntity, Exception>> Create(OrderEntity entity)
        {
            var currentShift = await _context.Shifts.FirstOrDefaultAsync(shift => shift.Closed == false);
            var attachedTable = await _context.Tables.AsNoTracking().Include(t => t.Orders).FirstOrDefaultAsync(table => table.Id == entity.TableId);
            var hasActiveOrder = attachedTable?.Orders.Any(order => order.IsActive == true);
            if (hasActiveOrder == true)
            {
                return new Exception(_localization.Getkey("the_table_alerdy_has_active_order").Value);
            }
            
            if (entity.IsTakeAway) {
                entity.IsActive = false;
                if (entity.TotalPrice > 0) {
                    await AddTransaction(entity.TotalPrice);
                }
            }
            entity.ShiftEntity = currentShift;
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
            var result = await GetOrderById(entity.Id);
            return result;
        }

        public async Task<ICollection<OrderEntity>> GetAllRecords()
        {
            var result = await _context.Orders.Include(order=>order.Table).Include(order => order.OrderItems).ThenInclude(or => or.Meal).Include(or => or.ShiftEntity).ToListAsync();
            return result;
        }

        public async Task<Result<OrderEntity, Exception>> Update(OrderEntity entity)
        {
            foreach (var orderItem in entity.OrderItems)
            {
                if (orderItem.Id == 0)
                {
                    _context.Entry(orderItem).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(orderItem).State = EntityState.Modified;
                }
            }
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result  = await GetOrderById(entity.Id);

            return result;
        }

        public async Task<OrderEntity?> GetOrderById(int orderId)
        {
            var order = await _context.Orders.Include(or => or.Table).Include(or => or.OrderItems).ThenInclude(or => or.Meal).FirstOrDefaultAsync(or => or.Id == orderId);
            return order;
        }

        public async Task<Result<bool, Exception>> CheckOutOrder(int orderId, PaymentMethod paymentMethod)
        {
            var order =  await GetOrderById(orderId);
            order.PaymentMethod = paymentMethod;
            order.IsActive = false;
            _context.Entry(order).State = EntityState.Modified;
            await AddTransaction(order.TotalPrice);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<OrderEntity>> GetCurrentActiveOrders() {
            var allRecords = await GetAllRecords();
            var activeOrders = allRecords.Where(order => order.IsActive == true).ToList();
            return activeOrders;
        }

        private async Task AddTransaction(decimal amount)
        {
            var currentShift = await _context.Shifts.FirstOrDefaultAsync(shift => shift.Closed == false);
            var transaction = new TransactionEntity() { Amount = amount, Shift = currentShift, TransactionType = TransactionType.SellOrder };
            await _context.TransactionsEntity.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }
    }
}

