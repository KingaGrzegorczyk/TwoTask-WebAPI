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
    public class GroupController : ControllerBase
    {
        private readonly SqlDataAccess _sql;
        private readonly GroupRepository _data;

        public GroupController()
        {
            _sql = new SqlDataAccess();
            _data = new GroupRepository(_sql);
        }
        [HttpPost]
        public IActionResult Post([FromBody] GroupModel group)
        {
            try
            {
                var currentUser = HttpContext.User;

                group.OwnerId = Guid.Parse(currentUser.Claims.First(c => c.Type == "Id").Value);
                _data.SaveGroup(group);

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

            return Ok(_data.GetAllGroups(userId));
        }

        [HttpGet("{groupId}")]
        public IActionResult Get(int groupId)
        {
            return Ok(_data.GetGroupById(groupId));
        }

        [HttpPut("{groupId}")]
        public IActionResult Put(int groupId, [FromBody] GroupModel group)
        {
            try
            {
                var currentUser = HttpContext.User;
                var userId = Guid.Parse(currentUser.Claims.First(c => c.Type == "Id").Value);
                group.OwnerId = userId;

                _data.UpdateGroupById(groupId, group, userId);
                return Ok();
            }
            catch (Exception)
            {
                return NoContent();
            }

        }

        [HttpDelete("{groupId}")]
        public IActionResult Delete(int groupId)
        {
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.First(c => c.Type == "Id").Value);
            var result = _data.DeleteGroupById(groupId, userId);

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpPost("{groupId}/{userId}")]
        public IActionResult PostUserIntoGroup([FromBody] UsersInGroupModel user)
        {
            try
            {
                _data.SaveUserInGroup(user);

                return Ok();
            }
            catch (Exception)
            {

                return NoContent();
            }
        }

        [HttpGet("GetUsers/{groupId}")]
        public IActionResult GetUsersFromGroup(int groupId)
        {
            return Ok(_data.GetAllUsersInGroup(groupId));
        }

        [HttpDelete("{groupId}/{userId}")]
        public IActionResult DeleteUserFromGroup(int groupId, Guid userId)
        {
            var result = _data.DeleteUserFromGroup(groupId, userId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
