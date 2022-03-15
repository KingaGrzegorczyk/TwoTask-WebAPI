using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Models;
using TwoTaskLibrary.Services;
using Xunit;

namespace TwoTaskWebAPI.Test
{
    public class GroupServiceTests
    {
        private Mock<IGroupRepository> _groupRepository;
        private GroupService _groupService;

        public GroupServiceTests()
        {
            this._groupRepository = new Mock<IGroupRepository>();
            this._groupRepository.Setup(x => x.UpdateGroupById(It.IsAny<int>(), It.IsAny<GroupModel>(), It.IsAny<Guid>())).Returns(true);
            this._groupRepository.Setup(x => x.RemoveGroupById(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);
            this._groupRepository.Setup(x => x.IsGroupExists(It.IsAny<int>())).Returns(true);
            this._groupRepository.Setup(x => x.GetUserInGroupId(It.IsAny<int>(), It.IsAny<Guid>())).Returns(1);
            this._groupRepository.Setup(x => x.RemoveUserFromGroup(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);

            _groupService = new GroupService(this._groupRepository.Object);
        }

        [Fact]
        public void UpdateGroup_False()
        {
            this._groupRepository.Setup(x => x.IsGroupExists(It.IsAny<int>())).Returns(false);

            GroupModel model = new GroupModel()
            { Id = 2, Name = "testName", OwnerId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5") };

            var result = _groupService.UpdateGroupById(model.Id, model, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.False(result);
        }

        [Fact]
        public void UpdateGroup_True()
        {
            this._groupRepository.Setup(x => x.IsGroupExists(It.IsAny<int>())).Returns(true);

            GroupModel model = new GroupModel()
            { Id = 2, Name = "testName", OwnerId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5") };

            var result = _groupService.UpdateGroupById(model.Id, model, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.True(result);
        }

        [Fact]
        public void RemoveGroup_False()
        {
            this._groupRepository.Setup(x => x.IsGroupExists(It.IsAny<int>())).Returns(false);

            GroupModel model = new GroupModel()
            { Id = 2, Name = "testName", OwnerId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5") };

            var result = _groupService.RemoveGroupById(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.False(result);
        }

        [Fact]
        public void RemoveGroup_True()
        {
            this._groupRepository.Setup(x => x.IsGroupExists(It.IsAny<int>())).Returns(true);

            GroupModel model = new GroupModel()
            { Id = 2, Name = "testName", OwnerId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5") };

            var result = _groupService.RemoveGroupById(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.True(result);
        }

        [Fact]
        public void RemoveUserFromGroup_False()
        {
            this._groupRepository.Setup(x => x.GetUserInGroupId(It.IsAny<int>(), It.IsAny<Guid>())).Returns(null as int?);

            UsersInGroupModel model = new UsersInGroupModel()
            { Id = 2, GroupId = 1, UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5") };

            var result = _groupService.RemoveUserFromGroup(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.False(result);
        }

        [Fact]
        public void RemoveUserFromGroup_True()
        {
            this._groupRepository.Setup(x => x.GetUserInGroupId(It.IsAny<int>(), It.IsAny<Guid>())).Returns(1);

            UsersInGroupModel model = new UsersInGroupModel()
            { Id = 2, GroupId = 1, UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5") };

            var result = _groupService.RemoveUserFromGroup(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.True(result);
        }

    }
}
