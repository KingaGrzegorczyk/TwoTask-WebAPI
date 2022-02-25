using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public class GroupRepository : IGroupRepository
    {
        private readonly SqlDataAccess _sql;

        public GroupRepository(SqlDataAccess sql)
        {
            _sql = sql;
        }
        public void SaveGroup(GroupModel group)
        {
            _sql.SaveData("dbo.spGroup_Insert", group, "ConnectionStrings:TwoTaskData");
        }
        public List<GroupModel> GetAllGroups(Guid userId)
        {
            var output = _sql.LoadData<GroupModel, dynamic>("dbo.spGroup_GetAll", new { UserId = userId }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public GroupModel GetGroupById(int groupId)
        {
            var output = _sql.LoadData<GroupModel, dynamic>("dbo.spGroup_GetById", new { Id = groupId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();

            return output;
        }
        public void UpdateGroupById(int groupId, GroupModel group, Guid userId)
        {
            var groupToUpdate = _sql.LoadData<GroupModel, dynamic>("dbo.spGroup_GetById", new { Id = groupId, OwnerId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (groupToUpdate != null)
            {
                _sql.UpdateData("dbo.spGroup_UpdateById", group, "ConnectionStrings:TwoTaskData");
            }
            else
            {
                throw new Exception("Group not found");
            }
        }
        public bool DeleteGroupById(int groupId, Guid userId)
        {
            var groupToDelete = _sql.LoadData<GroupModel, dynamic>("dbo.spGroup_GetById", new { Id = groupId, OwnerId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (groupToDelete == null)
                return false;
            else
            {
                _sql.DeleteData("dbo.spGroup_DeleteById", new { Id = groupId, UserId = userId }, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
        public void SaveUserInGroup(UsersInGroupModel userInGroup)
        {
            _sql.SaveData("dbo.spUsersInGroup_Insert", userInGroup, "ConnectionStrings:TwoTaskData");
        }
        public List<UsersInGroupModel> GetAllUsersInGroup(int groupId)
        {
            var output = _sql.LoadData<UsersInGroupModel, dynamic>("dbo.spUsersInGroup_GetAll", new { GroupId = groupId }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public bool DeleteUserFromGroup(int groupId, Guid userId)
        {
            var userInGroupToDelete = _sql.LoadData<GroupModel, dynamic>("dbo.spUsersInGroup_GetById", new { GroupId = groupId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (userInGroupToDelete == null)
                return false;
            else
            {
                _sql.DeleteData("dbo.spUsersInGroup_DeleteUserById", new { Id = userInGroupToDelete.Id }, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
    }
}
