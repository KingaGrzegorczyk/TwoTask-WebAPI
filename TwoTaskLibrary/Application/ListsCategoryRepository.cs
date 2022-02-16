using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public class ListsCategoryRepository : IListsCategoryRepository
    {
        private readonly SqlDataAccess _sql;

        public ListsCategoryRepository(SqlDataAccess sql)
        {
            _sql = sql;
        }
        public void SaveListsCategory(ListsCategoryModel category)
        {
            _sql.SaveData("dbo.spListsCategory_Insert", category, "ConnectionStrings:TwoTaskData");
        }
        public List<ListsCategoryModel> GetAllListsCategories()
        {
            var output = _sql.LoadData<ListsCategoryModel, dynamic>("dbo.spListsCategory_GetAll", new { }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public ListsCategoryModel GetListsCategoryById(int categoryId)
        {
            var output = _sql.LoadData<ListsCategoryModel, dynamic>("dbo.spListsCategory_GetById", new { Id = categoryId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();

            return output;
        }
        public void UpdateListsCategoryById(int categoryId, ListsCategoryModel category)
        {
            var categoryToUpdate = _sql.LoadData<ListsCategoryModel, dynamic>("dbo.spListsCategory_GetById", new { Id = categoryId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (categoryToUpdate != null)
            {
                _sql.UpdateData("dbo.spListsCategory_UpdateById", category, "ConnectionStrings:TwoTaskData");
            }
            else
            {
                throw new Exception("Category not found");
            }
        }
        public bool DeleteListsCategoryById(int categoryId)
        {
            var categoryToDelete = _sql.LoadData<ListsCategoryModel, dynamic>("dbo.spListsCategory_GetById", new { Id = categoryId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (categoryToDelete == null)
                return false;
            else
            {
                _sql.DeleteData("dbo.spListsCategory_DeleteById", new { Id = categoryId }, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
    }
}
