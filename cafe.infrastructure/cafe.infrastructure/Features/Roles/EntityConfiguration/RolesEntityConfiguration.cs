using cafe.Domain.Users.entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cafe.infrastructure.Features.Roles.EntityConfiguration
{
    public class RolesEntityConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public RolesEntityConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            foreach (int i in Enum.GetValues(typeof(CafeRoles)))
            {
                var roleName = Enum.GetName(typeof(CafeRoles), i);
                builder.HasData(new IdentityRole() { Id = $"{i}", Name = roleName, NormalizedName = roleName });
            }
            
        }
    }
}

