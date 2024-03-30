using System.ComponentModel.DataAnnotations;

namespace cafe.Domain.Users.DTO
{
	public class LoginDTO
	{
		[Required]
		public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

