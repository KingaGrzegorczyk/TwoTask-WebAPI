using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTasksController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] TodoTaskModel todoTask)
        {
            TodoTaskData data = new TodoTaskData();

            data.SaveTodoTask(todoTask);

            return Ok();
        }

        [HttpGet]
        public List<TodoTaskModel> Get()
        {
            TodoTaskData data = new TodoTaskData();

            return data.GetAllTodoTasks();
        }

        [HttpGet("{taskId}")]
        public TodoTaskModel Get(int taskId)
        {
            TodoTaskData data = new TodoTaskData();

            return data.GetTodoTaskById(taskId);
        }

        [HttpPut("{taskId}")]
        public IActionResult Put(int taskId, [FromBody] TodoTaskModel todoTask)
        {
            TodoTaskData data = new TodoTaskData();

            data.UpdateTodoTaskById(taskId, todoTask);

            return Ok();
        }
        
        [HttpDelete("{taskId}")]
        public IActionResult Delete(int taskId)
        {
            TodoTaskData data = new TodoTaskData();

            data.DeleteTodoTaskById(taskId);

            return Ok();
        }
    }
}
