using AutoMapper;
using cafe.Domain.Table.DTO;
using cafe.Domain.Table.Repository;
using cafe.Domain.Table.Service;

namespace cafe.Application.Features.Table.Service
{
	public class TableService: ITableService
    {
        private readonly IMapper _mapper;
        private readonly ITableRepository _repository;
		public TableService(IMapper mapper,ITableRepository repository)
		{
            _mapper = mapper;
            _repository = repository;
		}

        public ICollection<ReadTableDTO> GetAllTables()
        {
            var result = _repository.GetAllTables().Where(table => !table.Deleted).ToList();
            return _mapper.Map<List<ReadTableDTO>>(result);
        }
    }
}

