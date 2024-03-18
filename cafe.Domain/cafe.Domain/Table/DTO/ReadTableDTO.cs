using cafe.Domain.Table.Entity;

namespace cafe.Domain.Table.DTO
{
	public class ReadTableDTO
	{
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public LobbyName LobbyName { get; set; }
    }
}

