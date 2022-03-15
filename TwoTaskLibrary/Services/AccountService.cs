using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Services
{
    public interface IAccountService
    {
        UserModel RegisterUser(UserRegisterModel register);
        IEnumerable<UserModel> GetAllUsers();
    }

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public UserModel RegisterUser(UserRegisterModel register)
        {
            if (_accountRepository.IsUserNameIsTaken(register.Username))
                return null;

            var hmac = new HMACSHA512();

            var user = new UserModel
            {
                Id = Guid.NewGuid(),
                UserName = register.Username.ToLower(),
                Email = register.Email,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password.ToCharArray())),
                PasswordSalt = hmac.Key
            };

            _accountRepository.Register(register); 


            return user;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            IEnumerable<UserModel> users = _accountRepository.GetAllUsers();

            return users;
        }
    }
}
