//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TwoTaskLibrary.Application;
//using TwoTaskLibrary.Models;
//using TwoTaskWebAPI.Test.Helpers;

//namespace TwoTaskWebAPI.Test.Services
//{
//    public class TodoTaskRepositoryMock : ITodoTaskRepository
//    {
//        public bool DeleteTodoTaskById(int taskId, Guid userId)
//        {
//            var taskToDelete = DataHelper.GetAllTodoTasks().FirstOrDefault(c => c.UserId == userId && c.Id == taskId);
//            if(taskToDelete != null)
//            {
//                List<TodoTaskModel> todoTasks = DataHelper.GetAllTodoTasks().Where(c => c.UserId == userId).ToList();
//                todoTasks.Remove(taskToDelete);
//                return true;
//            }
//            else
//                return false;
//        }

//        public List<TodoTaskModel> GetAllTodoTasks(Guid userId)
//        {
//            return DataHelper.GetAllTodoTasks().Where(c => c.UserId == userId).ToList();
//        }

//        public TodoTaskModel GetTodoTaskById(int taskId, Guid userId)
//        {
//            return DataHelper.GetAllTodoTasks().FirstOrDefault(c => c.UserId == userId && c.Id == taskId);
//        }

//        public void SaveTodoTask(TodoTaskModel todoTask)
//        {
//            List<TodoTaskModel> todoTasks = DataHelper.GetAllTodoTasks().ToList();
//            todoTasks.Add(todoTask);
//        }

//        public void UpdateTodoTaskById(int taskId, TodoTaskModel todoTask, Guid userId)
//        {
//            var taskToUpdate = DataHelper.GetAllTodoTasks().FirstOrDefault(c => c.UserId == userId && c.Id == taskId);
//            if (taskToUpdate != null)
//            {
//                List<TodoTaskModel> todoTasks = DataHelper.GetAllTodoTasks().Where(c => c.UserId == userId).ToList();
//                int index = todoTasks.FindIndex(s => s.Id == taskId);
//                todoTasks[index] = todoTask;
//            }
//            else
//            {
//                throw new Exception("Task not found");
//            }
//        }
//    }
//}
