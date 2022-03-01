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

        public TodoTasksListController()
        {
            _sql = new SqlDataAccess();
            Data = new TodoTasksListRepository(_sql);
        }

        [NonAction]
        public virtual Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
        }
        [HttpPost]
        public IActionResult Post([FromBody] TodoTasksListModel list)
        {
            try
            {
                list.UserId = GetCurrentUserId();
                Data.SaveTodoTasksList(list);

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
            try
            {
                list.UserId = GetCurrentUserId();

                Data.UpdateTodoTasksListById(listId, list, GetCurrentUserId());
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
            var result = Data.DeleteTodoTasksListById(listId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
