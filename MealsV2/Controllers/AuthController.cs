using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using MealsV2.Classes;
using MealsV2.Interfaces;
using MealsV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MealsV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserDatumRepository userDatumRepository;
        private readonly IUserLoginRepository userLoginRepository;
        private readonly IConfiguration configuration;
        public AuthController(IUserDatumRepository userDatumRepository,IUserLoginRepository userLoginRepository,IConfiguration configuration)
        {
            this.userDatumRepository = userDatumRepository;
            this.userLoginRepository = userLoginRepository;
            this.configuration = configuration;
        }

        //testing if we can get user info using identity
        //[HttpGet, Authorize]
        //public ActionResult<UserDatum> GetMe()
        //{
        //    UserLogin user = context.UserLogins.Find(User?.Identity?.Name);
        //    UserDatum userDatum = context.UserData.Find(user.UserId);
        //    return Ok(userDatum);
        //}


        [HttpPost("register")]
        public async Task<ActionResult<UserDatum>> Register(UserRegisterDto request)
        {
            UserLogin userLogin=new UserLogin();
            UserDatum userDatum=new UserDatum
            {
                ActivityLevel = request.ActivityLevel,
                Age = request.Age,
                Gender = request.Gender,
                Height = request.Height,
                Name = request.Name,
                Nationality = request.Nationality,
                RecommendedCalories = 3000
            };
            await userDatumRepository.CreateUserDatumAsync(userDatum);

            CreatePasswordHash(request.Password,out byte[] passwordHash,out byte[] passwordSalt);
            userLogin.Email=request.Email;
            userLogin.PasswordHash=passwordHash;
            userLogin.PasswordSalt=passwordSalt;
            userLogin.UserId=userDatum.UserId;
            await userLoginRepository.CreateUserLoginAsync(userLogin);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginDto request)
        {
            UserLogin user = await userLoginRepository.GetUserLoginByEmailAsync(request.Email);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("wrong password");
            }

            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(UserLogin user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims:claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac= new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }


    }
}
