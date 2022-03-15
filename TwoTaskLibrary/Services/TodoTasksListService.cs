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
    public interface ITodoTasksListService
    {
        bool SaveTodoTasksList(TodoTasksListModel list);
        IEnumerable<TodoTasksListModel> GetAllTodoTasksLists(Guid userId);
        TodoTasksListModel GetTodoTasksListById(int listId, Guid userId);
        bool UpdateTodoTasksListById(int listId, TodoTasksListModel list, Guid userId);
        bool RemoveTodoTasksListById(int listId, Guid userId);
    }
    public class TodoTasksListService : ITodoTasksListService
    {
        private readonly ITodoTasksListRepository _todoTasksListRepository;

        public TodoTasksListService(ITodoTasksListRepository todoTasksListRepository)
        {
            _todoTasksListRepository = todoTasksListRepository;
        }
        public bool SaveTodoTasksList(TodoTasksListModel list)
        {
            return _todoTasksListRepository.SaveTodoTasksList(list);
        }
        public IEnumerable<TodoTasksListModel> GetAllTodoTasksLists(Guid userId)
        {
            return _todoTasksListRepository.GetAllTodoTasksLists(userId);
        }
        public TodoTasksListModel GetTodoTasksListById(int listId, Guid userId)
        {
            return _todoTasksListRepository.GetTodoTasksListById(listId, userId);
        }
        public bool UpdateTodoTasksListById(int listId, TodoTasksListModel list, Guid userId)
        {
            if (_todoTasksListRepository.IsTodoTasksListExists(listId, userId))
                return _todoTasksListRepository.UpdateTodoTasksListById(listId, list, userId);
            else
                return false;
        }
        public bool RemoveTodoTasksListById(int listId, Guid userId)
        {
            if (_todoTasksListRepository.IsTodoTasksListExists(listId, userId))
                return _todoTasksListRepository.RemoveTodoTasksListById(listId, userId);
            else
                return false;
        }

    }
}
