using MealsV2.Models;

namespace MealsV2.Interfaces
{
    public interface IUserDatumRepository
    {
        public Task<UserDatum> CreateUserDatumAsync(UserDatum userDatum);

        public Task<UserDatum> GetUserDatumAsync(int id);
        public Task<UserDatum> UpdateUserDatumAsync(UserDatum userDatum);
    }
}
