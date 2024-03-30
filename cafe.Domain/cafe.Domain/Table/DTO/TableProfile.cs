using AutoMapper;
using cafe.Domain.Table.Entity;

namespace cafe.Domain.Table.DTO
{
	public class TableProfile: Profile
	{
		public TableProfile()
		{
			CreateMap<TableEntity, ReadTableDTO>().ReverseMap();
		}
	}
}

