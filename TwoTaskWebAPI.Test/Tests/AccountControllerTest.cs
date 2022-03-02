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
    public class AccountControllerTest
    {
        AccountControllerFixed _controller;
        private readonly JwtSettings _jwtSettings;
        public AccountControllerTest()
        {
            _jwtSettings = new JwtSettings();
            _controller = new AccountControllerFixed(_jwtSettings);
        }

        [Fact]
        public void GetAllTest_OkResult()
        {
            // Act
            var okResult = _controller.GetAllUsers();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void RegisterTest_OkResult()
        {
            //Arrange          
            var completeUser = new UserRegisterModel()
            {
                Username = "tom1",
                Email = "tom@gmail.com",
                Password = "password",
            };

            //Act
            var createdResponse = _controller.Register(completeUser);

            //Assert
            Assert.IsType<OkResult>(createdResponse);
        }

        [Fact]
        public void RegisterTest_BadRequestResult()
        {
            //Arrange          
            var invalidUser = new UserRegisterModel()
            {
                Username = "tom",
                Email = "tom@gmail.com",
                Password = "password",
            };

            //Act
            var createdResponse = _controller.Register(invalidUser);

            //Assert
            Assert.IsType<BadRequestObjectResult>(createdResponse);
        }

        [Fact]
        public void LoginTest_OkResult()
        {
            //Arrange          
            var completeUser = new UserLoginModel()
            {
                UserName = "tom",
                Password = "string"
            };

            //Act
            var createdResponse = _controller.Login(completeUser);

            //Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void LoginTest_UnauthorizedResult()
        {
            //Arrange          
            var invalidUser = new UserLoginModel()
            {
                UserName = "tom123",
                Password = "string"
            };

            //Act
            var createdResponse = _controller.Login(invalidUser);

            //Assert
            Assert.IsType<UnauthorizedObjectResult>(createdResponse);
        }
    }
}
