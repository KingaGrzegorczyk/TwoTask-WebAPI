using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Services
{
    public class AccountService
    {
        private readonly SqlDataAccess _sql;

        public AccountService(SqlDataAccess sql)
        {
            _sql = sql;
        }
        public UserModel RegisterUser(UserRegisterModel register)
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

            return user;
        }      
    }
}
