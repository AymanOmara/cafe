using Microsoft.AspNetCore.Identity;

namespace cafe.Domain.Users.entity
{
    public class CafeUser : IdentityUser
    {
        public String Token { get; set; } = String.Empty;

        public String RefreshToken { get; set; } = String.Empty;

    }
}

