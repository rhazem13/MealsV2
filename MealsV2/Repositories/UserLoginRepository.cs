using MealsV2.Interfaces;
using MealsV2.Models;

namespace MealsV2.Repositories
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly FitnessContext context;

        public UserLoginRepository(FitnessContext context)
        {
            this.context = context;
        }
        public async Task<UserLogin> CreateUserLoginAsync(UserLogin userLogin)
        {
            context.UserLogins.Add(userLogin);
            await context.SaveChangesAsync();
            return userLogin;
        }

        public async Task<UserLogin> GetUserLoginByEmailAsync(string email)
        {
            return await context.UserLogins.FindAsync(email);
        }
    }
}
