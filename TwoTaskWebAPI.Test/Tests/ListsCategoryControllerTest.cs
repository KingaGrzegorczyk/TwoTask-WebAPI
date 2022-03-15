using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;
using Xunit;

namespace TwoTaskWebAPI.Test.Tests
{
    public class ListsCategoryControllerTest
    {
        //ListsCategoryControllerFixed _controller;
        //public ListsCategoryControllerTest()
        //{
        //    _controller = new ListsCategoryControllerFixed();
        //}
        public ListsCategoryControllerTest()
        {

        }

        [Fact]
        public void GetAllTest_OkResult()
        {

        }

        //[Theory]
        //[InlineData(1)]
        //public void GetByIdTest_OkResult(int categoryId)
        //{
        //    //Arrange
        //    int validCategoryId = categoryId;
        //    // Act
        //    var okResult = _controller.Get(validCategoryId);

        //    // Assert
        //    Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        //}

        //[Fact]
        //public void PostTest_OkResult()
        //{
        //    //Arrange
        //    var completeCategory = new ListsCategoryModel()
        //    {
        //        Id = 3,
        //        Name = "work",
        //        CategoryId = 1
        //    };

        //    //Act
        //    var createdResponse = _controller.Post(completeCategory);

        //    //Assert
        //    Assert.IsType<OkResult>(createdResponse);
        //}

        //[Fact]
        //public void PostTest_NoContentResult()
        //{
        //    //Arrange
        //    ListsCategoryModel incompleteCategory = null;

        //    //Act
        //    var badResponse = _controller.Post(incompleteCategory);

        //    //Assert
        //    Assert.IsType<NoContentResult>(badResponse);
        //}

        //[Theory]
        //[InlineData(3)]
        //public void DeleteByIdTest_OkResult(int categoryId)
        //{
        //    //Arrange
        //    var validCateogryId = categoryId;

        //    //Act
        //    var okResult = _controller.Delete(validCateogryId);

        //    //Assert
        //    Assert.IsType<OkResult>(okResult);
        //}

        //[Theory]
        //[InlineData(5)]
        //public void DeleteByIdTest_NoContentResult(int categoryId)
        //{
        //    //Arrange
        //    var invalidCategoryId = categoryId;

        //    //Act
        //    var noContentResult = _controller.Delete(invalidCategoryId);


        //    //Assert
        //    Assert.IsType<NoContentResult>(noContentResult);
        //}

        //[Theory]
        //[InlineData(3)]
        //public void UpdateByIdTest_OkResult(int categoryId)
        //{
        //    //Arrange
        //    var validCategoryId = categoryId;
        //    var completeCategory = new ListsCategoryModel()
        //    {
        //        Id = validCategoryId,
        //        Name = "work",
        //        CategoryId = 1
        //    };

        //    //Act
        //    var okResult = _controller.Put(validCategoryId, completeCategory);


        //    //Assert
        //    Assert.IsType<OkResult>(okResult);
        //}

        //[Theory]
        //[InlineData(5)]
        //public void UpdateByIdTest_NoContentResult(int categoryId)
        //{
        //    //Arrange
        //    var invalidCategoryId = categoryId;
        //    var completeCategory = new ListsCategoryModel()
        //    {
        //        Id = invalidCategoryId,
        //        Name = "work",
        //        CategoryId = 1
        //    };

        //    //Act
        //    var noContentResult = _controller.Put(invalidCategoryId, completeCategory);


        //    //Assert
        //    Assert.IsType<NoContentResult>(noContentResult);
        //}
    }
}
