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
//    public class LocationControllerTest
//    {
//        LocationControllerFixed _controller;
//        public LocationControllerTest()
//        {
//            _controller = new LocationControllerFixed();
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
//        public void GetByIdTest_OkResult(int locationId)
//        {
//            //Arrange
//            int validLocationId = locationId;
//            // Act
//            var okResult = _controller.Get(validLocationId);

//            // Assert
//            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
//        }

//        [Fact]
//        public void PostTest_OkResult()
//        {
//            //Arrange
//            var completeLocation = new LocationModel()
//            {
//                Id = 3,
//                RegionId = 2,
//                Latitude = 35.255785466556,
//                Longitude = 55.854525211455,
//                Radius = 1
//            };

//            //Act
//            var createdResponse = _controller.Post(completeLocation);

//            //Assert
//            Assert.IsType<OkResult>(createdResponse);
//        }

//        [Fact]
//        public void PostTest_NoContentResult()
//        {
//            //Arrange
//            LocationModel incompleteLocation = null;

//            //Act
//            var badResponse = _controller.Post(incompleteLocation);

//            //Assert
//            Assert.IsType<NoContentResult>(badResponse);
//        }

//        [Theory]
//        [InlineData(3)]
//        public void DeleteByIdTest_OkResult(int locationId)
//        {
//            //Arrange
//            var validLocationId = locationId;

//            //Act
//            var okResult = _controller.Delete(validLocationId);

//            //Assert
//            Assert.IsType<OkResult>(okResult);
//        }

//        [Theory]
//        [InlineData(5)]
//        public void DeleteByIdTest_NoContentResult(int locationId)
//        {
//            //Arrange
//            var invalidLocationId = locationId;

//            //Act
//            var noContentResult = _controller.Delete(invalidLocationId);


//            //Assert
//            Assert.IsType<NoContentResult>(noContentResult);
//        }

//        [Theory]
//        [InlineData(3)]
//        public void UpdateByIdTest_OkResult(int locationId)
//        {
//            //Arrange
//            var validLocationId = locationId;
//            var completeLocation= new LocationModel()
//            {
//                Id = validLocationId,
//                RegionId = 2,
//                Latitude = 35.255785466556,
//                Longitude = 55.854525211455,
//                Radius = 1
//            };

//            //Act
//            var okResult = _controller.Put(validLocationId, completeLocation);


//            //Assert
//            Assert.IsType<OkResult>(okResult);
//        }

//        [Theory]
//        [InlineData(5)]
//        public void UpdateByIdTest_NoContentResult(int locationId)
//        {
//            //Arrange
//            var invalidLocationId = locationId;
//            var completeLocation = new LocationModel()
//            {
//                Id = invalidLocationId,
//                RegionId = 2,
//                Latitude = 35.255785466556,
//                Longitude = 55.854525211455,
//                Radius = 1
//            };

//            //Act
//            var noContentResult = _controller.Put(invalidLocationId, completeLocation);


//            //Assert
//            Assert.IsType<NoContentResult>(noContentResult);
//        }
//    }
//}
