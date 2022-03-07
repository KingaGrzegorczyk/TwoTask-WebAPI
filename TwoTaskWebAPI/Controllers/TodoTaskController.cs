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
        protected ITodoTaskRepository Data { get; set; }
        private readonly ILogger<TodoTaskRepository> _logger;

        public TodoTaskController(ILogger<TodoTaskRepository> logger)
        {
            _sql = new SqlDataAccess();
            _logger = logger;
            Data = new TodoTaskRepository(_sql, _logger);
        }

        [NonAction]
        public virtual Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoTaskModel todoTask)
        {
            todoTask.UserId = GetCurrentUserId();
            var result = Data.SaveTodoTask(todoTask);

            return !result ? (IActionResult)NoContent() : Ok();
        }       
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Data.GetAllTodoTasks(GetCurrentUserId()));
        }

        [HttpGet("{taskId}")]
        public IActionResult Get(int taskId)
        {
            return Ok(Data.GetTodoTaskById(taskId, GetCurrentUserId()));
        }

        [HttpPut("{taskId}")]
        public IActionResult Put(int taskId, [FromBody] TodoTaskModel todoTask)
        {
            todoTask.UserId = GetCurrentUserId();
            var result = Data.UpdateTodoTaskById(taskId, todoTask, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
        
        [HttpDelete("{taskId}")]
        public IActionResult Delete(int taskId)
        {
            var result = Data.RemoveTodoTaskById(taskId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
