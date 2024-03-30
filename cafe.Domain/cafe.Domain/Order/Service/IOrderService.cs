using cafe.Domain.Common;
using cafe.Domain.Order.DTO;
using cafe.Domain.Order.Entity;

namespace cafe.Domain.Order.Service
{
	public interface IOrderService
    {
		Task<BaseResponse<ReadOrderDTO>> CreateOrder(CreateOrderDTO dto);
        
        Task<BaseResponse<ReadOrderDTO>> UpdateOrder(UpdateOrderDTO dto);

        Task<BaseResponse<bool>> CheckOut(int orderId, PaymentMethod paymentMethod);

        Task<BaseResponse<ICollection<ReadOrderDTO>>> GetCurrentActiveOrders();
    }
}

