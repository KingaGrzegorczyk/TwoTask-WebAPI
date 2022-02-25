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
        public bool CheckIfUserExists(string username)
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
    }
}
