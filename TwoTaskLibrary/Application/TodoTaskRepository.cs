using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly SqlDataAccess _sql;

        public TodoTaskRepository(SqlDataAccess sql)
        {
            _sql = sql;
        }
        public void SaveTodoTask(TodoTaskModel todoTask)
        {
            _sql.SaveData("dbo.spTodoTask_Insert", todoTask, "ConnectionStrings:TwoTaskData");
        }
        public List<TodoTaskModel> GetAllTodoTasks()
        {
            var output = _sql.LoadData<TodoTaskModel, dynamic>("dbo.spTodoTask_GetAll", new { }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public TodoTaskModel GetTodoTaskById(int taskId)
        {
            var output = _sql.LoadData<TodoTaskModel, dynamic>("dbo.spTodoTask_GetById", new { Id = taskId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();

            return output;
        }
        public void UpdateTodoTaskById(int taskId, TodoTaskModel todoTask)
        {
            var taskToUpdate = _sql.LoadData<TodoTaskModel, dynamic>("dbo.spTodoTask_GetById", new { Id = taskId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if(taskToUpdate != null)
            {
                _sql.UpdateData("dbo.spTodoTask_UpdateById", todoTask, "ConnectionStrings:TwoTaskData");
            }
            else
            {
                throw new Exception("Task not found");
            }       
        }
        public bool DeleteTodoTaskById(int taskId)
        {
            var taskToDelete = _sql.LoadData<TodoTaskModel, dynamic>("dbo.spTodoTask_GetById", new { Id = taskId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (taskToDelete == null)
                return false;
            else
            {
                _sql.DeleteData("dbo.spTodoTask_DeleteById", new { Id = taskId }, "ConnectionStrings:TwoTaskData");
                return true;
            }            
        }
    }
}
