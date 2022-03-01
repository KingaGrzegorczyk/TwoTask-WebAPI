using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using TwoTaskLibrary.Models;
using TwoTaskWebAPI.Controllers;
using TwoTaskWebAPI.Test.Services;
using Xunit;

namespace TwoTaskWebAPI.Test.Tests
{
    public class TodoTaskControllerTest
    {
        TodoTaskControllerFixed _controller;
        public TodoTaskControllerTest()
        {
            _controller = new TodoTaskControllerFixed();
        }       

        [Fact]
        public void GetAllTest_OkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Theory]
        [InlineData(1)]
        public void GetByIdTest_OkResult(int taskId)
        {
            //Arrange
            int validTaskId = taskId;
            // Act
            var okResult = _controller.Get(validTaskId); 

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void PostTest_OkResult()
        {
            //Arrange
            var completeTask = new TodoTaskModel()
            {
                Id = 1,
                ListId = 1,
                BeginDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                RegionId = 1,
                Description = "milk, eggs, apples, orangejuice",
                Title = "go shopping",
                Priority = 1,
                Status = "in progress"
            };

            //Act
            var createdResponse = _controller.Post(completeTask);

            //Assert
            Assert.IsType<OkResult>(createdResponse);             
        }

        [Fact]
        public void PostTest_NoContentResult()
        {
            //Arrange
            TodoTaskModel incompleteTask = null;

            //Act
            var badResponse = _controller.Post(incompleteTask);

            //Assert
            Assert.IsType<NoContentResult>(badResponse);
        }

        [Theory]
        [InlineData(3)]
        public void DeleteByIdTest_OkResult(int taskId)
        {
            //Arrange
            var validTaskId = taskId;

            //Act
            var okResult = _controller.Delete(validTaskId);

            //Assert
            Assert.IsType<OkResult>(okResult);
        }

        [Theory]
        [InlineData(5)]
        public void DeleteByIdTest_NoContentResult(int taskId)
        {
            //Arrange
            var invalidTaskId = taskId;

            //Act
            var noContentResult = _controller.Delete(invalidTaskId);


            //Assert
            Assert.IsType<NoContentResult>(noContentResult);
        }

        [Theory]
        [InlineData(3)]
        public void UpdateByIdTest_OkResult(int taskId)
        {
            //Arrange
            var validTaskId = taskId;
            var completeTask = new TodoTaskModel()
            {
                Id = validTaskId,
                ListId = 2,
                BeginDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                RegionId = 1,
                Description = "milk, eggs, apples, orangejuice",
                Title = "go shopping",
                Priority = 1,
                Status = "in progress"
            };

            //Act
            var okResult = _controller.Put(validTaskId, completeTask);


            //Assert
            Assert.IsType<OkResult>(okResult);
        }

        [Theory]
        [InlineData(5)]
        public void UpdateByIdTest_NoContentResult(int taskId)
        {
            //Arrange
            var invalidTaskId = taskId;
            var completeTask = new TodoTaskModel()
            {
                Id = invalidTaskId,
                ListId = 2,
                BeginDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                RegionId = 1,
                Description = "milk, eggs, apples, orangejuice",
                Title = "go shopping",
                Priority = 1,
                Status = "in progress"
            };

            //Act
            var noContentResult = _controller.Put(invalidTaskId, completeTask);


            //Assert
            Assert.IsType<NoContentResult>(noContentResult);
        }
    }
}
