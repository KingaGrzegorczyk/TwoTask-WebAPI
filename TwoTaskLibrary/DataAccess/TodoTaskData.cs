using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.DataAccess
{
    public class TodoTaskData
    {
        public void SaveTodoTask(TodoTaskModel todoTask)
        {    
            var twoTask = new TodoTaskModel
            {
                ListId = todoTask.ListId,
                BeginDate = todoTask.BeginDate,
                EndDate = todoTask.EndDate,
                RegionId = todoTask.RegionId,   
                Description = todoTask.Description,
                Title = todoTask.Title, 
                Priority = todoTask.Priority,   
                Status = todoTask.Status,
                UserId = todoTask.UserId
            };

            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spTodoTask_Insert", twoTask, "ConnectionStrings:TwoTaskData");
        }
        public List<TodoTaskModel> GetAllTodoTasks()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<TodoTaskModel, dynamic>("dbo.spTodoTask_GetAll", new { }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public TodoTaskModel GetTodoTaskById(int taskId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<TodoTaskModel, dynamic>("dbo.spTodoTask_GetById", new { Id = taskId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();

            return output;
        }
        public void UpdateTodoTaskById(int taskId, TodoTaskModel todoTask)
        {
            var twoTask = new TodoTaskModel
            {
                Id = taskId,
                ListId = todoTask.ListId,
                BeginDate = todoTask.BeginDate,
                EndDate = todoTask.EndDate,
                RegionId = todoTask.RegionId,
                Description = todoTask.Description,
                Title = todoTask.Title,
                Priority = todoTask.Priority,
                Status = todoTask.Status,
                UserId = todoTask.UserId
            };

            SqlDataAccess sql = new SqlDataAccess();

            sql.UpdateData("dbo.spTodoTask_UpdateById", twoTask, "ConnectionStrings:TwoTaskData");
        }
        public void DeleteTodoTaskById(int taskId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.DeleteData("dbo.spTodoTask_DeleteById", new { Id = taskId }, "ConnectionStrings:TwoTaskData");
        }
    }
}
