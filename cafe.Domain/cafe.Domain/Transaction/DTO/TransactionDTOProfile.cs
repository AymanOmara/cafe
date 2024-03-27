using AutoMapper;
using cafe.Domain.Transaction.Entity;

namespace cafe.Domain.Transaction.DTO
{
	public class TransactionDTOProfile:Profile
	{
		public TransactionDTOProfile()
		{
            CreateMap<TransactionEntity, ReadTransactionDTO>();
		}
	}
}

