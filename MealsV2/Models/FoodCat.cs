using System;
using System.Collections.Generic;

namespace MealsV2.Models
{
    public partial class FoodCat
    {
        public FoodCat()
        {
            Meals = new HashSet<Meal>();
        }

        public int FoodCatId { get; set; }
        public string? FoodName { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
