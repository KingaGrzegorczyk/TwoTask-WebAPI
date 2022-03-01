using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Models;
using TwoTaskWebAPI.Test.Helpers;

namespace TwoTaskWebAPI.Test.Services
{
    public class ListsCategoryRepositoryMock : IListsCategoryRepository
    {
        public bool DeleteListsCategoryById(int categoryId, Guid userId)
        {
            var categoryToDelete = DataHelper.GetAllListsCategories().FirstOrDefault(c => c.UserId == userId && c.Id == categoryId);
            if (categoryToDelete != null)
            {
                List<ListsCategoryModel> categories = DataHelper.GetAllListsCategories().Where(c => c.UserId == userId).ToList();
                categories.Remove(categoryToDelete);
                return true;
            }
            else
                return false;
        }

        public List<ListsCategoryModel> GetAllListsCategories(Guid userId)
        {
            return DataHelper.GetAllListsCategories().Where(c => c.UserId == userId).ToList();
        }

        public ListsCategoryModel GetListsCategoryById(int categoryId, Guid userId)
        {
            return DataHelper.GetAllListsCategories().FirstOrDefault(c => c.UserId == userId && c.Id == categoryId);
        }

        public void SaveListsCategory(ListsCategoryModel category)
        {
            List<ListsCategoryModel> categories = DataHelper.GetAllListsCategories().ToList();
            categories.Add(category);
        }

        public void UpdateListsCategoryById(int categoryId, ListsCategoryModel category, Guid userId)
        {
            var categoryToUpdate = DataHelper.GetAllListsCategories().FirstOrDefault(c => c.UserId == userId && c.Id == categoryId);
            if (categoryToUpdate != null)
            {
                List<ListsCategoryModel> categories = DataHelper.GetAllListsCategories().Where(c => c.UserId == userId).ToList();
                int index = categories.FindIndex(s => s.Id == categoryId);
                categories[index] = category;
            }
            else
            {
                throw new Exception("Category not found");
            }
        }
    }
}
