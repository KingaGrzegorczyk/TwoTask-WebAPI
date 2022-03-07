using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;
using TwoTaskLibrary.Services;

namespace TwoTaskLibrary.Application
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly SqlDataAccess _sql;
        private readonly TodoTaskService _service;
        private readonly ILogger<TodoTaskRepository> _logger;

        public TodoTaskRepository(SqlDataAccess sql, ILogger<TodoTaskRepository> logger)
        {
            _sql = sql;
            _service = new TodoTaskService(_sql);
            _logger = logger;
        }
        public bool SaveTodoTask(TodoTaskModel todoTask)
        {
            try
            {
                _sql.SaveData("dbo.spTodoTask_Insert", todoTask, "ConnectionStrings:TwoTaskData");
                return true;
            }
            catch (Exception)
            {
                return false;
            }           
        }
        public IEnumerable<TodoTaskModel> GetAllTodoTasks(Guid userId)
        {
            var output = _sql.LoadData<TodoTaskModel, object>("dbo.spTodoTask_GetAll", new { UserId = userId }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public TodoTaskModel GetTodoTaskById(int taskId, Guid userId)
        {
            var output = _sql.LoadData<TodoTaskModel, object>("dbo.spTodoTask_GetById", new { Id = taskId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();

            return output;
        }
        public bool UpdateTodoTaskById(int taskId, TodoTaskModel todoTask, Guid userId)
        {
            if (!_service.IsTodoTaskExists(taskId, userId))
            {
                _logger.LogWarning("TodoTask not found");
                return false;
            }
            else
            {
                _sql.UpdateData("dbo.spTodoTask_UpdateById", todoTask, "ConnectionStrings:TwoTaskData");
                return true;
            }      
        }
        public bool RemoveTodoTaskById(int taskId, Guid userId)
        {
            if (!_service.IsTodoTaskExists(taskId, userId))
            {
                _logger.LogWarning("TodoTask not found");
                return false;
            }
            else
            {
                _sql.DeleteData("dbo.spTodoTask_DeleteById", new { Id = taskId, UserId = userId }, "ConnectionStrings:TwoTaskData");
                return true;
            }           
        }
    }
}
