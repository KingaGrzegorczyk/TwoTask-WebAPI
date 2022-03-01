using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Application;
using TwoTaskWebAPI.Controllers;

namespace TwoTaskWebAPI.Test.Services
{
    public class TodoTaskControllerFixed : TodoTaskController
    {
        public TodoTaskControllerFixed()
        {
            Data = new TodoTaskRepositoryMock();
        }
        public override Guid GetCurrentUserId()
        {
            return Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5");
        }
    }
}
