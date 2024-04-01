using System.Collections.Generic;
using AutoMapper;
using cafe.Common;
using cafe.Domain.Common;
using cafe.Domain.Order.DTO;
using cafe.Domain.Order.Entity;
using cafe.Domain.Order.Service;

namespace cafe.Application.Features.Order.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly LanguageService _localization;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, LanguageService localization)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localization = localization;
        }

        public async Task<BaseResponse<bool>> CheckOut(int orderId, PaymentMethod paymentMethod)
        {
            var result = await _unitOfWork.Orders.CheckOutOrder(orderId, paymentMethod);
            if (!result.IsOk)
            {
                return new BaseResponse<bool> { statusCode = 400, message = _localization.Getkey("error_try_again_later").Value };
            }
            return new BaseResponse<bool> { statusCode = 200, data = true, message = _localization.Getkey("sucess").Value, success = true };
        }

        public async Task<BaseResponse<ReadOrderDTO>> CreateOrder(CreateOrderDTO dto)
        {
            var entity = _mapper.Map<OrderEntity>(dto);
            var result = await _unitOfWork.Orders.Create(entity);
            if (!result.IsOk)
            {
                return new BaseResponse<ReadOrderDTO> { statusCode = 400, message = result.Error.Message };
            }
            var mappedResult = _mapper.Map<ReadOrderDTO>(result.Value);
            return new BaseResponse<ReadOrderDTO> { data = mappedResult, statusCode = 200, success = true, message = _localization.Getkey("sucess").Value };
        }

        public async Task<BaseResponse<ICollection<ReadOrderDTO>>> GetCurrentActiveOrders()
        {
            var result = await _unitOfWork.Orders.GetCurrentActiveOrders();
            var mappedResult = _mapper.Map<ICollection<ReadOrderDTO>>(result);
            return new BaseResponse<ICollection<ReadOrderDTO>> { data = mappedResult,statusCode = 200,success = true};
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<ReadOrderDTO>> UpdateOrder(UpdateOrderDTO dto)
        {
            var entity = _mapper.Map<OrderEntity>(dto);
            if (dto.OrderItems.Count == 0)
            {
                return new BaseResponse<ReadOrderDTO> { statusCode = 400, message = _localization.Getkey("please_add_order_items").Value };
            }
            var result = await _unitOfWork.Orders.Update(entity);
            var mappedResult = _mapper.Map<ReadOrderDTO>(result.Value);
            return new BaseResponse<ReadOrderDTO> { data = mappedResult, statusCode = 200, success = true };
        }
    }
}

