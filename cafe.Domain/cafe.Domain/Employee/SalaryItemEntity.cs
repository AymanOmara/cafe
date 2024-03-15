namespace cafe.Domain.Employee
{
    public class SalaryItemEntity
    {
        public int Id { get; set; }

        public string Reason { get; set; } = string.Empty;

        public DateTime Data { get; set; } = DateTime.Now;

        public int Amount { get; set; }
    }
}

