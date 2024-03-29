using cafe.Domain.Order.Entity;
using cafe.Domain.Order.Repository;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Order.Repository
{
	public class OrderRepository: IOrderRepository
    {
        private readonly CafeDbContext _context;

		public OrderRepository(CafeDbContext context)
		{
            _context = context;
		}

        public Task<OrderEntity> Create(OrderEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(OrderEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<OrderEntity>> GetAllRecords()
        {
            var result = await _context.Orders.Include(order => order.OrderItems).ThenInclude(or=>or.Meal).ToListAsync();
            return result;
        }

        public Task<OrderEntity> Update(OrderEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

