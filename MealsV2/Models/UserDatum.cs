using System;
using System.Collections.Generic;

namespace MealsV2.Models
{
    public partial class UserDatum
    {
        public UserDatum()
        {
            UserLogins = new HashSet<UserLogin>();
            UserMeals = new HashSet<UserMeal>();
        }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public string? Nationality { get; set; }
        public byte? ActivityLevel { get; set; }
        public int? RecommendedCalories { get; set; }

        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<UserMeal> UserMeals { get; set; }
    }
}
