using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Models;
using TwoTaskWebAPI.JwtHelpers;
using TwoTaskLibrary.Internal.DataAccess;
using System.Security.Cryptography;
using System.Text;
using TwoTaskLibrary.Application;
using TwoTaskWebAPI.Extensions;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly SqlDataAccess _sql;
        protected IAccountRepository Data { get; set; }
        private readonly ILogger<AccountRepository> _logger;
        private AccountExtension _extension;

        public AccountController(JwtSettings jwtSettings, ILogger<AccountRepository> logger)
        {
            _jwtSettings = jwtSettings;
            _sql = new SqlDataAccess();
            _logger = logger;
            Data = new AccountRepository(_sql, _logger);
            _extension = new AccountExtension(_jwtSettings, _sql, _logger);
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel register)
        {
            if(Data.IsUserNameIsTaken(register.Username)) 
                return BadRequest("UserName Is Already Taken");
            else
            {                
                var result = Data.Register(register);
                return !result ? (IActionResult)NoContent() : Ok();
            }           
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel userLogin)
        {
            var user = _extension.IsUserNameFound(userLogin);
            if (user != null)
            {
                if (_extension.IsPasswordValid(userLogin, user))
                {
                    return Ok(_extension.GenerateToken(user));
                }
                else
                    return Unauthorized("Bad credentials");
            }                   
            else
                return BadRequest($"User not found");

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetAllUsers()
        {
            return Ok(Data.GetAllUsers());
        }
    }
}
