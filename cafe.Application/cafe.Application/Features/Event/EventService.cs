using AutoMapper;
using cafe.Common;
using cafe.Domain.Common;
using cafe.Domain.Event.DTO;
using cafe.Domain.Event.Entity;
using cafe.Domain.Event.Service;
using cafe.Domain.Transaction.Entity;


namespace cafe.Application.Features.Event
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly LanguageService _localization;

        public EventService(IUnitOfWork unitOfWork, IMapper mapper, LanguageService localization)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localization = localization;
        }

        public async Task<BaseResponse<string>> CancelEvent(int id, string resaon)
        {
            var eventEntity = await _unitOfWork.Events.GetEventById(id);
            if (eventEntity == null)
            {
                return new BaseResponse<string> { statusCode = 404, message = _localization.Getkey("event_not_found").Value };
            }
            eventEntity.CancelationReason = resaon;
            await _unitOfWork.Events.Delete(eventEntity);
            return new BaseResponse<string> { data = _localization.Getkey("sucess").Value, statusCode = 200, success = true, message = _localization.Getkey("event_deleted_successfully").Value };
        }

        public async Task<BaseResponse<string>> Checkout(UpdateEventDTO dto)
        {
            var currentEvent = await _unitOfWork.Events.GetEventById(dto.Id);
            var entity = _mapper.Map<EventEntity>(dto);
            if (entity.RemainingAmount > 0)
            {
                var message = _localization.Getkey("error_please_close_the_amount_first").Value;
                return new BaseResponse<string> { statusCode = 400, data = message, message = message };
            }
            var _ = await _unitOfWork.Events.CheckOut(entity);
            var revenue = currentEvent.Deposit - dto.Deposit;
            if (revenue > 0)
            {
                var transactionEntity = new TransactionEntity
                {
                    TransactionType = TransactionType.ReserveEvent,
                    Amount = revenue
                };
                await _unitOfWork.Transactions.CreateTransaction(transactionEntity);
            }
            return new BaseResponse<string> { statusCode = 200, data = _localization.Getkey("success").Value, message = _localization.Getkey("check_out_successfully").Value };
        }

        public async Task<BaseResponse<ReadEventDTO>> CreateEvent(CreateEventDTO dto)
        {
            var isPastDate = DateTime.Compare(dto.RservationDate, DateTime.Now) > 0;
            if (!isPastDate)
            {
                return new BaseResponse<ReadEventDTO> { message = _localization.Getkey("reserve_past_date_not_allowed").Value, statusCode = 400 };
            }
            if (dto.Deposit > dto.Price)
            {
                return new BaseResponse<ReadEventDTO> { message = _localization.Getkey("deposite_cannot_gratter_than_price").Value, statusCode = 400 };
            }
            var entity = _mapper.Map<EventEntity>(dto);
            var result = await _unitOfWork.Events.Create(entity);

            var transactionEntity = new TransactionEntity
            {
                TransactionType = TransactionType.ReserveEvent,
                Amount = dto.Deposit
            };
            await _unitOfWork.Transactions.CreateTransaction(transactionEntity);
            var mappedResult = _mapper.Map<ReadEventDTO>(result);
            return new BaseResponse<ReadEventDTO> { statusCode = 200, data = mappedResult, success = true, message = _localization.Getkey("success").Value };
        }

        public async Task<ICollection<ReadEventDTO>> GetUpcommingEvents()
        {
            var result = await _unitOfWork.Events.GetAllRecords();
            return _mapper.Map<List<ReadEventDTO>>(result.Where(eve => !eve.Deleted && !eve.CheckOut));
        }

        public async Task<BaseResponse<ReadEventDTO>> UpdateEvent(UpdateEventDTO dto)
        {
            var currentEvent = await _unitOfWork.Events.GetEventById(dto.Id);
            if (currentEvent == null)
            {
                return new BaseResponse<ReadEventDTO> { statusCode = 404, message = _localization.Getkey("event_not_found").Value };
            }
            var isPastDate = DateTime.Compare(dto.RservationDate, DateTime.Now) > 0;
            if (!isPastDate)
            {
                return new BaseResponse<ReadEventDTO> { message = _localization.Getkey("reserve_past_date_not_allowed").Value, statusCode = 400 };
            }
            if (dto.Deposit > dto.Price)
            {
                return new BaseResponse<ReadEventDTO> { message = _localization.Getkey("deposite_cannot_gratter_than_price").Value, statusCode = 400 };
            }
            var entity = _mapper.Map<EventEntity>(dto);
            var result = await _unitOfWork.Events.Update(entity);
            var revenue = currentEvent.Deposit - dto.Deposit;
            if (revenue > 0)
            {
                var transactionEntity = new TransactionEntity
                {
                    TransactionType = TransactionType.ReserveEvent,
                    Amount = revenue
                };
                await _unitOfWork.Transactions.CreateTransaction(transactionEntity);
            }

            var mappedResult = _mapper.Map<ReadEventDTO>(result);
            return new BaseResponse<ReadEventDTO> { data = mappedResult, statusCode = 200, success = true, message = _localization.Getkey("success").Value };
        }
    }
}