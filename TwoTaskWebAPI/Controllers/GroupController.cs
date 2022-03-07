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
    public partial class GroupController : ControllerBase
    {
        private readonly SqlDataAccess _sql;
        protected IGroupRepository Data { get; set; }
        private readonly ILogger<GroupRepository> _logger;

        public GroupController(ILogger<GroupRepository> logger)
        {
            _sql = new SqlDataAccess();
            _logger = logger;
            Data = new GroupRepository(_sql, _logger);
        }

        [HttpPost]
        public IActionResult Post([FromBody] GroupModel group)
        {
            group.OwnerId = GetCurrentUserId();
            var result = Data.SaveGroup(group);

            return !result ? (IActionResult)NoContent() : Ok();
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
            var result = Data.UpdateGroupById(groupId, group, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();           
        }

        [HttpDelete("{groupId}")]
        public IActionResult Delete(int groupId)
        {
            var result = Data.RemoveGroupById(groupId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpPost("{groupId}/{userId}")]
        public IActionResult PostUserIntoGroup([FromBody] UsersInGroupModel user, int groupId, Guid userId)
        {
            user.UserId = userId;
            user.GroupId = groupId;
            
            var result = Data.SaveUserInGroup(user);

            return !result ? (IActionResult)NoContent() : Ok();           
        }

        [HttpGet("GetUsers/{groupId}")]
        public IActionResult GetUsersFromGroup(int groupId)
        {
            return Ok(Data.GetAllUsersInGroup(groupId));
        }

        [HttpDelete("{groupId}/{userId}")]
        public IActionResult DeleteUserFromGroup(int groupId, Guid userId)
        {
            var result = Data.RemoveUserFromGroup(groupId, userId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
