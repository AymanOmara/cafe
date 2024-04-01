using AutoMapper;
using cafe.Common;
using cafe.Domain.Client.DTO;
using cafe.Domain.Client.Entity;
using cafe.Domain.Client.Service;
using cafe.Domain.Common;
using cafe.Domain.Table.Entity;

namespace cafe.Application.Features.Client.Service
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        private readonly LanguageService _localization;

        public ClientService(IMapper mapper, IUnitOfWork unitOfWork, LanguageService localization)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<ReadClientDTO> AddClient(WriteClientDTO dto)
        {

            var clientEntity = _mapper.Map<ClientEntity>(dto);

            var result = await _unitOfWork.Clients.Create(clientEntity);

            if (dto.IsVIP)
            {
                var tableEntity = _mapper.Map<TableEntity>(dto);
                tableEntity.Client = result;
                tableEntity.LobbyName = LobbyName.Specail;
                _unitOfWork.Tables.CreateTable(tableEntity);
            }
            return _mapper.Map<ReadClientDTO>(result);
        }

        public async Task DeleteClient(UpdateClientDTO dto)
        {
            var assocaitedTable = await _unitOfWork.Tables.GetTableByClientId(dto.Id);

            if (assocaitedTable == null)
            {
                var clientEntity = _mapper.Map<ClientEntity>(dto);

                await _unitOfWork.Clients.Delete(clientEntity);
            }
            else
            {
                await _unitOfWork.Tables.ChangeDeleteStatus(assocaitedTable.Id, true);
                await _unitOfWork.Clients.MarkClientDeleted(assocaitedTable.Client);
            }
        }

        public async Task<ICollection<ReadClientDTO>> GetAllClients()
        {
            var result = await _unitOfWork.Clients.GetAllRecords();
            return _mapper.Map<List<ReadClientDTO>>(result.Where(client => !client.Deleted));
        }

        public async Task<ReadClientDTO> UpdateClient(UpdateClientDTO dto)
        {
            var clientEntity = _mapper.Map<ClientEntity>(dto);
            var result = await _unitOfWork.Clients.Update(clientEntity);
            var assocaitedTable = await _unitOfWork.Tables.GetTableByClientId(dto.Id);

            if (dto.IsVIP && assocaitedTable == null)
            {
                var tableEntity = _mapper.Map<TableEntity>(dto);
                tableEntity.LobbyName = LobbyName.Specail;
                _unitOfWork.Tables.CreateTable(tableEntity);
            }
            else
            {
                await _unitOfWork.Tables.ChangeDeleteStatus(assocaitedTable.Id, !dto.IsVIP);
            }

            return _mapper.Map<ReadClientDTO>(result);
        }
    }
}

