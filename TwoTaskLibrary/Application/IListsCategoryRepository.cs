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
        List<ListsCategoryModel> GetAllListsCategories();
        ListsCategoryModel GetListsCategoryById(int categoryId);
        void UpdateListsCategoryById(int categoryId, ListsCategoryModel category);
        bool DeleteListsCategoryById(int categoryId);
    }
}
