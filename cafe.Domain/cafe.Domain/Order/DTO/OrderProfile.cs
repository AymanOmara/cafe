using AutoMapper;
using cafe.Domain.Order.Entity;

namespace cafe.Domain.Order.DTO
{
	public class OrderProfile:Profile
	{
		public OrderProfile()
		{
			CreateMap<OrderItemEntity, ReadOrderItemDTO>().ReverseMap();

			CreateMap<OrderEntity,ReadOrderDTO>().ReverseMap();
		}
	}
}

