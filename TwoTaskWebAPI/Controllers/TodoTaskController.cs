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

        public TodoTaskController()
        {
            _sql = new SqlDataAccess();
            Data = new TodoTaskRepository(_sql);
        }

        [NonAction]
        public virtual Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoTaskModel todoTask)
        {
            try
            {               
                todoTask.UserId = GetCurrentUserId();
                Data.SaveTodoTask(todoTask);

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
            try
            {
                todoTask.UserId = GetCurrentUserId();

                Data.UpdateTodoTaskById(taskId, todoTask, GetCurrentUserId());
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
            var result = Data.DeleteTodoTaskById(taskId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
