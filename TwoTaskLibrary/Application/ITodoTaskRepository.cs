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
        bool SaveTodoTask(TodoTaskModel todoTask);
        IEnumerable<TodoTaskModel> GetAllTodoTasks(Guid userId);
        TodoTaskModel GetTodoTaskById(int taskId, Guid userId);
        bool UpdateTodoTaskById(int taskId, TodoTaskModel todoTask, Guid userId);
        bool RemoveTodoTaskById(int taskId, Guid userId);
    }
}
