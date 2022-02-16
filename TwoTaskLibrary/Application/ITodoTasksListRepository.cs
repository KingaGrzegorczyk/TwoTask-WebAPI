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
        List<TodoTasksListModel> GetAllTodoTasksLists();
        TodoTasksListModel GetTodoTasksListById(int listId);
        void UpdateTodoTasksListById(int listId, TodoTasksListModel list);
        bool DeleteTodoTasksListById(int listId);
    }
}
