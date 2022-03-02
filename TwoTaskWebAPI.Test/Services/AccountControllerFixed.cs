using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskWebAPI.Controllers;

namespace TwoTaskWebAPI.Test.Services
{
    public class AccountControllerFixed : AccountController
    {
        public AccountControllerFixed(JwtSettings jwtSettings) : base(jwtSettings)
        {   
            Data = new AccountRepositoryMock();
        }      
    }
}
