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
            return Ok(_data.GetAllTodoTasksLists());
        }

        [HttpGet("{listId}")]
        public IActionResult Get(int listId)
        {
            return Ok(_data.GetTodoTasksListById(listId));
        }

        [HttpPut("{listId}")]
        public IActionResult Put(int listId, [FromBody] TodoTasksListModel list)
        {
            try
            {
                _data.UpdateTodoTasksListById(listId, list);
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
            var result = _data.DeleteTodoTasksListById(listId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
