using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Services
{
    public class TodoTaskService
    {
        private readonly SqlDataAccess _sql;

        public TodoTaskService(SqlDataAccess sql)
        {
            _sql = sql;
        }

        public bool IsTodoTaskExists(int taskId, Guid userId)
        {
            var task = _sql.LoadData<TodoTaskModel, object>("dbo.spTodoTask_GetById", new { Id = taskId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (task != null)
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
