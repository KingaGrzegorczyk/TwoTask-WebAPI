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
        private readonly SqlDataAccess _sql;
        private readonly ListsCategoryService _service;
        private readonly ILogger<ListsCategoryRepository> _logger;

        public ListsCategoryRepository(SqlDataAccess sql, ILogger<ListsCategoryRepository> logger)
        {
            _sql = sql;
            _service = new ListsCategoryService(_sql);
            _logger = logger;
        }
        public bool SaveListsCategory(ListsCategoryModel category)
        {
            try
            {
                _sql.SaveData("dbo.spListsCategory_Insert", category, "ConnectionStrings:TwoTaskData");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public IEnumerable<ListsCategoryModel> GetAllListsCategories(Guid userId)
        {
            var output = _sql.LoadData<ListsCategoryModel, object>("dbo.spListsCategory_GetAll", new { UserId = userId }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public ListsCategoryModel GetListsCategoryById(int categoryId, Guid userId)
        {
            var output = _sql.LoadData<ListsCategoryModel, object>("dbo.spListsCategory_GetById", new { Id = categoryId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();

            return output;
        }
        public bool UpdateListsCategoryById(int categoryId, ListsCategoryModel category, Guid userId)
        {
            if (!_service.IsListsCategoryExists(categoryId, userId))
            {
                _logger.LogWarning("Category not found");
                return false;
            }
            else
            {
                _sql.UpdateData("dbo.spListsCategory_UpdateById", category, "ConnectionStrings:TwoTaskData");
                return true;
            }          
        }
        public bool RemoveListsCategoryById(int categoryId, Guid userId)
        {
            if (!_service.IsListsCategoryExists(categoryId, userId))
            {
                _logger.LogWarning("Category not found");
                return false;
            }
            else
            {
                _sql.DeleteData("dbo.spListsCategory_DeleteById", new { Id = categoryId, UserId = userId }, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
    }
}
