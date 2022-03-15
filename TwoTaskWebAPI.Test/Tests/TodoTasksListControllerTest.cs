//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TwoTaskLibrary.Models;
//using TwoTaskWebAPI.Test.Services;
//using Xunit;

//namespace TwoTaskWebAPI.Test.Tests
//{
//    public class TodoTasksListControllerTest
//    {
//        TodoTasksListControllerFixed _controller;
//        public TodoTasksListControllerTest()
//        {
//            _controller = new TodoTasksListControllerFixed();
//        }

//        [Fact]
//        public void GetAllTest_OkResult()
//        {
//            // Act
//            var okResult = _controller.Get();
//            // Assert
//            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
//        }

//        [Theory]
//        [InlineData(1)]
//        public void GetByIdTest_OkResult(int listId)
//        {
//            //Arrange
//            int validListId = listId;
//            // Act
//            var okResult = _controller.Get(validListId);

//            // Assert
//            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
//        }

//        [Fact]
//        public void PostTest_OkResult()
//        {
//            //Arrange
//            var completeList = new TodoTasksListModel()
//            {
//                Id = 3,
//                Name = "work",
//                CategoryId = 2,
//                IsArchived = false,
//                Colour = "red",
//                Privacy = "semipublic",
//                GroupId = 1
//            };

//            //Act
//            var createdResponse = _controller.Post(completeList);

//            //Assert
//            Assert.IsType<OkResult>(createdResponse);
//        }
//        [Fact]
//        public void PostTest_NoContentResult()
//        {
//            //Arrange
//            TodoTasksListModel incompleteList = null;

//            //Act
//            var badResponse = _controller.Post(incompleteList);

//            //Assert
//            Assert.IsType<NoContentResult>(badResponse);
//        }

//        [Theory]
//        [InlineData(3)]
//        public void DeleteByIdTest_OkResult(int listId)
//        {
//            //Arrange
//            var validListId = listId;

//            //Act
//            var okResult = _controller.Delete(validListId);

//            //Assert
//            Assert.IsType<OkResult>(okResult);
//        }

//        [Theory]
//        [InlineData(5)]
//        public void DeleteByIdTest_NoContentResult(int listId)
//        {
//            //Arrange
//            var invalidListId = listId;

//            //Act
//            var noContentResult = _controller.Delete(invalidListId);


//            //Assert
//            Assert.IsType<NoContentResult>(noContentResult);
//        }

//        [Theory]
//        [InlineData(3)]
//        public void UpdateByIdTest_OkResult(int listId)
//        {
//            //Arrange
//            var validListId = listId;
//            var completeList = new TodoTasksListModel()
//            {
//                Id = validListId,
//                Name = "work",
//                CategoryId = 2,
//                IsArchived = false,
//                Colour = "red",
//                Privacy = "semipublic",
//                GroupId = 1
//            };

//            //Act
//            var okResult = _controller.Put(validListId, completeList);


//            //Assert
//            Assert.IsType<OkResult>(okResult);
//        }

//        [Theory]
//        [InlineData(5)]
//        public void UpdateByIdTest_NoContentResult(int listId)
//        {
//            //Arrange
//            var invalidListId = listId;
//            var completeList = new TodoTasksListModel()
//            {
//                Id = invalidListId,
//                Name = "work",
//                CategoryId = 2,
//                IsArchived = false,
//                Colour = "red",
//                Privacy = "semipublic",
//                GroupId = 1
//            };

//            //Act
//            var noContentResult = _controller.Put(invalidListId, completeList);


//            //Assert
//            Assert.IsType<NoContentResult>(noContentResult);
//        }
//    }
//}
