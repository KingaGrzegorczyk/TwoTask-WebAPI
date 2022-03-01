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
    public class RegionControllerTest
    {
        RegionControllerFixed _controller;
        public RegionControllerTest()
        {
            _controller = new RegionControllerFixed();
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
        public void GetByIdTest_OkResult(int regionId)
        {
            //Arrange
            int validRegionId = regionId;
            // Act
            var okResult = _controller.Get(validRegionId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void PostTest_OkResult()
        {
            //Arrange
            var completeRegion = new RegionModel()
            {
                Id = 3,
                Name = "Home",
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
            };

            //Act
            var createdResponse = _controller.Post(completeRegion);

            //Assert
            Assert.IsType<OkResult>(createdResponse);
        }

        [Fact]
        public void PostTest_NoContentResult()
        {
            //Arrange
            RegionModel incompleteRegion = null;

            //Act
            var badResponse = _controller.Post(incompleteRegion);

            //Assert
            Assert.IsType<NoContentResult>(badResponse);
        }

        [Theory]
        [InlineData(3)]
        public void DeleteByIdTest_OkResult(int regionId)
        {
            //Arrange
            var validRegionId = regionId;

            //Act
            var okResult = _controller.Delete(validRegionId);

            //Assert
            Assert.IsType<OkResult>(okResult);
        }

        [Theory]
        [InlineData(5)]
        public void DeleteByIdTest_NoContentResult(int regionId)
        {
            //Arrange
            var invalidRegionId = regionId;

            //Act
            var noContentResult = _controller.Delete(invalidRegionId);


            //Assert
            Assert.IsType<NoContentResult>(noContentResult);
        }

        [Theory]
        [InlineData(3)]
        public void UpdateByIdTest_OkResult(int regionId)
        {
            //Arrange
            var validRegionId = regionId;
            var completeRegion = new RegionModel()
            {
                Id = validRegionId,
                Name = "Home",
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
            };

            //Act
            var okResult = _controller.Put(validRegionId, completeRegion);


            //Assert
            Assert.IsType<OkResult>(okResult);
        }

        [Theory]
        [InlineData(5)]
        public void UpdateByIdTest_NoContentResult(int regionId)
        {
            //Arrange
            var invalidRegionId = regionId;
            var completeRegion = new RegionModel()
            {
                Id = invalidRegionId,
                Name = "Home",
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
            };

            //Act
            var noContentResult = _controller.Put(invalidRegionId, completeRegion);


            //Assert
            Assert.IsType<NoContentResult>(noContentResult);
        }
    }
}
