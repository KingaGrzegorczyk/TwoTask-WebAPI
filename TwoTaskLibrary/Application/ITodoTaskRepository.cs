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
        List<TodoTaskModel> GetAllTodoTasks(Guid userId);
        TodoTaskModel GetTodoTaskById(int taskId, Guid userId);
        void UpdateTodoTaskById(int taskId, TodoTaskModel todoTask, Guid userId);
        bool DeleteTodoTaskById(int taskId, Guid userId);
    }
}
