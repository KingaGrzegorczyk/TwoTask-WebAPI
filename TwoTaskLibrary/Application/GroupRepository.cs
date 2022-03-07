using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;
using Microsoft.Extensions.Logging;
using TwoTaskLibrary.Services;

namespace TwoTaskLibrary.Application
{
    public class GroupRepository : IGroupRepository
    {
        private readonly SqlDataAccess _sql;
        private readonly GroupService _service;
        private readonly ILogger<GroupRepository> _logger;

        public GroupRepository(SqlDataAccess sql, ILogger<GroupRepository> logger)
        {
            _sql = sql; 
            _service = new GroupService(_sql);
            _logger = logger;
        }
        public bool SaveGroup(GroupModel group)
        {
            try
            {
                _sql.SaveData("dbo.spGroup_Insert", group, "ConnectionStrings:TwoTaskData");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
   
        }
        public IEnumerable<GroupModel> GetAllGroups(Guid userId)
        {
            var output = _sql.LoadData<GroupModel, object>("dbo.spGroup_GetAll", new { UserId = userId }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public GroupModel GetGroupById(int groupId)
        {
            var output = _sql.LoadData<GroupModel, object>("dbo.spGroup_GetById", new { Id = groupId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();

            return output;
        }
        public bool UpdateGroupById(int groupId, GroupModel group, Guid userId)
        {
            if (!_service.IsGroupExists(groupId))
            {
                _logger.LogWarning("Group not found");
                return false;
            }
            else
            {
                _sql.UpdateData("dbo.spGroup_UpdateById", group, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
        public bool RemoveGroupById(int groupId, Guid userId)
        {
            if (!_service.IsGroupExists(groupId))
            {
                _logger.LogWarning("Group not found");
                return false;
            }
            else
            {
                _sql.DeleteData("dbo.spGroup_DeleteById", new { Id = groupId, UserId = userId }, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
        public bool SaveUserInGroup(UsersInGroupModel userInGroup)
        {
            try
            {
                _sql.SaveData("dbo.spUsersInGroup_Insert", userInGroup, "ConnectionStrings:TwoTaskData");
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
        public IEnumerable<UsersInGroupModel> GetAllUsersInGroup(int groupId)
        {
            var output = _sql.LoadData<UsersInGroupModel, object>("dbo.spUsersInGroup_GetAll", new { GroupId = groupId }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public bool RemoveUserFromGroup(int groupId, Guid userId)
        {
            if (_service.GetUserInGroupId(groupId, userId) == null)
            {
                _logger.LogWarning("User in group not found");
                return false;
            }
            else
            {
                _sql.DeleteData("dbo.spUsersInGroup_DeleteUserById", new { Id = _service.GetUserInGroupId(groupId, userId) }, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
    }
}
