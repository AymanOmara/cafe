using cafe.Domain.Shift.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cafe.infrastructure.Features.Shift.EntityConfiguration
{
    public class ShiftEntityConfiguration : IEntityTypeConfiguration<ShiftEntity>
	{
		public ShiftEntityConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<ShiftEntity> builder)
        {
            builder
                .HasMany(x => x.Orders)
                .WithOne(x=> x.ShiftEntity);

            builder
                .Ignore(shift => shift.TotalRevenue);
        }
    }
}

