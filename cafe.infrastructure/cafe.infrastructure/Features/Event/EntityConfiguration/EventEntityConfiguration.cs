
using cafe.Domain.Event.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cafe.infrastructure.Features.Event.EntityConfiguration
{
    public class EventEntityConfiguration : IEntityTypeConfiguration<EventEntity>
	{
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.Ignore(entity=> entity.RemainingAmount);
            builder.Property(prop => prop.ClientName).IsRequired();
            builder.Property(prop => prop.Price).IsRequired();
            builder.Property(prop => prop.CreatedDate).IsRequired();
            builder.Property(prop => prop.RservationDate).IsRequired();
            builder.Property(prop => prop.ClientPhoneNumber).IsRequired();
        }
    }
}

