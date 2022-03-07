using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class TodoTasksListController : ControllerBase
    {
        private readonly SqlDataAccess _sql;
        protected ITodoTasksListRepository Data { get; set; }
        private readonly ILogger<TodoTasksListRepository> _logger;

        public TodoTasksListController(ILogger<TodoTasksListRepository> logger)
        {
            _sql = new SqlDataAccess();
            _logger = logger;
            Data = new TodoTasksListRepository(_sql, _logger);
        }

        [NonAction]
        public virtual Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
        }
        [HttpPost]
        public IActionResult Post([FromBody] TodoTasksListModel list)
        {
            list.UserId = GetCurrentUserId();
            var result = Data.SaveTodoTasksList(list);

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Data.GetAllTodoTasksLists(GetCurrentUserId()));
        }

        [HttpGet("{listId}")]
        public IActionResult Get(int listId)
        {
            return Ok(Data.GetTodoTasksListById(listId, GetCurrentUserId()));
        }

        [HttpPut("{listId}")]
        public IActionResult Put(int listId, [FromBody] TodoTasksListModel list)
        {
            list.UserId = GetCurrentUserId();
            var result = Data.UpdateTodoTasksListById(listId, list, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpDelete("{listId}")]
        public IActionResult Delete(int listId)
        {          
            var result = Data.RemoveTodoTasksListById(listId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
