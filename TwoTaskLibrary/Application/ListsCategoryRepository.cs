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
    public class ListsCategoryRepository : IListsCategoryRepository
    {
        private readonly ISqlDataFactory _sqlDataFactory;

        public ListsCategoryRepository(ISqlDataFactory sqlDataFactory)
        {
            _sqlDataFactory = sqlDataFactory;
        }

        public bool IsListsCategoryExists(int categoryId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, [Name], CategoryId, UserId FROM[dbo].[ListsCategory] WHERE Id = @Id AND UserId = @UserId; ";

            var category = connection.Query<ListsCategoryModel>(sql, new { Id = categoryId, UserId = userId }).Single();

            return category != null;
        }
        public bool SaveListsCategory(ListsCategoryModel category)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	INSERT INTO dbo.ListsCategory([Name], CategoryId, UserId) VALUES(@Name, @CategoryId, @UserId); ";

            connection.Execute(sql, new { Name = category.Name, CategoryId = category.CategoryId, UserId = category.UserId });

            return true;
        }
        public IEnumerable<ListsCategoryModel> GetAllListsCategories(Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, [Name], CategoryId, UserId FROM[dbo].[ListsCategory] WHERE UserId = @UserId ORDER BY Id; ";

            var categories = connection.Query<ListsCategoryModel>(sql, new { UserId = userId });

            return categories;
        }
        public ListsCategoryModel GetListsCategoryById(int categoryId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, [Name], CategoryId, UserId FROM[dbo].[ListsCategory] WHERE Id = @Id AND UserId = @UserId; ";

            var category = connection.Query<ListsCategoryModel>(sql, new { Id = categoryId, UserId = userId }).Single();

            return category;
        }
        public bool UpdateListsCategoryById(int categoryId, ListsCategoryModel category, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	UPDATE dbo.ListsCategory SET[Name] = @Name, CategoryId = @CategoryId, UserId = @UserId WHERE Id = @Id AND UserId = @UserId; ";

            connection.Execute(sql, new { Id = categoryId, Name = category.Name, CategoryId = category.CategoryId, UserId = userId });

            return true;
        }
        public bool RemoveListsCategoryById(int categoryId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	DELETE FROM dbo.ListsCategory WHERE Id = @Id AND UserId = @UserId; ";

            connection.Execute(sql, new { Id = categoryId, UserId = userId });

            return true;
        }
    }
}
