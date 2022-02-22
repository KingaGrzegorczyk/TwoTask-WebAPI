using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SqlDataAccess _sql;
        public AccountRepository(SqlDataAccess sql)
        {
            _sql = sql;
        }
        public void Register(UserModel user)
        {
            _sql.SaveData("dbo.spUser_Insert", user, "ConnectionStrings:TwoTaskData");
        }
        public void Login(UserModel user)
        {
            
            
            
        }
    }
}
