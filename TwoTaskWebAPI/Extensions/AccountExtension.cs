using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Models;
using TwoTaskWebAPI.JwtHelpers;

namespace TwoTaskWebAPI.Extensions
{
    public class AccountExtension
    {
        private readonly SqlDataFactory _sqlDataFactory;
        private readonly JwtSettings _jwtSettings;
        public AccountExtension(JwtSettings jwtSettings, SqlDataFactory sqlDataFactory)
        {
            _jwtSettings = jwtSettings;
            _sqlDataFactory = sqlDataFactory;
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
            var Data = new AccountRepository(_sqlDataFactory);
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
