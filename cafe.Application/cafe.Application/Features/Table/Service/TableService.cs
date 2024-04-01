using AutoMapper;
using cafe.Common;
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
        private readonly LanguageService _localization;
        public TableService(IMapper mapper, IUnitOfWork unitOfWork, LanguageService localization)
		{
            _mapper = mapper;

            _unitOfWork = unitOfWork;

            _localization = localization;
		}

        public async Task<ICollection<ReadTableDTO>> GetAllTables()
        {
            var result = await _unitOfWork.Tables.GetAllTables();
            return _mapper.Map<List<ReadTableDTO>>(result.Where(table => !table.Deleted).ToList());
        }
    }
}

