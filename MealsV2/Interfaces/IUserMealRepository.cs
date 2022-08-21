using MealsV2.Models;

namespace MealsV2.Interfaces
{
    public interface IUserMealRepository
    {
        public Task<List<UserMeal>> GetAllUserMeals(int? id);
        public Task<UserMeal> InsertUserMeal(UserMeal userMeal);

    }
}
