using System.ComponentModel.DataAnnotations;

namespace cafe.Domain.Client.DTO
{
	public class UpdateClientDTO
	{
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Preference { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public bool IsVIP { get; set; }
    }
}

