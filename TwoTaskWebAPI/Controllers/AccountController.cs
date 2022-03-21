using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Models;
using TwoTaskWebAPI.JwtHelpers;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using TwoTaskLibrary.Application;
using TwoTaskWebAPI.Extensions;
using TwoTaskLibrary.Services;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;
        private readonly AccountExtension _extension;
        private readonly ISqlDataFactory _sqlDataFactory;

        public AccountController(JwtSettings jwtSettings, ILogger<AccountController> logger, ISqlDataFactory sqlDataFactory, IAccountService accountService)
        {
            _jwtSettings = jwtSettings;
            _logger = logger;
            _sqlDataFactory = sqlDataFactory;
            _accountService = accountService;
            _extension = new AccountExtension(_jwtSettings, _sqlDataFactory);
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel register)
        {
            if(_accountService.RegisterUser(register) == null) 
                return BadRequest("UserName Is Already Taken");
            else
            {
                return Ok();
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
            return Ok(_accountService.GetAllUsers());
        }
    }
}
