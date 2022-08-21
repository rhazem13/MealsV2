using MealsV2.Models;

namespace MealsV2.Interfaces
{
    public interface IMealRepository
    {
        public Task<List<Meal>> GetAllMeals();

    }
}
