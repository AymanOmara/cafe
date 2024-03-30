using AutoMapper;
using cafe.Domain.Order.Entity;

namespace cafe.Domain.Order.DTO
{
	public class OrderProfile:Profile
	{
		public OrderProfile()
		{
            CreateMap<ReadOrderItemDTO, OrderItemEntity>().ReverseMap();

            CreateMap<OrderItemEntity, ReadOrderItemDTO>().ReverseMap();

			CreateMap<OrderEntity,ReadOrderDTO>().ReverseMap();

			CreateMap<CreateOrderDTO, OrderEntity>().ReverseMap();

            CreateMap<OrderEntity, UpdateOrderDTO>().ReverseMap();

            CreateMap<OrderItemEntity, CreateOrderItemDTO>().ReverseMap();

            CreateMap<OrderItemEntity, UpdateOrderItenDTO>().ReverseMap();
            
        }
	}
}

