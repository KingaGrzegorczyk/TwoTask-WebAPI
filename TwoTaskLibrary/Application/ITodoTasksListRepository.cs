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
        bool SaveTodoTasksList(TodoTasksListModel list);
        IEnumerable<TodoTasksListModel> GetAllTodoTasksLists(Guid userId);
        TodoTasksListModel GetTodoTasksListById(int listId, Guid userId);
        bool UpdateTodoTasksListById(int listId, TodoTasksListModel list, Guid userId);
        bool RemoveTodoTasksListById(int listId, Guid userId);
    }
}
