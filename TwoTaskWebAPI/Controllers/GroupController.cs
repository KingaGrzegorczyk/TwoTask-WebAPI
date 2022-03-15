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
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly ILogger<GroupController> _logger;

        public GroupController(ILogger<GroupController> logger, IGroupService groupService)
        {
            _logger = logger;
            _groupService = groupService;
        }

        [NonAction]
        public Guid GetCurrentUserId()
        {
            return HttpContext.GetUserId();
        }

        [HttpPost]
        public IActionResult Post([FromBody] GroupModel group)
        {
            var result = _groupService.SaveGroup(group);

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_groupService.GetAllGroups(GetCurrentUserId()));
        }

        [HttpGet("{groupId}")]
        public IActionResult Get(int groupId)
        {
            return Ok(_groupService.GetGroupById(groupId));
        }

        [HttpPut("{groupId}")]
        public IActionResult Put(int groupId, [FromBody] GroupModel group)
        {
            var result = _groupService.UpdateGroupById(groupId, group, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpDelete("{groupId}")]
        public IActionResult Delete(int groupId)
        {
            var result = _groupService.RemoveGroupById(groupId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpPost("{groupId}/{userId}")]
        public IActionResult PostUserIntoGroup([FromBody] UsersInGroupModel user, int groupId, Guid userId)
        {
            var result = _groupService.SaveUserInGroup(user);

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpGet("GetUsers/{groupId}")]
        public IActionResult GetUsersFromGroup(int groupId)
        {
            return Ok(_groupService.GetAllUsersInGroup(groupId));
        }

        [HttpDelete("{groupId}/{userId}")]
        public IActionResult DeleteUserFromGroup(int groupId, Guid userId)
        {
            var result = _groupService.RemoveUserFromGroup(groupId, userId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
