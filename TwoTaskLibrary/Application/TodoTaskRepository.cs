using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TwoTaskLibrary.Models;
using TwoTaskLibrary.Services;

namespace TwoTaskLibrary.Application
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly ISqlDataFactory _sqlDataFactory;

        public TodoTaskRepository(ISqlDataFactory sqlDataFactory)
        {
            _sqlDataFactory = sqlDataFactory;
        }
        public bool IsTodoTaskExists(int taskId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, ListId, BeginDate, EndDate, RegionId, [Description], Title, [Priority], [Status], UserId FROM[dbo].[TodoTask] WHERE Id = @Id AND UserId = @UserId; ";

            var task = connection.Query<TodoTaskModel>(sql, new { Id = taskId, UserId = userId }).Single();

            return task != null;
        }
        public bool SaveTodoTask(TodoTaskModel todoTask)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	INSERT INTO dbo.TodoTask(ListId, BeginDate, EndDate, RegionId, [Description], Title, [Priority], [Status], UserId) VALUES(@ListId, @BeginDate, @EndDate, @RegionId, @Description, @Title, @Priority, @Status, @UserId); ";

            connection.Execute(sql, new { ListId = todoTask.ListId, BeginDate = todoTask.BeginDate, EndDate = todoTask.EndDate, RegionId = todoTask.RegionId, Description = todoTask.Description, Title = todoTask.Title, Priority = todoTask.Priority, Status = todoTask.Status, UserId = todoTask.UserId });

            return true;
        }
        public IEnumerable<TodoTaskModel> GetAllTodoTasks(Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, ListId, BeginDate, EndDate, RegionId, [Description], Title, [Priority], [Status], UserId FROM[dbo].[TodoTask] WHERE UserId = @UserId ORDER BY Id; ";

            var tasks = connection.Query<TodoTaskModel>(sql, new { UserId = userId });

            return tasks;
        }
        public TodoTaskModel GetTodoTaskById(int taskId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, ListId, BeginDate, EndDate, RegionId, [Description], Title, [Priority], [Status], UserId FROM[dbo].[TodoTask] WHERE Id = @Id AND UserId = @UserId; ";

            var task = connection.Query<TodoTaskModel>(sql, new { Id = taskId, UserId = userId }).Single();

            return task;
        }
        public bool UpdateTodoTaskById(int taskId, TodoTaskModel todoTask, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	UPDATE dbo.TodoTask SET ListId = @ListId, BeginDate = @BeginDate, EndDate = @EndDate, RegionId = @RegionId, [Description] = @Description, Title = @Title, [Priority] = @Priority, [Status] = @Status, UserId = @UserId WHERE Id = @Id AND UserId = @UserId; ";

            connection.Execute(sql, new { Id = taskId, ListId = todoTask.ListId, BeginDate = todoTask.BeginDate, EndDate = todoTask.EndDate, RegionId = todoTask.RegionId, Description = todoTask.Description, Title = todoTask.Title, Priority = todoTask.Priority, Status = todoTask.Status, UserId = userId });

            return true;
        }
        public bool RemoveTodoTaskById(int taskId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	DELETE FROM dbo.TodoTask WHERE Id = @Id AND UserId = @UserId; ";

            connection.Execute(sql, new { Id = taskId, UserId = userId });

            return true;
        }
    }
}
