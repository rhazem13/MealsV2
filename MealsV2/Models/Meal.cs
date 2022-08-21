using System;
using System.Collections.Generic;

namespace MealsV2.Models
{
    public partial class Meal
    {
        public Meal()
        {
            UserMeals = new HashSet<UserMeal>();
        }

        public int MealId { get; set; }
        public int? FoodCatId { get; set; }
        public int? Calories { get; set; }
        public bool? IsCountable { get; set; }
        public string? Name { get; set; }

        public virtual FoodCat? FoodCat { get; set; }
        public virtual ICollection<UserMeal> UserMeals { get; set; }
    }
}
