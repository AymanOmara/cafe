namespace cafe.Domain.Event.DTO
{
	public class UpdateEventDTO
	{
        public int Id { get; set; }

        public decimal Price { get; set; }

        public decimal Deposit { get; set; }

        public DateTime RservationDate { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public string Prerequisites { get; set; } = string.Empty;

        public string ClientPhoneNumber { get; set; } = string.Empty;

        public string CancelationReason { get; set; } = string.Empty;

        public bool CheckOut { get; set; }
    }
}