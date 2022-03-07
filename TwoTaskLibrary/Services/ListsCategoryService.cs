using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Services
{
    public class ListsCategoryService
    {
        private readonly SqlDataAccess _sql;

        public ListsCategoryService(SqlDataAccess sql)
        {
            _sql = sql;
        }

        public bool IsListsCategoryExists(int categoryId, Guid userId)
        {
            var category = _sql.LoadData<ListsCategoryModel, object>("dbo.spListsCategory_GetById", new { Id = categoryId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if(category != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
