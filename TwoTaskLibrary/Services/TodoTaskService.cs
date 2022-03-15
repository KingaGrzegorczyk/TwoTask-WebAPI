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
    public interface ITodoTaskService
    {
        bool SaveTodoTask(TodoTaskModel todoTask);
        IEnumerable<TodoTaskModel> GetAllTodoTasks(Guid userId);
        TodoTaskModel GetTodoTaskById(int taskId, Guid userId);
        bool UpdateTodoTaskById(int taskId, TodoTaskModel todoTask, Guid userId);
        bool RemoveTodoTaskById(int taskId, Guid userId);
    }
    public class TodoTaskService : ITodoTaskService
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TodoTaskService(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public bool SaveTodoTask(TodoTaskModel todoTask)
        {
            return _todoTaskRepository.SaveTodoTask(todoTask);
        }
        public IEnumerable<TodoTaskModel> GetAllTodoTasks(Guid userId)
        {
            return _todoTaskRepository.GetAllTodoTasks(userId);
        }
        public TodoTaskModel GetTodoTaskById(int taskId, Guid userId)
        {
            return _todoTaskRepository.GetTodoTaskById(taskId, userId);
        }
        public bool UpdateTodoTaskById(int taskId, TodoTaskModel todoTask, Guid userId)
        {
            if (_todoTaskRepository.IsTodoTaskExists(taskId, userId))
                return _todoTaskRepository.UpdateTodoTaskById(taskId, todoTask, userId);
            else
                return false;
        }
        public bool RemoveTodoTaskById(int taskId, Guid userId)
        {
            if (_todoTaskRepository.IsTodoTaskExists(taskId, userId))
                return _todoTaskRepository.RemoveTodoTaskById(taskId, userId);
            else
                return false;
        }
    }
}
