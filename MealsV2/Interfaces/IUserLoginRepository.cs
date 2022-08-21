using MealsV2.Models;

namespace MealsV2.Interfaces
{
    public interface IUserLoginRepository
    {
        public Task<UserLogin> CreateUserLoginAsync(UserLogin userLogin);
        public Task<UserLogin> GetUserLoginByEmailAsync(string email);
    }
}
