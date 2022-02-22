using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Models;
using TwoTaskWebAPI.JwtHelpers;
using TwoTaskLibrary.Internal.DataAccess;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        public AccountController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        
        [HttpPost]
        public IActionResult Login(UserLoginModel userLogin)
        {
            SqlDataAccess _sql = new SqlDataAccess();
            var users = _sql.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new {  }, "ConnectionStrings:TwoTaskData");
            var Token = new UserToken();
            if (users != null)
            {                
                var validUserName = users.Any(x => x.UserName.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                if (validUserName)
                {
                    var validPassword = users.Any(x => x.Password.Equals(userLogin.Password, StringComparison.OrdinalIgnoreCase));
                    if(validPassword)
                    {
                        var user = users.FirstOrDefault(x => x.UserName.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                        Token = JwtHelper.GenTokenkey(new UserToken()
                        {
                            Email = user.Email,
                            UserName = user.UserName,
                            Id = user.Id,
                        }, _jwtSettings);
                        return Ok(Token);
                    }
                    else
                    {
                        return BadRequest($"wrong password");
                    }
                    
                }
                else
                {
                    return BadRequest($"wrong username");
                }
                
            }
            else
                return BadRequest($"there is no user");

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetAllUsers()
        {
            SqlDataAccess _sql = new SqlDataAccess();
            var users = _sql.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { }, "ConnectionStrings:TwoTaskData");
            return Ok(users);
        }
    }
}
