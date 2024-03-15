namespace cafe.Domain.Employee
{
	public class EmployeeEntity
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public int BaseSalary { get; set; }

		public string PhoneNumber { get; set; } = string.Empty;

		public ICollection<SalaryDeductionEntity>? Deductions { get; set; }

		public ICollection<SalaryIncentiveEntity>? Incentive { get; set; }
    }
}

