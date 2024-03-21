namespace cafe.Domain.Client.Entity
{
    public class ClientEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Preference { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; } = string.Empty;

        public bool IsVIP { get; set; }
    }
}

