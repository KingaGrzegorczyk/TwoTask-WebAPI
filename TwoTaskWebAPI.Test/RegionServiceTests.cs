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
    public class RegionServiceTests
    {
        private Mock<IRegionRepository> _regionRepository;
        private RegionService _regionService;
        private readonly Guid _userId;

        public RegionServiceTests()
        {
            this._userId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5");
            this._regionRepository = new Mock<IRegionRepository>();
            this._regionRepository.Setup(x => x.UpdateRegionById(It.IsAny<int>(), It.IsAny<RegionModel>(), _userId)).Returns(true);
            this._regionRepository.Setup(x => x.RemoveRegionById(It.IsAny<int>(), _userId)).Returns(true);
            this._regionRepository.Setup(x => x.IsRegionExists(It.IsAny<int>(), _userId)).Returns(true);


            _regionService = new RegionService(this._regionRepository.Object);
        }

        [Fact]
        public void UpdateRegion_False()
        {
            this._regionRepository.Setup(x => x.IsRegionExists(It.IsAny<int>(), _userId)).Returns(false);

            RegionModel model = new RegionModel()
            {
                Id = 1,
                Name = "School",
                UserId = _userId
            };

            var result = _regionService.UpdateRegionById(model.Id, model, _userId);

            Assert.False(result);
        }

        [Fact]
        public void UpdateRegion_True()
        {
            this._regionRepository.Setup(x => x.IsRegionExists(It.IsAny<int>(), _userId)).Returns(true);

            RegionModel model = new RegionModel()
            {
                Id = 1,
                Name = "School",
                UserId = _userId
            };

            var result = _regionService.UpdateRegionById(model.Id, model, _userId);

            Assert.True(result);
        }

        [Fact]
        public void RemoveRegion_False()
        {
            this._regionRepository.Setup(x => x.IsRegionExists(It.IsAny<int>(), _userId)).Returns(false);

            RegionModel model = new RegionModel()
            {
                Id = 1,
                Name = "School",
                UserId = _userId
            };

            var result = _regionService.RemoveRegionById(model.Id, _userId);

            Assert.False(result);
        }

        [Fact]
        public void RemoveRegion_True()
        {
            this._regionRepository.Setup(x => x.IsRegionExists(It.IsAny<int>(), _userId)).Returns(true);

            RegionModel model = new RegionModel()
            {
                Id = 1,
                Name = "School",
                UserId = _userId
            };

            var result = _regionService.RemoveRegionById(model.Id, _userId);

            Assert.True(result);
        }

    }
}
