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
    public class TodoTasksListRepositoryMock : ITodoTasksListRepository
    {
        public bool DeleteTodoTasksListById(int listId, Guid userId)
        {
            var listToDelete = DataHelper.GetAllTodoTasksLists().FirstOrDefault(c => c.UserId == userId && c.Id == listId);
            if (listToDelete != null)
            {
                List<TodoTasksListModel> todoTasksLists = DataHelper.GetAllTodoTasksLists().Where(c => c.UserId == userId).ToList();
                todoTasksLists.Remove(listToDelete);
                return true;
            }
            else
                return false;
        }

        public List<TodoTasksListModel> GetAllTodoTasksLists(Guid userId)
        {
            return DataHelper.GetAllTodoTasksLists().Where(c => c.UserId == userId).ToList();
        }

        public TodoTasksListModel GetTodoTasksListById(int listId, Guid userId)
        {
            return DataHelper.GetAllTodoTasksLists().FirstOrDefault(c => c.UserId == userId && c.Id == listId);
        }

        public void SaveTodoTasksList(TodoTasksListModel list)
        {
            List<TodoTasksListModel> todoTasksLists = DataHelper.GetAllTodoTasksLists().ToList();
            todoTasksLists.Add(list);
        }

        public void UpdateTodoTasksListById(int listId, TodoTasksListModel list, Guid userId)
        {
            var listToUpdate = DataHelper.GetAllTodoTasksLists().FirstOrDefault(c => c.UserId == userId && c.Id == listId);
            if (listToUpdate != null)
            {
                List<TodoTasksListModel> todoTasksLists = DataHelper.GetAllTodoTasksLists().Where(c => c.UserId == userId).ToList();
                int index = todoTasksLists.FindIndex(s => s.Id == listId);
                todoTasksLists[index] = list;
            }
            else
            {
                throw new Exception("List not found");
            }
        }
    }
}
