using System;
using System.Collections.Generic;

namespace MealsV2.Models
{
    public partial class MainCat
    {
        public MainCat()
        {
            UserMeals = new HashSet<UserMeal>();
        }

        public int MainCatId { get; set; }
        public string? CatName { get; set; }

        public virtual ICollection<UserMeal> UserMeals { get; set; }
    }
}
