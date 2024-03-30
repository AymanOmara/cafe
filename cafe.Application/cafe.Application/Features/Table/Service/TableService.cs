using AutoMapper;
using cafe.Domain.Common;
using cafe.Domain.Table.DTO;
using cafe.Domain.Table.Repository;
using cafe.Domain.Table.Service;

namespace cafe.Application.Features.Table.Service
{
	public class TableService: ITableService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public TableService(IMapper mapper, IUnitOfWork unitOfWork)
		{
            _mapper = mapper;
            _unitOfWork = unitOfWork;
		}

        public async Task<ICollection<ReadTableDTO>> GetAllTables()
        {
            var result = await _unitOfWork.Tables.GetAllTables();
            return _mapper.Map<List<ReadTableDTO>>(result.Where(table => !table.Deleted).ToList());
        }
    }
}

