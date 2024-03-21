using AutoMapper;
using cafe.Domain.Client.Entity;
using cafe.Domain.Table.Entity;

namespace cafe.Domain.Client.DTO
{
	public class ClientProfile : Profile
	{
		public ClientProfile()
		{
			CreateMap<ClientEntity,ReadClientDTO>().ReverseMap();
           
			CreateMap<WriteClientDTO,ClientEntity>();

			CreateMap<WriteClientDTO,TableEntity>().ReverseMap();

            CreateMap<UpdateClientDTO, ClientEntity>();

			CreateMap<UpdateClientDTO, TableEntity>();
        }
	}
}

