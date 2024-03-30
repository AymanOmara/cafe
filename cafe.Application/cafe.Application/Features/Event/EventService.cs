using AutoMapper;
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

        public EventService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<string>> CancelEvent(int id, string resaon)
        {
            var eventEntity = await _unitOfWork.Events.GetEventById(id);
            if (eventEntity == null) {
                return new BaseResponse<string> { statusCode = 404,message = "event not found"};
            }
            eventEntity.CancelationReason = resaon;
            await _unitOfWork.Events.Delete(eventEntity);
            return new BaseResponse<string> { data = "sucess" ,statusCode = 200,success = true,message = "event deleted successfully"};
        }

        public async Task<BaseResponse<string>> Checkout(UpdateEventDTO dto)
        {
            var currentEvent = await _unitOfWork.Events.GetEventById(dto.Id);
            var entity = _mapper.Map<EventEntity>(dto);
            if (entity.RemainingAmount > 0) {
                var message = "error please close the amount first";
                return new BaseResponse<string> { statusCode = 400, data = message, message= message };
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
            return new BaseResponse<string> { statusCode = 200, data = "success",message = "check out successfully" };
        }

        public async Task<BaseResponse<ReadEventDTO>> CreateEvent(CreateEventDTO dto)
        {
            var isPastDate = DateTime.Compare(dto.RservationDate, DateTime.Now) > 0;
            if (!isPastDate) {
                return new BaseResponse<ReadEventDTO> {message = "error date shouldnot be erlier than now",statusCode = 400 };
            }
            if (dto.Deposit > dto.Price) {
                return new BaseResponse<ReadEventDTO> { message = "error deposite cannot be gratter than price", statusCode = 400 };
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
            return new BaseResponse<ReadEventDTO>{ statusCode = 200,data = mappedResult, success = true ,message = ""};
        }

        public async Task<ICollection<ReadEventDTO>> GetUpcommingEvents()
        {
            var result = await _unitOfWork.Events.GetAllRecords();
            return _mapper.Map<List<ReadEventDTO>>(result.Where(eve => !eve.Deleted && !eve.CheckOut));
        }

        public async Task<BaseResponse<ReadEventDTO>> UpdateEvent(UpdateEventDTO dto)
        {
            var currentEvent = await _unitOfWork.Events.GetEventById(dto.Id);
            if (currentEvent == null) {
                return new BaseResponse<ReadEventDTO> { statusCode = 404, message = "event not found" };
            }
            var isPastDate = DateTime.Compare(dto.RservationDate, DateTime.Now) > 0;
            if (!isPastDate)
            {
                return new BaseResponse<ReadEventDTO> { message = "error date shouldnot be erlier than now", statusCode = 400 };
            }
            if (dto.Deposit > dto.Price)
            {
                return new BaseResponse<ReadEventDTO> { message = "error deposite cannot be gratter than price", statusCode = 400 };
            }
            var entity = _mapper.Map<EventEntity>(dto);
            var result = await _unitOfWork.Events.Update(entity);
            var revenue = currentEvent.Deposit - dto.Deposit;
            if (revenue > 0) {
                var transactionEntity = new TransactionEntity
                {
                    TransactionType = TransactionType.ReserveEvent,
                    Amount = revenue
                };
                await _unitOfWork.Transactions.CreateTransaction(transactionEntity);
            }
            
            var mappedResult = _mapper.Map<ReadEventDTO>(result);
            return new BaseResponse<ReadEventDTO> { data = mappedResult, statusCode = 200, success = true};
        }
    }
}