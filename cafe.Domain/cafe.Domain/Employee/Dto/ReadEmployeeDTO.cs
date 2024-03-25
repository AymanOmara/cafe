namespace cafe.Domain.Employee.Dto
{
    public class ReadEmployeeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int BaseSalary { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string DeliverdPapers { get; set; } = string.Empty;

        public ICollection<ReadSalaryItemDto>? Deductions { get; set; }

        public ICollection<ReadSalaryItemDto>? Incentive { get; set; }

        public ICollection<ReadAdvancePaymentDTO>? Advance { get; set; }
        

        public decimal FinalSalary {get; set;}
    }
}

