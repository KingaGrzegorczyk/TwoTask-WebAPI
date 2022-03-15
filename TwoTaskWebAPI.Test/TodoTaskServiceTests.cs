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
    public class TodoTaskServiceTests
    {
        private Mock<ITodoTaskRepository> _todoTaskRepository;
        private TodoTaskService _todoTaskService;

        public TodoTaskServiceTests()
        {
            this._todoTaskRepository = new Mock<ITodoTaskRepository>();
            this._todoTaskRepository.Setup(x => x.UpdateTodoTaskById(It.IsAny<int>(), It.IsAny<TodoTaskModel>(), It.IsAny<Guid>())).Returns(true);
            this._todoTaskRepository.Setup(x => x.RemoveTodoTaskById(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);
            this._todoTaskRepository.Setup(x => x.IsTodoTaskExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);


            _todoTaskService = new TodoTaskService(this._todoTaskRepository.Object);
        }

        [Fact]
        public void UpdateTodoTask_False()
        {
            this._todoTaskRepository.Setup(x => x.IsTodoTaskExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(false);

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
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff4")

            };

            var result = _todoTaskService.UpdateTodoTaskById(model.Id, model, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.False(result);
        }

        [Fact]
        public void UpdateTodoTask_True()
        {
            this._todoTaskRepository.Setup(x => x.IsTodoTaskExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);

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
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff4")

            };

            var result = _todoTaskService.UpdateTodoTaskById(model.Id, model, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.True(result);
        }

        [Fact]
        public void RemoveTodoTask_False()
        {
            this._todoTaskRepository.Setup(x => x.IsTodoTaskExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(false);

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
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff4")

            };

            var result = _todoTaskService.RemoveTodoTaskById(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.False(result);
        }

        [Fact]
        public void RemoveTodoTask_True()
        {
            this._todoTaskRepository.Setup(x => x.IsTodoTaskExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);

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
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff4")

            };

            var result = _todoTaskService.RemoveTodoTaskById(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.True(result);
        }
    }
}
