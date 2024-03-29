using AutoMapper;
using cafe.Domain.Transaction.DTO;
using cafe.Domain.Transaction.Repository;
using cafe.Domain.Transaction.Service;

namespace cafe.Application.Features.Transaction.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<ReadTransactionDTO>> GetAllTransactions()
        {
            var result = await _repository.GetAllTransaction();

            

            return _mapper.Map<List<ReadTransactionDTO>>(result);
        }

        public async Task<ICollection<ReadTransactionDTO>> GetFilterdTransaction(TransactionFilterDTO filterDTO)
        {
            // todo finish filter
            var result = await _repository.GetAllTransaction();
            var filterdResult = result;
            return _mapper.Map<List<ReadTransactionDTO>>(filterdResult);
        }
    }
}

