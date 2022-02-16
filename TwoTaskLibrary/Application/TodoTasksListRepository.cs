using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public class TodoTasksListRepository : ITodoTasksListRepository 
    {
        private readonly SqlDataAccess _sql;
        public TodoTasksListRepository(SqlDataAccess sql)
        {
            _sql = sql;
        }
        public void SaveTodoTasksList(TodoTasksListModel list)
        {           
            _sql.SaveData("dbo.spTodoTasksList_Insert", list, "ConnectionStrings:TwoTaskData");
        }
        public List<TodoTasksListModel> GetAllTodoTasksLists()
        {
            var output = _sql.LoadData<TodoTasksListModel, dynamic>("dbo.spTodoTasksList_GetAll", new { }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public TodoTasksListModel GetTodoTasksListById(int listId)
        {
            var output = _sql.LoadData<TodoTasksListModel, dynamic>("dbo.spTodoTasksList_GetById", new { Id = listId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();

            return output;
        }
        public void UpdateTodoTasksListById(int listId, TodoTasksListModel list)
        {
            var listToUpdate = _sql.LoadData<TodoTasksListModel, dynamic>("dbo.spTodoTasksList_GetById", new { Id = listId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (listToUpdate != null)
            {
                _sql.UpdateData("dbo.spTodoTasksList_UpdateById", list, "ConnectionStrings:TwoTaskData");
            }
            else
            {
                throw new Exception("List not found");
            }
        }
        public bool DeleteTodoTasksListById(int listId)
        {
            var listToDelete = _sql.LoadData<TodoTasksListModel, dynamic>("dbo.spTodoTasksList_GetById", new { Id = listId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (listToDelete == null)
                return false;
            else
            {
                _sql.DeleteData("dbo.spTodoTasksList_DeleteById", new { Id = listId }, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
    }
}
