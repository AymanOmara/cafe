using cafe.Domain.Meal;

namespace cafe.Domain.Order.Entity
{
    public class OrderItemEntity
    {
        public int Id { get; set; }

        public MealEntity? Meal { get; set; }

        public int Count { get; set; }

        public decimal ItemPrice { get; set; }

        public decimal TotalPrice
        {
            get { return ItemPrice * Count; }
        }
    }
}

