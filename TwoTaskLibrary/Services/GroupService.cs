using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Services
{
    public interface IGroupService
    {
        bool SaveGroup(GroupModel group);
        IEnumerable<GroupModel> GetAllGroups(Guid userId);
        GroupModel GetGroupById(int groupId);
        bool UpdateGroupById(int groupId, GroupModel group, Guid userId);
        bool RemoveGroupById(int groupId, Guid userId);
        bool SaveUserInGroup(UsersInGroupModel userInGroup);
        IEnumerable<UsersInGroupModel> GetAllUsersInGroup(int groupId);
        bool RemoveUserFromGroup(int groupId, Guid userId);
    }
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public bool SaveGroup(GroupModel group)
        {
            return _groupRepository.SaveGroup(group);
        }
        public IEnumerable<GroupModel> GetAllGroups(Guid userId)
        {
            return _groupRepository.GetAllGroups(userId);
        }

        public GroupModel GetGroupById(int groupId)
        {
            return _groupRepository.GetGroupById(groupId);
        }

        public bool UpdateGroupById(int groupId, GroupModel group, Guid userId)
        {
            if (_groupRepository.IsGroupExists(groupId))
                return _groupRepository.UpdateGroupById(groupId, group, userId);
            else
                return false;
        }

        public bool RemoveGroupById(int groupId, Guid userId)
        {
            if (_groupRepository.IsGroupExists(groupId))
                return _groupRepository.RemoveGroupById(groupId, userId);
            else
                return false;
        }

        public bool SaveUserInGroup(UsersInGroupModel userInGroup)
        {
            return _groupRepository.SaveUserInGroup(userInGroup);
        }

        public IEnumerable<UsersInGroupModel> GetAllUsersInGroup(int groupId)
        {
            return _groupRepository.GetAllUsersInGroup(groupId);
        }

        public bool RemoveUserFromGroup(int groupId, Guid userId)
        {
            if(_groupRepository.GetUserInGroupId(groupId, userId) != null)
                return _groupRepository.RemoveUserFromGroup(groupId, userId);
            else
                return false;
        }
    }
}
