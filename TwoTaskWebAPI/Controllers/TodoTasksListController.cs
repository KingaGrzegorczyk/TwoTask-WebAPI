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
        private readonly TodoTasksListRepository _data;

        public TodoTasksListController()
        {
            _sql = new SqlDataAccess();
            _data = new TodoTasksListRepository(_sql);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoTasksListModel list)
        {
            try
            {
                var currentUser = HttpContext.User;

                list.UserId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                _data.SaveTodoTasksList(list);

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
            var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            return Ok(_data.GetAllTodoTasksLists(userId));
        }

        [HttpGet("{listId}")]
        public IActionResult Get(int listId)
        {
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            return Ok(_data.GetTodoTasksListById(listId, userId));
        }

        [HttpPut("{listId}")]
        public IActionResult Put(int listId, [FromBody] TodoTasksListModel list)
        {
            try
            {
                var currentUser = HttpContext.User;
                var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                list.UserId = userId;

                _data.UpdateTodoTasksListById(listId, list, userId);
                return Ok();
            }
            catch (Exception)
            {
                return NoContent();
            }

        }

        [HttpDelete("{listId}")]
        public IActionResult Delete(int listId)
        {
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var result = _data.DeleteTodoTasksListById(listId, userId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
