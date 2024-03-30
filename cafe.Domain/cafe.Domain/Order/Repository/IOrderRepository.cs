using cafe.Domain.Common;
using cafe.Domain.Order.Entity;

namespace cafe.Domain.Order.Repository
{
    public interface IOrderRepository 
	{
        Task<Result<OrderEntity,Exception>> Create(OrderEntity entity);

        Task<Result<OrderEntity, Exception>> Update(OrderEntity entity);

        Task<Result<bool, Exception>> CheckOutOrder(int orderId,PaymentMethod paymentMethod);

        Task<ICollection<OrderEntity>> GetCurrentActiveOrders();
    }
}

