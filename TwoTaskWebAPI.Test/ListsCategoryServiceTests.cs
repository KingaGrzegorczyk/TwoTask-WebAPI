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

namespace TwoTaskWebAPI.UnitTests
{
    public class ListsCategoryServiceTests
    {
        private Mock<IListsCategoryRepository> _listsCategoryRepository;
        private ListsCategoryService _listsCategoryService;
        private readonly Guid _userId;

        public ListsCategoryServiceTests()
        {
            this._userId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5");
            this._listsCategoryRepository = new Mock<IListsCategoryRepository>();
            this._listsCategoryRepository.Setup(x => x.UpdateListsCategoryById(It.IsAny<int>(), It.IsAny<ListsCategoryModel>(), _userId)).Returns(true);
            this._listsCategoryRepository.Setup(x => x.RemoveListsCategoryById(It.IsAny<int>(), _userId)).Returns(true);
            this._listsCategoryRepository.Setup(x => x.IsListsCategoryExists(It.IsAny<int>(), _userId)).Returns(true);


            _listsCategoryService = new ListsCategoryService(this._listsCategoryRepository.Object);
        }

        [Fact]
        public void UpdateListsCategory_False()
        {
            this._listsCategoryRepository.Setup(x => x.IsListsCategoryExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(false);

            ListsCategoryModel model = new ListsCategoryModel()
            { Id = 2, Name = "testName", CategoryId = 1, UserId = _userId };

            var result = _listsCategoryService.UpdateListsCategoryById(model.Id, model, _userId);

            Assert.False(result);
        }

        [Fact]
        public void UpdateListsCategory_True()
        {
            this._listsCategoryRepository.Setup(x => x.IsListsCategoryExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);

            ListsCategoryModel model = new ListsCategoryModel()
            { Id = 2, Name = "testName", CategoryId = 1, UserId = _userId };

            var result = _listsCategoryService.UpdateListsCategoryById(model.Id, model, _userId);

            Assert.True(result);
        }

        [Fact]
        public void RemoveListsCategory_False()
        {
            this._listsCategoryRepository.Setup(x => x.IsListsCategoryExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(false);

            ListsCategoryModel model = new ListsCategoryModel()
            { Id = 2, Name = "testName", CategoryId = 1, UserId = _userId };

            var result = _listsCategoryService.RemoveListsCategoryById(model.Id, _userId);

            Assert.False(result);
        }

        [Fact]
        public void RemoveListsCategory_True()
        {
            this._listsCategoryRepository.Setup(x => x.IsListsCategoryExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);

            ListsCategoryModel model = new ListsCategoryModel()
            { Id = 2, Name = "testName", CategoryId = 1, UserId = _userId };

            var result = _listsCategoryService.RemoveListsCategoryById(model.Id, _userId);

            Assert.True(result);
        }
    }
}
