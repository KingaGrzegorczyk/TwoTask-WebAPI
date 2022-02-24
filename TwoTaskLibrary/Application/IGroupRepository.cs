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
        void SaveGroup(GroupModel group);
        List<GroupModel> GetAllGroups(Guid userId);
        GroupModel GetGroupById(int groupId, Guid userId);
        void UpdateGroupById(int groupId, GroupModel group, Guid userId);
        bool DeleteGroupyById(int groupId, Guid userId);
        void SaveUserInGroup(UsersInGroupModel userInGroup);
        bool DeleteUserFromGroup(int groupId, Guid userId);
    }
}
