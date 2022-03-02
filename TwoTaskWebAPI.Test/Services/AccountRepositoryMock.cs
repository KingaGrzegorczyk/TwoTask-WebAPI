using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Models;
using TwoTaskWebAPI.Test.Helpers;

namespace TwoTaskWebAPI.Test.Services
{
    public class AccountRepositoryMock : IAccountRepository
    {
        public bool CheckIfUserExists(string username)
        {
            var user = DataHelper.GetAllUsers().Where(u => u.UserName == username).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<UserModel> GetAllUsers()
        {
            return DataHelper.GetAllUsers().ToList();
        }

        public void Register(UserModel user)
        {
            List<UserModel> users = DataHelper.GetAllUsers().ToList();
            users.Add(user);
        }
    }
}
