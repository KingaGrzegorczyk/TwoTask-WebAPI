using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Models;
using TwoTaskWebAPI.Test.Services;
using Xunit;

namespace TwoTaskWebAPI.Test.Tests
{
    public class GroupControllerTest
    {
        GroupControllerFixed _controller;
        public GroupControllerTest()
        {
            _controller = new GroupControllerFixed();
        }

        [Fact]
        public void GetAllGroupsTest_OkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Theory]
        [InlineData(1)]
        public void GetGroupByIdTest_OkResult(int groupId)
        {
            //Arrange
            int validGroupId = groupId;
            // Act
            var okResult = _controller.Get(validGroupId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void PostGroupTest_OkResult()
        {
            //Arrange
            var completeGroup = new GroupModel()
            {
                Id = 3,
                Name = "class 2a"
            };

            //Act
            var createdResponse = _controller.Post(completeGroup);

            //Assert
            Assert.IsType<OkResult>(createdResponse);
        }

        [Fact]
        public void PostGroupTest_NoContentResult()
        {
            //Arrange
            GroupModel incompleteGroup = null;

            //Act
            var badResponse = _controller.Post(incompleteGroup);

            //Assert
            Assert.IsType<NoContentResult>(badResponse);
        }

        [Theory]
        [InlineData(3)]
        public void DeleteGroupByIdTest_OkResult(int groupId)
        {
            //Arrange
            var validGroupId = groupId;

            //Act
            var okResult = _controller.Delete(validGroupId);

            //Assert
            Assert.IsType<OkResult>(okResult);
        }

        [Theory]
        [InlineData(5)]
        public void DeleteGroupByIdTest_NoContentResult(int groupId)
        {
            //Arrange
            var invalidGroupId = groupId;

            //Act
            var noContentResult = _controller.Delete(invalidGroupId);


            //Assert
            Assert.IsType<NoContentResult>(noContentResult);
        }

        [Theory]
        [InlineData(3)]
        public void UpdateGroupByIdTest_OkResult(int groupId)
        {
            //Arrange
            var validGroupId = groupId;
            var completeGroup = new GroupModel()
            {
                Id = validGroupId,
                Name = "class 2a"
            };

            //Act
            var okResult = _controller.Put(validGroupId, completeGroup);


            //Assert
            Assert.IsType<OkResult>(okResult);
        }

        [Theory]
        [InlineData(5)]
        public void UpdateGroupByIdTest_NoContentResult(int groupId)
        {
            //Arrange
            var invalidGroupId = groupId;
            var completeGroup = new GroupModel()
            {
                Id = invalidGroupId,
                Name = "class 2a"
            };

            //Act
            var noContentResult = _controller.Put(invalidGroupId, completeGroup);


            //Assert
            Assert.IsType<NoContentResult>(noContentResult);
        }

        [Fact]
        public void PostUserIntoGroupTest_OkResult()
        {
            //Arrange
            var completeUser = new UsersInGroupModel()
            {
                Id = 3,
                GroupId = 3,
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
            };

            //Act
            var createdResponse = _controller.PostUserIntoGroup(completeUser, completeUser.GroupId, completeUser.UserId);

            //Assert
            Assert.IsType<OkResult>(createdResponse);
        }

        [Fact]
        public void PostUserIntoGroupTest_NoContentResult()
        {
            //Arrange
            UsersInGroupModel incompleteUser = null;
            int? groupId = null;
            Guid? userId = null;

            //Act
            var badResponse = _controller.PostUserIntoGroup(incompleteUser, groupId ?? default(int), userId ?? default(Guid));

            //Assert
            Assert.IsType<NoContentResult>(badResponse);
        }

        [Theory]
        [InlineData(3)]
        public void GetAllUsersFromGroupTest_OkResult(int groupId)
        {
            //Arrange
            var validGroupId = groupId;
            // Act
            var okResult = _controller.GetUsersFromGroup(validGroupId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Theory]
        [InlineData(3, "5418b246-9d9f-4d37-a6d9-a283a2169ff5")]
        public void DeleteUserFromGroupTest_OkResult(int groupId, string userId)
        {
            //Arrange
            var validGroupId = groupId;
            var validUserId = new Guid(userId);

            //Act
            var okResult = _controller.DeleteUserFromGroup(validGroupId, validUserId);

            //Assert
            Assert.IsType<OkResult>(okResult);
        }

        [Theory]
        [InlineData(5, "5418b246-9d9f-4d37-a6d9-a283a2169ff5")]
        public void DeleteUserFromGroupTest_NoContentResult(int groupId, string userId)
        {
            //Arrange
            var invalidGroupId = groupId;
            var validUserId = new Guid(userId);

            //Act
            var noContentResult = _controller.DeleteUserFromGroup(invalidGroupId, validUserId);


            //Assert
            Assert.IsType<NoContentResult>(noContentResult);
        }
    }
}
