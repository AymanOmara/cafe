using System.ComponentModel.DataAnnotations;

namespace cafe.Domain.Users.DTO
{
	public class RegistrationDTO
	{
		[Required]
		public String Email { get; set; } = null!;

        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public int Role { get; set; }

    }
}

