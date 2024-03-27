using cafe.Domain.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cafe.infrastructure.Features.Employee.EntityConfiguration
{
    public class EmployeeConiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
		public EmployeeConiguration()
		{
		}

        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.Ignore(emp => emp.FinalSalary);
        }
    }
}

