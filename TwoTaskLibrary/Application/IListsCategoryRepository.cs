using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public interface IListsCategoryRepository
    {
        bool IsListsCategoryExists(int categoryId, Guid userId);
        bool SaveListsCategory(ListsCategoryModel category);
        IEnumerable<ListsCategoryModel> GetAllListsCategories(Guid userId);
        ListsCategoryModel GetListsCategoryById(int categoryId, Guid userId);
        bool UpdateListsCategoryById(int categoryId, ListsCategoryModel category, Guid userId);
        bool RemoveListsCategoryById(int categoryId, Guid userId);
    }
}
