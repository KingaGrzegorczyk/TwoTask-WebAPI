using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using TwoTaskLibrary.Services;
using TwoTaskWebAPI.Extensions;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class TodoTaskController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;
        private readonly ILogger<TodoTaskController> _logger;

        public TodoTaskController(ILogger<TodoTaskController> logger, ITodoTaskService todoTaskService)
        {
            _todoTaskService = todoTaskService;
            _logger = logger;
        }

        [NonAction]
        public Guid GetCurrentUserId()
        {
            return HttpContext.GetUserId();
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoTaskModel todoTask)
        {
            var result = _todoTaskService.SaveTodoTask(todoTask);

            return !result ? (IActionResult)NoContent() : Ok();
        }       
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_todoTaskService.GetAllTodoTasks(GetCurrentUserId()));
        }

        [HttpGet("{taskId}")]
        public IActionResult Get(int taskId)
        {
            return Ok(_todoTaskService.GetTodoTaskById(taskId, GetCurrentUserId()));
        }

        [HttpPut("{taskId}")]
        public IActionResult Put(int taskId, [FromBody] TodoTaskModel todoTask)
        {
            var result = _todoTaskService.UpdateTodoTaskById(taskId, todoTask, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
        
        [HttpDelete("{taskId}")]
        public IActionResult Delete(int taskId)
        {
            var result = _todoTaskService.RemoveTodoTaskById(taskId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
