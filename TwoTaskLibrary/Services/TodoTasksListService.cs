using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Services
{
    public class TodoTasksListService
    {
        private readonly SqlDataAccess _sql;

        public TodoTasksListService(SqlDataAccess sql)
        {
            _sql = sql;
        }

        public bool IsTodoTasksListExists(int listId, Guid userId)
        {
            var list = _sql.LoadData<TodoTasksListModel, object>("dbo.spTodoTasksList_GetById", new { Id = listId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (list != null)
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
