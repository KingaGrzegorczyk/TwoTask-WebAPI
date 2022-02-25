using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;
using Microsoft.AspNetCore.Authorization;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
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
                var currentUser = HttpContext.User;
               
                todoTask.UserId = Guid.Parse(currentUser.Claims.First(c => c.Type == "Id").Value);
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
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.First(c => c.Type == "Id").Value);

            return Ok(_data.GetAllTodoTasks(userId));
        }

        [HttpGet("{taskId}")]
        public IActionResult Get(int taskId)
        {
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.First(c => c.Type == "Id").Value);

            return Ok(_data.GetTodoTaskById(taskId, userId));
        }

        [HttpPut("{taskId}")]
        public IActionResult Put(int taskId, [FromBody] TodoTaskModel todoTask)
        {
            try
            {
                var currentUser = HttpContext.User;
                var userId = Guid.Parse(currentUser.Claims.First(c => c.Type == "Id").Value);
               
               _data.UpdateTodoTaskById(taskId, todoTask, userId);
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
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.First(c => c.Type == "Id").Value);
            var result = _data.DeleteTodoTaskById(taskId, userId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
