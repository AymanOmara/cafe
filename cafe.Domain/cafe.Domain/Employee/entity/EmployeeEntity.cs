using cafe.Domain.Employee.entity;

namespace cafe.Domain.Employee
{
    public class EmployeeEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int BaseSalary { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string DeliverdPapers { get; set; } = string.Empty;

        public ICollection<SalaryDeductionEntity>? Deductions { get; set; }

        public ICollection<PayAdvance>? Advance { get; set; }

        public ICollection<SalaryIncentiveEntity>? Incentive { get; set; }

        public decimal FinalSalary
        {
            get
            {
                decimal finalSalary = BaseSalary;

                if (Incentive != null)
                    finalSalary += Incentive.Sum(inc => inc?.Amount ?? 0);

                if (Advance != null)
                    finalSalary -= Advance.Sum(adv => adv?.Amount ?? 0);

                if (Deductions != null)
                    finalSalary -= Deductions.Sum(ded => ded?.Amount ?? 0);

                return finalSalary;
            }
        }
    }
}

