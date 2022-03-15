using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Services
{
    public interface IListsCategoryService
    {
        bool SaveListsCategory(ListsCategoryModel category);
        IEnumerable<ListsCategoryModel> GetAllListsCategories(Guid userId);
        ListsCategoryModel GetListsCategoryById(int categoryId, Guid userId);
        bool UpdateListsCategoryById(int categoryId, ListsCategoryModel category, Guid userId);
        bool RemoveListsCategoryById(int categoryId, Guid userId);
    }
    
    public class ListsCategoryService : IListsCategoryService
    {
        private readonly IListsCategoryRepository _listsCategoryRepository;

        public ListsCategoryService(IListsCategoryRepository listsCategoryRepository)
        {
            _listsCategoryRepository = listsCategoryRepository;
        }

        public bool SaveListsCategory(ListsCategoryModel category)
        {
            return _listsCategoryRepository.SaveListsCategory(category);
        }
        public IEnumerable<ListsCategoryModel> GetAllListsCategories(Guid userId)
        {
            return _listsCategoryRepository.GetAllListsCategories(userId);
        }
        public ListsCategoryModel GetListsCategoryById(int categoryId, Guid userId)
        {
            return _listsCategoryRepository.GetListsCategoryById(categoryId, userId);
        }
        public bool UpdateListsCategoryById(int categoryId, ListsCategoryModel category, Guid userId)
        {
            if (_listsCategoryRepository.IsListsCategoryExists(categoryId, userId))
                return _listsCategoryRepository.UpdateListsCategoryById(categoryId, category, userId);
            else
                return false;
        }
        public bool RemoveListsCategoryById(int categoryId, Guid userId)
        {
            if (_listsCategoryRepository.IsListsCategoryExists(categoryId, userId))
                return _listsCategoryRepository.RemoveListsCategoryById(categoryId, userId);
            else
                return false;
        }
    }
}
