using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Models;
using Microsoft.Extensions.Logging;
using TwoTaskLibrary.Services;
using Dapper;

namespace TwoTaskLibrary.Application
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ISqlDataFactory _sqlDataFactory;

        public GroupRepository(ISqlDataFactory sqlDataFactory)
        {
            _sqlDataFactory = sqlDataFactory;
        }

        public bool IsGroupExists(int groupId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, [Name], OwnerId FROM[dbo].[Group] WHERE Id = @Id; ";

            var group = connection.Query<GroupModel>(sql, new { Id = groupId });

            return group != null;
        }

        public int? GetUserInGroupId(int groupId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id FROM[dbo].[Group] WHERE GroupId = @GroupId AND UserId = @UserId; ";

            var id = connection.Query<int>(sql, new { GroupId = groupId, UserId = userId }).Single();

            return id;
        }
        public bool SaveGroup(GroupModel group)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	INSERT INTO dbo.[Group]([Name], OwnerId) VALUES(@Name, @OwnerId); ";

            connection.Execute(sql, new { Name = group.Name, OwnerId = group.OwnerId });

            return true;  
        }
        public IEnumerable<GroupModel> GetAllGroups(Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, [Name], OwnerId FROM[dbo].[Group] WHERE OwnerId = @UserId ORDER BY Id; ";

            var groups = connection.Query<GroupModel>(sql, new { OwnerId = userId });

            return groups;
        }
        public GroupModel GetGroupById(int groupId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, [Name], OwnerId FROM[dbo].[Group] WHERE Id = @Id; ";

            var group = connection.Query<GroupModel>(sql, new { Id = groupId }).Single();

            return group;
        }
        public bool UpdateGroupById(int groupId, GroupModel group, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	UPDATE dbo.[Group] SET[Name] = @Name, OwnerId = @OwnerId WHERE Id = @Id AND OwnerId = @OwnerId; ";

            connection.Execute(sql, new { Id = groupId, Name = group.Name, OwnerId = userId });

            return true;
        }
        public bool RemoveGroupById(int groupId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	DELETE FROM dbo.[Group] WHERE Id = @Id AND OwnerId = @UserId; ";

            connection.Execute(sql, new { Id = groupId, OwnerId = userId });

            return true;
        }
        public bool SaveUserInGroup(UsersInGroupModel userInGroup)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	INSERT INTO dbo.UsersInGroup(GroupId, UserId) VALUES(@GroupId, @UserId); ";

            connection.Execute(sql, new { GroupId = userInGroup.GroupId, UserId = userInGroup.UserId });

            return true;
        }
        public IEnumerable<UsersInGroupModel> GetAllUsersInGroup(int groupId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, GroupId, UserId FROM[dbo].[UsersInGroup] WHERE GroupId = @GroupId ORDER BY Id; ";

            var groups = connection.Query<UsersInGroupModel>(sql, new { GroupId = groupId });

            return groups;
        }
        public bool RemoveUserFromGroup(int groupId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	DELETE FROM dbo.UsersInGroup WHERE GroupId = @GroupId AND UserId = @UserId; ";

            connection.Execute(sql, new { GroupId = groupId, UserId = userId });

            return true;
        }
    }
}
