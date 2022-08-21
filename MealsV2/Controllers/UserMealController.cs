using MealsV2.Classes;
using MealsV2.Interfaces;
using MealsV2.Models;
using MealsV2.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealsV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMealController : ControllerBase
    {
        private readonly IUserMealRepository userMealRepository;
        private readonly IUserService userService;

        public UserMealController(IUserMealRepository userMealRepository,IUserService userService)
        {
            this.userMealRepository = userMealRepository;
            this.userService = userService;
        }

        [HttpGet("GetAllUserMeals"),Authorize]
        public async Task<ActionResult<List<UserMeal>>> Meals()
        {
            var userId = userService.GetMyId();
            return Ok(await userMealRepository.GetAllUserMeals(userId));
        }

        [HttpPost("InsertMeal"), Authorize]
        public async Task<ActionResult<UserMeal>> InsertMeal(InsertUserMealDto userMeal)
        {
            UserMeal MyUserMeal = new UserMeal
            {
                MealId = userMeal.MealId,
                MainCatId = userMeal.MainCatId,
                Quantity = userMeal.Quantity,
                UserId = userService.GetMyId()??1,
                UserMealDate = DateTime.Now
            };
            await userMealRepository.InsertUserMeal(MyUserMeal);

            return Ok(MyUserMeal);
        }


    }
}
