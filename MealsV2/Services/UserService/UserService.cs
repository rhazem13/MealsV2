using System.Security.Claims;
using MealsV2.Models;

namespace MealsV2.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly FitnessContext context;

        public UserService(IHttpContextAccessor httpContextAccessor,FitnessContext context)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.context = context;
        }
        public int? GetMyId()
        {
            var result = string.Empty;
            if (httpContextAccessor != null)
            {
                result = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            UserLogin user = context.UserLogins.Find(result);
            if (user == null)
            {
                return -1;
            }
            return user.UserId;
        }
    }
}
