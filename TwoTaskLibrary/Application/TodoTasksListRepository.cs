using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;
using TwoTaskLibrary.Services;

namespace TwoTaskLibrary.Application
{
    public class TodoTasksListRepository : ITodoTasksListRepository 
    {
        private readonly SqlDataAccess _sql;
        private readonly TodoTasksListService _service;
        private readonly ILogger<TodoTasksListRepository> _logger;
        public TodoTasksListRepository(SqlDataAccess sql, ILogger<TodoTasksListRepository> logger)
        {
            _sql = sql;
            _service = new TodoTasksListService(_sql);
            _logger = logger;
        }
        public bool SaveTodoTasksList(TodoTasksListModel list)
        {
            try
            {
                _sql.SaveData("dbo.spTodoTasksList_Insert", list, "ConnectionStrings:TwoTaskData");
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }
        public IEnumerable<TodoTasksListModel> GetAllTodoTasksLists(Guid userId)
        {
            var output = _sql.LoadData<TodoTasksListModel, object>("dbo.spTodoTasksList_GetAll", new { UserId = userId  }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public TodoTasksListModel GetTodoTasksListById(int listId, Guid userId)
        {
            var output = _sql.LoadData<TodoTasksListModel, object>("dbo.spTodoTasksList_GetById", new { Id = listId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();

            return output;
        }
        public bool UpdateTodoTasksListById(int listId, TodoTasksListModel list, Guid userId)
        {
            if (!_service.IsTodoTasksListExists(listId, userId))
            {
                _logger.LogWarning("List not found");
                return false;
            }
            else
            {
                _sql.UpdateData("dbo.spTodoTasksList_UpdateById", list, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
        public bool RemoveTodoTasksListById(int listId, Guid userId)
        {
            if (!_service.IsTodoTasksListExists(listId, userId))
            {
                _logger.LogWarning("List not found");
                return false;
            }
            else
            {
                _sql.DeleteData("dbo.spTodoTasksList_DeleteById", new { Id = listId, UserId = userId }, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
    }
}
