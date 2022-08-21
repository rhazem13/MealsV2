using MealsV2.Interfaces;
using MealsV2.Models;
using Microsoft.EntityFrameworkCore;

namespace MealsV2.Repositories
{
    public class MealRepository:IMealRepository
    {
        private readonly FitnessContext context;

        public MealRepository(FitnessContext context)
        {
            this.context = context;
        }
        public async Task<List<Meal>> GetAllMeals()
        {
            return await context.Meals.ToListAsync();
        }
    }
}
