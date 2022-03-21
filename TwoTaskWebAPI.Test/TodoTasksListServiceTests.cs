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
    public class TodoTasksListServiceTests
    {
        private Mock<ITodoTasksListRepository> _todoTasksListRepository;
        private TodoTasksListService _todoTasksListService;
        private readonly Guid _userId;
        public TodoTasksListServiceTests()
        {
            this._userId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5");
            this._todoTasksListRepository = new Mock<ITodoTasksListRepository>();
            this._todoTasksListRepository.Setup(x => x.UpdateTodoTasksListById(It.IsAny<int>(), It.IsAny<TodoTasksListModel>(), _userId)).Returns(true);
            this._todoTasksListRepository.Setup(x => x.RemoveTodoTasksListById(It.IsAny<int>(), _userId)).Returns(true);
            this._todoTasksListRepository.Setup(x => x.IsTodoTasksListExists(It.IsAny<int>(), _userId)).Returns(true);


            _todoTasksListService = new TodoTasksListService(this._todoTasksListRepository.Object);
        }

        [Fact]
        public void UpdateTodoTask_False()
        {
            this._todoTasksListRepository.Setup(x => x.IsTodoTasksListExists(It.IsAny<int>(), _userId)).Returns(false);

            TodoTasksListModel model = new TodoTasksListModel
            {
                Id = 1,
                Name = "home",
                CategoryId = 1,
                IsArchived = false,
                Colour = "blue",
                Privacy = "private",
                UserId = _userId,
                GroupId = 0
            };

            var result = _todoTasksListService.UpdateTodoTasksListById(model.Id, model, _userId);

            Assert.False(result);
        }

        [Fact]
        public void UpdateTodoTask_True()
        {
            this._todoTasksListRepository.Setup(x => x.IsTodoTasksListExists(It.IsAny<int>(), _userId)).Returns(true);

            TodoTasksListModel model = new TodoTasksListModel
            {
                Id = 1,
                Name = "home",
                CategoryId = 1,
                IsArchived = false,
                Colour = "blue",
                Privacy = "private",
                UserId = _userId,
                GroupId = 0
            };

            var result = _todoTasksListService.UpdateTodoTasksListById(model.Id, model, _userId);

            Assert.True(result);
        }

        [Fact]
        public void RemoveTodoTask_False()
        {
            this._todoTasksListRepository.Setup(x => x.IsTodoTasksListExists(It.IsAny<int>(), _userId)).Returns(false);

            TodoTasksListModel model = new TodoTasksListModel
            {
                Id = 1,
                Name = "home",
                CategoryId = 1,
                IsArchived = false,
                Colour = "blue",
                Privacy = "private",
                UserId = _userId,
                GroupId = 0
            };

            var result = _todoTasksListService.RemoveTodoTasksListById(model.Id, _userId);

            Assert.False(result);
        }

        [Fact]
        public void RemoveTodoTask_True()
        {
            this._todoTasksListRepository.Setup(x => x.IsTodoTasksListExists(It.IsAny<int>(), _userId)).Returns(true);

            TodoTasksListModel model = new TodoTasksListModel
            {
                Id = 1,
                Name = "home",
                CategoryId = 1,
                IsArchived = false,
                Colour = "blue",
                Privacy = "private",
                UserId = _userId,
                GroupId = 0
            };

            var result = _todoTasksListService.RemoveTodoTasksListById(model.Id, _userId);

            Assert.True(result);
        }
    }
}
