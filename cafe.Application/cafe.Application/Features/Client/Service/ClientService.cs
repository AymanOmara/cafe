using AutoMapper;
using cafe.Domain.Client.DTO;
using cafe.Domain.Client.Entity;
using cafe.Domain.Client.Repository;
using cafe.Domain.Client.Service;
using cafe.Domain.Table.Entity;
using cafe.Domain.Table.Repository;

namespace cafe.Application.Features.Client.Service
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;

        private readonly IClientRepository _clientRepository;

        private readonly ITableRepository _tableRepository;

        public ClientService(IMapper mapper, IClientRepository repository, ITableRepository tableRepository)
        {
            _mapper = mapper;
            _clientRepository = repository;
            _tableRepository = tableRepository;
        }

        public async Task<ReadClientDTO> AddClient(WriteClientDTO dto)
        {

            var clientEntity = _mapper.Map<ClientEntity>(dto);

            var result = await _clientRepository.Create(clientEntity);

            if (dto.IsVIP)
            {
                var tableEntity = _mapper.Map<TableEntity>(dto);
                tableEntity.Client = result;
                tableEntity.LobbyName = LobbyName.Specail;
                _tableRepository.CreateTable(tableEntity);
            }
            return _mapper.Map<ReadClientDTO>(result);
        }

        public async Task DeleteClient(UpdateClientDTO dto)
        {
            var assocaitedTable = await _tableRepository.GetTableByClientId(dto.Id);

            if (assocaitedTable == null)
            {
                var clientEntity = _mapper.Map<ClientEntity>(dto);

                await _clientRepository.Delete(clientEntity);
            }
            else
            {
                await _tableRepository.ChangeDeleteStatus(assocaitedTable.Id, true);
                await _clientRepository.MarkClientDeleted(assocaitedTable.Client);
            }
        }

        public async Task<ICollection<ReadClientDTO>> GetAllClients()
        {
            var result = await _clientRepository.GetAllRecords();
            return _mapper.Map<List<ReadClientDTO>>(result.Where(client => !client.Deleted));
        }

        public async Task<ReadClientDTO> UpdateClient(UpdateClientDTO dto)
        {
            var clientEntity = _mapper.Map<ClientEntity>(dto);
            var result = await _clientRepository.Update(clientEntity);
            var assocaitedTable = await _tableRepository.GetTableByClientId(dto.Id);

            if (dto.IsVIP && assocaitedTable == null)
            {
                var tableEntity = _mapper.Map<TableEntity>(dto);
                tableEntity.LobbyName = LobbyName.Specail;
                _tableRepository.CreateTable(tableEntity);
            }
            else
            {
                await _tableRepository.ChangeDeleteStatus(assocaitedTable.Id, !dto.IsVIP);
            }

            return _mapper.Map<ReadClientDTO>(result);
        }
    }
}

