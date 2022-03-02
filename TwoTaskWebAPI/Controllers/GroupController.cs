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
        protected IGroupRepository Data { get; set; }

        public GroupController()
        {
            _sql = new SqlDataAccess();
            Data = new GroupRepository(_sql);
        }

        [NonAction]
        public virtual Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
        }

        [HttpPost]
        public IActionResult Post([FromBody] GroupModel group)
        {
            try
            {
                group.OwnerId = GetCurrentUserId();
                Data.SaveGroup(group);

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
            return Ok(Data.GetAllGroups(GetCurrentUserId()));
        }

        [HttpGet("{groupId}")]
        public IActionResult Get(int groupId)
        {
            return Ok(Data.GetGroupById(groupId));
        }

        [HttpPut("{groupId}")]
        public IActionResult Put(int groupId, [FromBody] GroupModel group)
        {
            try
            {
                group.OwnerId = GetCurrentUserId();

                Data.UpdateGroupById(groupId, group, GetCurrentUserId());
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
            var result = Data.DeleteGroupById(groupId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpPost("{groupId}/{userId}")]
        public IActionResult PostUserIntoGroup([FromBody] UsersInGroupModel user, int groupId, Guid userId)
        {
            try
            {
                user.UserId = userId;
                user.GroupId = groupId;
                Data.SaveUserInGroup(user);

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
            return Ok(Data.GetAllUsersInGroup(groupId));
        }

        [HttpDelete("{groupId}/{userId}")]
        public IActionResult DeleteUserFromGroup(int groupId, Guid userId)
        {
            var result = Data.DeleteUserFromGroup(groupId, userId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
