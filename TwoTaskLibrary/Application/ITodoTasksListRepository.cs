using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public interface ITodoTasksListRepository
    {
        void SaveTodoTasksList(TodoTasksListModel list);
        List<TodoTasksListModel> GetAllTodoTasksLists(Guid userId);
        TodoTasksListModel GetTodoTasksListById(int listId, Guid userId);
        void UpdateTodoTasksListById(int listId, TodoTasksListModel list, Guid userId);
        bool DeleteTodoTasksListById(int listId, Guid userId);
    }
}
