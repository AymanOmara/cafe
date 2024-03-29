using cafe.Domain.Order.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cafe.infrastructure.Features.Order.EntityConfiguration
{
	public class OrderItemEntityConfiguration: IEntityTypeConfiguration<OrderItemEntity>
	{
		public OrderItemEntityConfiguration()
		{

		}

        public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {
            builder.Ignore(item => item.TotalPrice);

            builder.Property(item => item.Count)
                .IsRequired();

            builder.Property(item => item.ItemPrice)
                .IsRequired();

        }
    }
}

