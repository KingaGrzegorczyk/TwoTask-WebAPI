using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public interface ITodoTaskRepository
    {
        void SaveTodoTask(TodoTaskModel todoTask);
        List<TodoTaskModel> GetAllTodoTasks();
        TodoTaskModel GetTodoTaskById(int taskId);
        void UpdateTodoTaskById(int taskId, TodoTaskModel todoTask);
        bool DeleteTodoTaskById(int taskId);
    }
}
