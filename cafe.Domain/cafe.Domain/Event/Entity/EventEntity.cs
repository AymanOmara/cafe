namespace cafe.Domain.Event.Entity
{
	public class EventEntity
	{
		public int Id { get; set; }

		public decimal Price { get; set; }

        public decimal Deposit { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime RservationDate { get; set; }

        public string ClientName { get; set; } = string.Empty;

		public string Prerequisites { get; set; } = string.Empty;

		public string ClientPhoneNumber { get; set; } = string.Empty;

		public string CancelationReason { get; set; } = string.Empty;

        public decimal RemainingAmount
        {
            get { return Price - Deposit; }
        }
        public bool CheckOut { get; set; }

        public bool Deleted { get; set; }
    }
}