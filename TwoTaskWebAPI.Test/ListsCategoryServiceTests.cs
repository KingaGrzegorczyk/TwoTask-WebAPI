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
    public class ListsCategoryServiceTests
    {
        private Mock<IListsCategoryRepository> _listsCategoryRepository;
        private ListsCategoryService _listsCategoryService;

        public ListsCategoryServiceTests()
        {
            this._listsCategoryRepository = new Mock<IListsCategoryRepository>();
            this._listsCategoryRepository.Setup(x => x.UpdateListsCategoryById(It.IsAny<int>(), It.IsAny<ListsCategoryModel>(), It.IsAny<Guid>())).Returns(true);
            this._listsCategoryRepository.Setup(x => x.RemoveListsCategoryById(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);
            this._listsCategoryRepository.Setup(x => x.IsListsCategoryExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);


            _listsCategoryService = new ListsCategoryService(this._listsCategoryRepository.Object);
        }

        [Fact]
        public void UpdateListsCategory_False()
        {
            this._listsCategoryRepository.Setup(x => x.IsListsCategoryExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(false);

            ListsCategoryModel model = new ListsCategoryModel()
            { Id = 2, Name = "testName", CategoryId = 1, UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5") };

            var result = _listsCategoryService.UpdateListsCategoryById(model.Id, model, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.False(result);
        }

        [Fact]
        public void UpdateListsCategory_True()
        {
            this._listsCategoryRepository.Setup(x => x.IsListsCategoryExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);

            ListsCategoryModel model = new ListsCategoryModel()
            { Id = 2, Name = "testName", CategoryId = 1, UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5") };

            var result = _listsCategoryService.UpdateListsCategoryById(model.Id, model, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.True(result);
        }

        [Fact]
        public void RemoveListsCategory_False()
        {
            this._listsCategoryRepository.Setup(x => x.IsListsCategoryExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(false);

            ListsCategoryModel model = new ListsCategoryModel()
            { Id = 2, Name = "testName", CategoryId = 1, UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5") };

            var result = _listsCategoryService.RemoveListsCategoryById(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.False(result);
        }

        [Fact]
        public void RemoveListsCategory_True()
        {
            this._listsCategoryRepository.Setup(x => x.IsListsCategoryExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);

            ListsCategoryModel model = new ListsCategoryModel()
            { Id = 2, Name = "testName", CategoryId = 1, UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5") };

            var result = _listsCategoryService.RemoveListsCategoryById(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.True(result);
        }
    }
}
