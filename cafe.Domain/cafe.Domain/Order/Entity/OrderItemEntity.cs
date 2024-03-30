using System.ComponentModel.DataAnnotations.Schema;
using cafe.Domain.Meal;

namespace cafe.Domain.Order.Entity
{
    public class OrderItemEntity
    {
        public int Id { get; set; }

        [ForeignKey("MealId")]
        public int? MealId { get; set; }

        public MealEntity? Meal { get; set; }

        public int Count { get; set; }

        public decimal ItemPrice { get; set; }

        public decimal TotalPrice
        {
            get { return ItemPrice * Count; }
        }
    }
}

