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
        private readonly ISecurityService _securityService;

        public AccountService(IAccountRepository accountRepository, ISecurityService securityService)
        {
            _accountRepository = accountRepository;
            _securityService = securityService;
        }
        public UserModel RegisterUser(UserRegisterModel register)
        {
            if (_accountRepository.IsUserNameIsTaken(register.Username))
                return null;


            var user = new UserModel
            {
                Id = Guid.NewGuid(),
                UserName = register.Username.ToLower(),
                Email = register.Email,
                Password = _securityService.ComputeHash(register.Password),
                PasswordSalt = _securityService.GetKey()
            };

            var result = _accountRepository.Register(register);

            return !result ? null : user;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            IEnumerable<UserModel> users = _accountRepository.GetAllUsers();

            return users;
        }
    }
}
