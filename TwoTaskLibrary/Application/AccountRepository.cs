using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;
using TwoTaskLibrary.Services;

namespace TwoTaskLibrary.Application
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SqlDataAccess _sql;
        private readonly AccountService _service;
        private readonly ILogger<AccountRepository> _logger;
        public AccountRepository(SqlDataAccess sql, ILogger<AccountRepository> logger)
        {
            _sql = sql;
            _service = new AccountService(_sql);
            _logger = logger;
        }
        public bool Register(UserRegisterModel register)
        {
            try
            {
                _sql.SaveData("dbo.spUser_Insert", _service.RegisterUser(register), "ConnectionStrings:TwoTaskData");
                return true;
            }
            catch (Exception)
            {
                return false;
            }           
        }        
        public bool IsUserNameIsTaken(string username)
        {
            var user = _sql.LoadData<UserModel, dynamic>("dbo.spUser_GetByName", new { UserName = username }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if(user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<UserModel> GetAllUsers()
        {
            var output = _sql.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { }, "ConnectionStrings:TwoTaskData");

            return output;
        }
      
    }
}
