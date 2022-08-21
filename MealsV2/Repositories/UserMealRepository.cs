using MealsV2.Interfaces;
using MealsV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MealsV2.Repositories
{
    public class UserMealRepository:IUserMealRepository
    {
        private readonly FitnessContext context;

        public UserMealRepository(FitnessContext context)
        {
            this.context = context;
        }
        public async Task<List<UserMeal>> GetAllUserMeals(int? id)
        {
            return await context.UserMeals.Where(m=>m.UserId==id).ToListAsync();
        }

        public async Task<UserMeal> InsertUserMeal(UserMeal userMeal)
        {
            await context.UserMeals.AddAsync(userMeal);
            await context.SaveChangesAsync();
            return userMeal;
        }
    }
}
