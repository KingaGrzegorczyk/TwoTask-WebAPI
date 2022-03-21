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
    public class TodoTaskServiceTests
    {
        private Mock<ITodoTaskRepository> _todoTaskRepository;
        private TodoTaskService _todoTaskService;
        private readonly Guid _userId;
        public TodoTaskServiceTests()
        {
            this._userId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5");
            this._todoTaskRepository = new Mock<ITodoTaskRepository>();
            this._todoTaskRepository.Setup(x => x.UpdateTodoTaskById(It.IsAny<int>(), It.IsAny<TodoTaskModel>(), _userId)).Returns(true);
            this._todoTaskRepository.Setup(x => x.RemoveTodoTaskById(It.IsAny<int>(), _userId)).Returns(true);
            this._todoTaskRepository.Setup(x => x.IsTodoTaskExists(It.IsAny<int>(), _userId)).Returns(true);


            _todoTaskService = new TodoTaskService(this._todoTaskRepository.Object);
        }

        [Fact]
        public void UpdateTodoTask_False()
        {
            this._todoTaskRepository.Setup(x => x.IsTodoTaskExists(It.IsAny<int>(), _userId)).Returns(false);

            TodoTaskModel model = new TodoTaskModel
            {
                Id = 2,
                ListId = 2,
                BeginDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                RegionId = 2,
                Description = "all rooms",
                Title = "clean house",
                Priority = 1,
                Status = "in progress",
                UserId = _userId

            };

            var result = _todoTaskService.UpdateTodoTaskById(model.Id, model, _userId);

            Assert.False(result);
        }

        [Fact]
        public void UpdateTodoTask_True()
        {
            this._todoTaskRepository.Setup(x => x.IsTodoTaskExists(It.IsAny<int>(), _userId)).Returns(true);

            TodoTaskModel model = new TodoTaskModel
            {
                Id = 2,
                ListId = 2,
                BeginDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                RegionId = 2,
                Description = "all rooms",
                Title = "clean house",
                Priority = 1,
                Status = "in progress",
                UserId = _userId

            };

            var result = _todoTaskService.UpdateTodoTaskById(model.Id, model, _userId);

            Assert.True(result);
        }

        [Fact]
        public void RemoveTodoTask_False()
        {
            this._todoTaskRepository.Setup(x => x.IsTodoTaskExists(It.IsAny<int>(), _userId)).Returns(false);

            TodoTaskModel model = new TodoTaskModel
            {
                Id = 2,
                ListId = 2,
                BeginDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                RegionId = 2,
                Description = "all rooms",
                Title = "clean house",
                Priority = 1,
                Status = "in progress",
                UserId = _userId

            };

            var result = _todoTaskService.RemoveTodoTaskById(model.Id, _userId);

            Assert.False(result);
        }

        [Fact]
        public void RemoveTodoTask_True()
        {
            this._todoTaskRepository.Setup(x => x.IsTodoTaskExists(It.IsAny<int>(), _userId)).Returns(true);

            TodoTaskModel model = new TodoTaskModel
            {
                Id = 2,
                ListId = 2,
                BeginDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                RegionId = 2,
                Description = "all rooms",
                Title = "clean house",
                Priority = 1,
                Status = "in progress",
                UserId = _userId

            };

            var result = _todoTaskService.RemoveTodoTaskById(model.Id, _userId);

            Assert.True(result);
        }
    }
}
