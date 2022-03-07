using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public interface IAccountRepository
    {
        bool Register(UserRegisterModel register);
        bool IsUserNameIsTaken(string username);
        IEnumerable<UserModel> GetAllUsers();
    }
}
