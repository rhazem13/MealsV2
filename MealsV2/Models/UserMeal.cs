using System;
using System.Collections.Generic;

namespace MealsV2.Models
{
    public partial class UserMeal
    {
        public int UserId { get; set; }
        public int MealId { get; set; }
        public int? MainCatId { get; set; }
        public int? Quantity { get; set; }
        public DateTime UserMealDate { get; set; }

        public virtual MainCat? MainCat { get; set; }
        public virtual Meal Meal { get; set; } = null!;
        public virtual UserDatum User { get; set; } = null!;
    }
}
