using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly SqlDataAccess _sql;
        private readonly TodoTaskRepository _data;

        public TodoTaskController()
        {
            _sql = new SqlDataAccess();
            _data = new TodoTaskRepository(_sql);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoTaskModel todoTask)
        {
            try
            {
                _data.SaveTodoTask(todoTask);

                return Ok();
            }
            catch (Exception)
            {

                return NoContent();
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_data.GetAllTodoTasks());
        }

        [HttpGet("{taskId}")]
        public IActionResult Get(int taskId)
        {
            return Ok(_data.GetTodoTaskById(taskId));
        }

        [HttpPut("{taskId}")]
        public IActionResult Put(int taskId, [FromBody] TodoTaskModel todoTask)
        {
            try
            {
                _data.UpdateTodoTaskById(taskId, todoTask);
                return Ok();
            }
            catch(Exception)
            {
                return NoContent();
            }

        }
        
        [HttpDelete("{taskId}")]
        public IActionResult Delete(int taskId)
        {
            var result = _data.DeleteTodoTaskById(taskId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
