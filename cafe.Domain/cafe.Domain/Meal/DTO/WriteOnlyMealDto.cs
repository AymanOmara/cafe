﻿using System.ComponentModel.DataAnnotations;

namespace cafe.Domain.Meal.DTO
{
	public class WriteOnlyMealDto
	{
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
