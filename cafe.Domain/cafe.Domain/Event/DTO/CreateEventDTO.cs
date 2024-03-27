using System.ComponentModel.DataAnnotations;

namespace cafe.Domain.Event.DTO
{
	public class CreateEventDTO
	{
        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Deposit { get; set; }

        [Required]
        public DateTime RservationDate { get; set; }

        [Required]
        public string ClientName { get; set; } = string.Empty;

        [Required]
        public string Prerequisites { get; set; } = string.Empty;

        [Required]
        public string ClientPhoneNumber { get; set; } = string.Empty;
    }
}

