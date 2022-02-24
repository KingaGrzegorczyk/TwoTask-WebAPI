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
        void SaveListsCategory(ListsCategoryModel category);
        List<ListsCategoryModel> GetAllListsCategories(Guid userId);
        ListsCategoryModel GetListsCategoryById(int categoryId, Guid userId);
        void UpdateListsCategoryById(int categoryId, ListsCategoryModel category, Guid userId);
        bool DeleteListsCategoryById(int categoryId, Guid userId);
    }
}
