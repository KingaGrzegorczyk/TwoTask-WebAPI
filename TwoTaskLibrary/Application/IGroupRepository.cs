using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public interface IGroupRepository
    {
        bool IsGroupExists(int groupId);
        int? GetUserInGroupId(int groupId, Guid userId);
        bool SaveGroup(GroupModel group);
        IEnumerable<GroupModel> GetAllGroups(Guid userId);
        GroupModel GetGroupById(int groupId);
        bool UpdateGroupById(int groupId, GroupModel group, Guid userId);
        bool RemoveGroupById(int groupId, Guid userId);
        bool SaveUserInGroup(UsersInGroupModel userInGroup);
        IEnumerable<UsersInGroupModel> GetAllUsersInGroup(int groupId);
        bool RemoveUserFromGroup(int groupId, Guid userId);
    }
}
