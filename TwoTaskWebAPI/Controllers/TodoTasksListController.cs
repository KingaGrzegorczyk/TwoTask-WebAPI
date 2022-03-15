using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Models;
using TwoTaskLibrary.Services;
using TwoTaskWebAPI.Extensions;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class TodoTasksListController : ControllerBase
    {
        private readonly ITodoTasksListService _todoTasksListService;
        private readonly ILogger<TodoTasksListController> _logger;

        public TodoTasksListController(ILogger<TodoTasksListController> logger, ITodoTasksListService todoTasksListService)
        {
            _todoTasksListService = todoTasksListService;
            _logger = logger;
        }

        [NonAction]
        public Guid GetCurrentUserId()
        {
            return HttpContext.GetUserId();
        }
        [HttpPost]
        public IActionResult Post([FromBody] TodoTasksListModel list)
        {
            var result = _todoTasksListService.SaveTodoTasksList(list);

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_todoTasksListService.GetAllTodoTasksLists(GetCurrentUserId()));
        }

        [HttpGet("{listId}")]
        public IActionResult Get(int listId)
        {
            return Ok(_todoTasksListService.GetTodoTasksListById(listId, GetCurrentUserId()));
        }

        [HttpPut("{listId}")]
        public IActionResult Put(int listId, [FromBody] TodoTasksListModel list)
        {
            var result = _todoTasksListService.UpdateTodoTasksListById(listId, list, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpDelete("{listId}")]
        public IActionResult Delete(int listId)
        {          
            var result = _todoTasksListService.RemoveTodoTasksListById(listId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
