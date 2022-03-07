using System.Security.Cryptography;
using System.Text;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;
using TwoTaskWebAPI.JwtHelpers;

namespace TwoTaskWebAPI.Extensions
{
    public class AccountExtension
    {
        private readonly JwtSettings _jwtSettings;
        private readonly SqlDataAccess _sql;
        private readonly ILogger<AccountRepository> _logger;
        public AccountExtension(JwtSettings jwtSettings, SqlDataAccess sql, ILogger<AccountRepository> logger)
        {
            _jwtSettings = jwtSettings;
            _sql = sql;
            _logger = logger;
        }
        public UserToken? GenerateToken(UserModel user)
        {
            var Token = JwtHelper.GenTokenkey(new UserToken()
            {
                Email = user.Email,
                UserName = user.UserName,
                Id = user.Id,
            }, _jwtSettings);

            return Token;
        }

        public bool IsPasswordValid(UserLoginModel userLogin, UserModel user)
        {
            var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLogin.Password.ToCharArray()));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.Password[i])
                    return false;
            }

            return true;
        }

        public UserModel? IsUserNameFound(UserLoginModel userLogin)
        {
            var Data = new AccountRepository(_sql, _logger);
            var users = Data.GetAllUsers();
            if (users != null)
            {
                var user = users.FirstOrDefault(x => x.UserName == userLogin.UserName);
                if (user != null)
                    return user;
                else
                    return null;
            }
            else
                return null;
        }
    }
}
