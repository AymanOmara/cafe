using cafe.Domain.Category.DTO;

namespace cafe.Domain.Employee.Dto
{
	public class CreateEmployeeDTO
	{
        public string Name { get; set; } = string.Empty;

        public int BaseSalary { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string DeliverdPapers { get; set; } = string.Empty;

        public ICollection<WriteSalaryItemDTO>? Deductions { get; set; }

        public ICollection<WriteSalaryItemDTO>? Incentive { get; set; }
    }
}

