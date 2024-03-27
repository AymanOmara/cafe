using AutoMapper;
using cafe.Domain.Event.DTO;
using cafe.Domain.Event.Entity;
using cafe.Domain.Event.Repository;
using cafe.Domain.Event.Service;
using cafe.Domain.Transaction.Entity;
using cafe.Domain.Transaction.Repository;

namespace cafe.Application.Features.Event
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public EventService(IEventRepository repository, ITransactionRepository transactionRepository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<ReadEventDTO> CreateEvent(CreateEventDTO dto)
        {
            var entity = _mapper.Map<EventEntity>(dto);
            var result = await _repository.Create(entity);

            //todo create this using custome mapper
            var transactionEntity = new TransactionEntity
            {
                TransactionType = TransactionType.ReserveEvent,
                Amount = dto.Deposit
            };
            await _transactionRepository.CreateTransaction(transactionEntity);
            return _mapper.Map<ReadEventDTO>(result);
        }

        public async Task<ICollection<ReadEventDTO>> GetUpcommingEvents()
        {
            var result = await _repository.GetAllRecords();
            return _mapper.Map<List<ReadEventDTO>>(result.Where(eve => !eve.Deleted && !eve.CheckOut));
        }
    }
}