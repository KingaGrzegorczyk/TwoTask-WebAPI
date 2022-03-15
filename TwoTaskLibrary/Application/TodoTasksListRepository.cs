using Dapper;
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
        private readonly ISqlDataFactory _sqlDataFactory;

        public TodoTasksListRepository(ISqlDataFactory sqlDataFactory)
        {
            _sqlDataFactory = sqlDataFactory;
        }
        public bool IsTodoTasksListExists(int listId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, [Name], CategoryId, IsArchived, Colour, Privacy, UserId FROM[dbo].[TodoTasksList] WHERE Id = @Id AND UserId = @UserId; ";

            var list = connection.Query<TodoTasksListModel>(sql, new { Id = listId, UserId = userId }).Single();

            return list != null;
        }
        public bool SaveTodoTasksList(TodoTasksListModel list)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	INSERT INTO dbo.TodoTasksList([Name], CategoryId, IsArchived, Colour, Privacy, UserId) VALUES(@Name, @CategoryId, @IsArchived, @Colour, @Privacy, @UserId); ";

            connection.Execute(sql, new { Name = list.Name, CategoryId = list.CategoryId, IsArchived = list.IsArchived, Colour = list.Colour, Privacy = list.Privacy, UserId = list.UserId });

            return true;
        }
        public IEnumerable<TodoTasksListModel> GetAllTodoTasksLists(Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, [Name], CategoryId, IsArchived, Colour, Privacy, UserId FROM[dbo].[TodoTasksList] WHERE UserId = @UserId ORDER BY Id; ";

            var lists = connection.Query<TodoTasksListModel>(sql, new { UserId = userId });

            return lists;
        }
        public TodoTasksListModel GetTodoTasksListById(int listId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, [Name], CategoryId, IsArchived, Colour, Privacy, UserId FROM[dbo].[TodoTasksList] WHERE Id = @Id AND UserId = @UserId; ";

            var list = connection.Query<TodoTasksListModel>(sql, new { Id = listId, UserId = userId }).Single();

            return list;
        }
        public bool UpdateTodoTasksListById(int listId, TodoTasksListModel list, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	UPDATE dbo.TodoTasksList SET[Name] = @Name, CategoryId = @CategoryId, IsArchived = @IsArchived, Colour = @Colour, Privacy = @Privacy, UserId = @UserId WHERE Id = @Id AND UserId = @UserId; ";

            connection.Execute(sql, new { Id = listId, Name = list.Name, CategoryId = list.CategoryId, IsArchived = list.IsArchived, Colour = list.Colour, Privacy = list.Privacy, UserId = userId });

            return true;
        }
        public bool RemoveTodoTasksListById(int listId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	DELETE FROM dbo.TodoTasksList WHERE Id = @Id AND UserId = @UserId; ";

            connection.Execute(sql, new { Id = listId, UserId = userId });

            return true;
        }
    }
}
