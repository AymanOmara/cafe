namespace cafe.Domain.Shift.DTO
{
	public class ReadShiftsDTO
	{
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndTime { get; set; }

        public bool Closed { get; set; }

        public decimal TotalRevenue { get; set; }

    }
}

