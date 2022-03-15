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
    public class TodoTasksListServiceTests
    {
        private Mock<ITodoTasksListRepository> _todoTasksListRepository;
        private TodoTasksListService _todoTasksListService;

        public TodoTasksListServiceTests()
        {
            this._todoTasksListRepository = new Mock<ITodoTasksListRepository>();
            this._todoTasksListRepository.Setup(x => x.UpdateTodoTasksListById(It.IsAny<int>(), It.IsAny<TodoTasksListModel>(), It.IsAny<Guid>())).Returns(true);
            this._todoTasksListRepository.Setup(x => x.RemoveTodoTasksListById(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);
            this._todoTasksListRepository.Setup(x => x.IsTodoTasksListExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);


            _todoTasksListService = new TodoTasksListService(this._todoTasksListRepository.Object);
        }

        [Fact]
        public void UpdateTodoTask_False()
        {
            this._todoTasksListRepository.Setup(x => x.IsTodoTasksListExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(false);

            TodoTasksListModel model = new TodoTasksListModel
            {
                Id = 1,
                Name = "home",
                CategoryId = 1,
                IsArchived = false,
                Colour = "blue",
                Privacy = "private",
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"),
                GroupId = 0
            };

            var result = _todoTasksListService.UpdateTodoTasksListById(model.Id, model, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.False(result);
        }

        [Fact]
        public void UpdateTodoTask_True()
        {
            this._todoTasksListRepository.Setup(x => x.IsTodoTasksListExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);

            TodoTasksListModel model = new TodoTasksListModel
            {
                Id = 1,
                Name = "home",
                CategoryId = 1,
                IsArchived = false,
                Colour = "blue",
                Privacy = "private",
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"),
                GroupId = 0
            };

            var result = _todoTasksListService.UpdateTodoTasksListById(model.Id, model, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.True(result);
        }

        [Fact]
        public void RemoveTodoTask_False()
        {
            this._todoTasksListRepository.Setup(x => x.IsTodoTasksListExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(false);

            TodoTasksListModel model = new TodoTasksListModel
            {
                Id = 1,
                Name = "home",
                CategoryId = 1,
                IsArchived = false,
                Colour = "blue",
                Privacy = "private",
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"),
                GroupId = 0
            };

            var result = _todoTasksListService.RemoveTodoTasksListById(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.False(result);
        }

        [Fact]
        public void RemoveTodoTask_True()
        {
            this._todoTasksListRepository.Setup(x => x.IsTodoTasksListExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);

            TodoTasksListModel model = new TodoTasksListModel
            {
                Id = 1,
                Name = "home",
                CategoryId = 1,
                IsArchived = false,
                Colour = "blue",
                Privacy = "private",
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"),
                GroupId = 0
            };

            var result = _todoTasksListService.RemoveTodoTasksListById(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.True(result);
        }
    }
}
