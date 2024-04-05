using cafe.Domain.Users.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cafe.infrastructure.Features.User.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<CafeUser>
    {
        public UserEntityConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<CafeUser> builder)
        {
            builder
                .HasQueryFilter(us => !us.Deleted);
        }
    }
}

