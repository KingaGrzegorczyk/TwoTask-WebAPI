using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Models;
using TwoTaskWebAPI.JwtHelpers;
using TwoTaskLibrary.Internal.DataAccess;
using System.Security.Cryptography;
using System.Text;
using TwoTaskLibrary.Application;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly SqlDataAccess _sql;
        protected IAccountRepository Data { get; set; }

        public AccountController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _sql = new SqlDataAccess();
            Data = new AccountRepository(_sql);
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel register)
        {
            if(Data.CheckIfUserExists(register.Username)) 
                return BadRequest("UserName Is Already Taken");
            else
            {
                var hmac = new HMACSHA512();

                var user = new UserModel
                {
                    Id = Guid.NewGuid(),
                    UserName = register.Username.ToLower(),
                    Email = register.Email,
                    Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password.ToCharArray())),
                    PasswordSalt = hmac.Key
                };
                Data.Register(user);
                return Ok();
            }           
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel userLogin)
        {
            var users = Data.GetAllUsers();
            var Token = new UserToken();
            if (users != null)
            {
                var user = users.FirstOrDefault(x => x.UserName == userLogin.UserName);

                if (user == null) 
                    return Unauthorized("Invalid UserName");
                else
                {
                    var hmac = new HMACSHA512(user.PasswordSalt);

                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLogin.Password.ToCharArray()));

                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != user.Password[i]) 
                            return Unauthorized("Invalid Password");
                    }
                    Token = JwtHelper.GenTokenkey(new UserToken()
                    {
                        Email = user.Email,
                        UserName = user.UserName,
                        Id = user.Id,
                    }, _jwtSettings);
                    return Ok(Token);

                }            
                
            }
            else
                return BadRequest($"there is no user");

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetAllUsers()
        {
            return Ok(Data.GetAllUsers());
        }
    }
}
