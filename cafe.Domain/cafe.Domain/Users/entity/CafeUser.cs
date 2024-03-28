using Microsoft.AspNetCore.Identity;

namespace cafe.Domain.Users.entity
{
    public class CafeUser : IdentityUser
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
}

