using MealsV2.Interfaces;
using MealsV2.Models;

namespace MealsV2.Repositories
{
    public class UserDatumRepository:IUserDatumRepository
    {
        private readonly FitnessContext context;

        public UserDatumRepository(FitnessContext context)
        {
            this.context = context;
        }
        public async Task<UserDatum> CreateUserDatumAsync(UserDatum userDatum)
        {
            context.UserData.Add(userDatum);
            await context.SaveChangesAsync();
            return userDatum;
        }

        public async Task<UserDatum> GetUserDatumAsync(int id)
        {
            return await context.UserData.FindAsync(id);
        }

        public async Task<UserDatum> UpdateUserDatumAsync(UserDatum userDatum)
        {
            var myUser = context.UserData.FirstOrDefault(u => u.UserId == userDatum.UserId);
            if (myUser != null)
            {
                myUser.ActivityLevel = userDatum.ActivityLevel;
                myUser.Name = userDatum.Name;
                myUser.Age=userDatum.Age;
                myUser.Gender=userDatum.Gender;
                myUser.Height=userDatum.Height;
                myUser.Weight=userDatum.Weight;
                myUser.Nationality=userDatum.Nationality;
                myUser.RecommendedCalories=userDatum.RecommendedCalories;
                await context.SaveChangesAsync();
            }

            return myUser;
        }
    }
}
