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
        void Register(UserModel user);
        bool CheckIfUserExists(string username);
    }
}
