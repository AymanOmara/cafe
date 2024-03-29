using cafe.Domain.Order.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cafe.infrastructure.Features.Order.EntityConfiguration
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
	{
		public OrderEntityConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder
                .Ignore(order => order.TotalPrice);
        }
    }
}

