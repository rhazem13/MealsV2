using MealsV2.Interfaces;
using MealsV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealsV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealRepository mealRepository;

        public MealController(IMealRepository mealRepository)
        {
            this.mealRepository = mealRepository;
        }

        [HttpGet("GetAll"),Authorize]
        public async Task<ActionResult<List<Meal>>> Meals()
        {
            return Ok(await mealRepository.GetAllMeals());
        }
    }
}
