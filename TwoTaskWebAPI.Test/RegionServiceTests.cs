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
    public class RegionServiceTests
    {
        private Mock<IRegionRepository> _regionRepository;
        private RegionService _regionService;

        public RegionServiceTests()
        {
            this._regionRepository = new Mock<IRegionRepository>();
            this._regionRepository.Setup(x => x.UpdateRegionById(It.IsAny<int>(), It.IsAny<RegionModel>(), It.IsAny<Guid>())).Returns(true);
            this._regionRepository.Setup(x => x.RemoveRegionById(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);
            this._regionRepository.Setup(x => x.IsRegionExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);


            _regionService = new RegionService(this._regionRepository.Object);
        }

        [Fact]
        public void UpdateRegion_False()
        {
            this._regionRepository.Setup(x => x.IsRegionExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(false);

            RegionModel model = new RegionModel()
            {
                Id = 1,
                Name = "School",
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
            };

            var result = _regionService.UpdateRegionById(model.Id, model, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.False(result);
        }

        [Fact]
        public void UpdateRegion_True()
        {
            this._regionRepository.Setup(x => x.IsRegionExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);

            RegionModel model = new RegionModel()
            {
                Id = 1,
                Name = "School",
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
            };

            var result = _regionService.UpdateRegionById(model.Id, model, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.True(result);
        }

        [Fact]
        public void RemoveRegion_False()
        {
            this._regionRepository.Setup(x => x.IsRegionExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(false);

            RegionModel model = new RegionModel()
            {
                Id = 1,
                Name = "School",
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
            };

            var result = _regionService.RemoveRegionById(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.False(result);
        }

        [Fact]
        public void RemoveRegion_True()
        {
            this._regionRepository.Setup(x => x.IsRegionExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);

            RegionModel model = new RegionModel()
            {
                Id = 1,
                Name = "School",
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
            };

            var result = _regionService.RemoveRegionById(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.True(result);
        }

    }
}
