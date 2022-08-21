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
    public class UserDatumController : ControllerBase
    {
        private readonly IUserDatumRepository userDatumRepository;
        private readonly IUserService userService;

        public UserDatumController(IUserDatumRepository userDatumRepository, IUserService userService)
        {
            this.userDatumRepository = userDatumRepository;
            this.userService = userService;
        }

        [HttpGet("UserInfo"), Authorize]
        public async Task<UserDatum> GetUserDatum()
        {
            int id = userService.GetMyId() ?? -1;
            return await userDatumRepository.GetUserDatumAsync(id);

        }

        [HttpPost("UpdateUserInfo"), Authorize]
        public async Task<UserDatum> UpdateUserDatum(UserDatum userDatum)
        {
            UserDatum userDatumToUpdate = await userDatumRepository.UpdateUserDatumAsync(userDatum);
            return userDatumToUpdate;
        }

    }
}
