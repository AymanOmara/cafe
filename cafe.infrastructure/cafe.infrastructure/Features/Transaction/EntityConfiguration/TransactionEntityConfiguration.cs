using cafe.Domain.Transaction.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cafe.infrastructure.Features.Transaction.EntityConfiguration
{
    public class TransactionEntityConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {

            builder
                .Property(prop => prop.Amount)
                .IsRequired();

            builder
                .Property(prop => prop.TransactionType)
                .IsRequired();

        }
    }
}

