//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TwoTaskLibrary.Application;
//using TwoTaskLibrary.Models;
//using TwoTaskWebAPI.Test.Helpers;

//namespace TwoTaskWebAPI.Test.Services
//{
//    public class GroupRepositoryMock : IGroupRepository
//    {
//        public bool DeleteGroupById(int groupId, Guid userId)
//        {
//            var groupToDelete = DataHelper.GetAllGroups().FirstOrDefault(c => c.OwnerId == userId && c.Id == groupId);
//            if (groupToDelete != null)
//            {
//                List<GroupModel> groups = DataHelper.GetAllGroups().Where(c => c.OwnerId == userId).ToList();
//                groups.Remove(groupToDelete);
//                return true;
//            }
//            else
//                return false;
//        }

//        public bool DeleteUserFromGroup(int groupId, Guid userId)
//        {
//            var userToDelete = DataHelper.GetAllUsersFromGroup().FirstOrDefault(c => c.UserId == userId && c.Id == groupId);
//            if (userToDelete != null)
//            {
//                List<UsersInGroupModel> users = DataHelper.GetAllUsersFromGroup().Where(c => c.UserId == userId).ToList();
//                users.Remove(userToDelete);
//                return true;
//            }
//            else
//                return false;
//        }

//        public List<GroupModel> GetAllGroups(Guid userId)
//        {
//            return DataHelper.GetAllGroups().Where(c => c.OwnerId == userId).ToList();
//        }

//        public List<UsersInGroupModel> GetAllUsersInGroup(int groupId)
//        {
//            return DataHelper.GetAllUsersFromGroup().Where(c => c.GroupId == groupId).ToList();
//        }

//        public GroupModel GetGroupById(int groupId)
//        {
//            return DataHelper.GetAllGroups().FirstOrDefault(c => c.Id == groupId);
//        }

//        public void SaveGroup(GroupModel group)
//        {
//            List<GroupModel> groups = DataHelper.GetAllGroups().ToList();
//            groups.Add(group);
//        }

//        public void SaveUserInGroup(UsersInGroupModel userInGroup)
//        {
//            List<UsersInGroupModel> users = DataHelper.GetAllUsersFromGroup().ToList();
//            users.Add(userInGroup);
//        }

//        public void UpdateGroupById(int groupId, GroupModel group, Guid userId)
//        {
//            var groupToUpdate = DataHelper.GetAllGroups().FirstOrDefault(c => c.OwnerId == userId && c.Id == groupId);
//            if (groupToUpdate != null)
//            {
//                List<GroupModel> groups = DataHelper.GetAllGroups().Where(c => c.OwnerId == userId).ToList();
//                int index = groups.FindIndex(s => s.Id == groupId);
//                groups[index] = group;
//            }
//            else
//            {
//                throw new Exception("Group not found");
//            }
//        }
//    }
//}
