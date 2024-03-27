using cafe.Domain.Employee;
using cafe.Domain.Employee.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cafe.infrastructure.Features.Employee.EntityConfiguration
{
    public class SalaryItemConfiguration : IEntityTypeConfiguration<SalaryItemEntity>
    {
        public void Configure(EntityTypeBuilder<SalaryItemEntity> builder)
        {
            builder.Property(e => e.Amount)
                .IsRequired()
                .HasMaxLength(256);

            builder
                 .HasDiscriminator<string>("Discriminator")
                 .HasValue<SalaryIncentiveEntity>("SalaryIncentive")
                 .HasValue<PayAdvance>("PayAdvance")
                 .HasValue<SalaryDeductionEntity>("SalaryDeduction");
        }
    }
}

