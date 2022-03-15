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
    public class LocationServiceTests
    {
        private Mock<ILocationRepository> _locationRepository;
        private LocationService _locationService;

        public LocationServiceTests()
        {
            this._locationRepository = new Mock<ILocationRepository>();
            this._locationRepository.Setup(x => x.UpdateLocationById(It.IsAny<int>(), It.IsAny<LocationModel>(), It.IsAny<Guid>())).Returns(true);
            this._locationRepository.Setup(x => x.RemoveLocationById(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);
            this._locationRepository.Setup(x => x.IsLocationExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);


            _locationService = new LocationService(this._locationRepository.Object);
        }

        [Fact]
        public void UpdateLocation_False()
        {
            this._locationRepository.Setup(x => x.IsLocationExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(false);

            LocationModel model = new LocationModel()
            {
                Id = 3,
                RegionId = 2,
                Latitude = 35.255785466556,
                Longitude = 55.854525211455,
                Radius = 1,
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
            };

            var result = _locationService.UpdateLocationById(model.Id, model, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.False(result);
        }

        [Fact]
        public void UpdateLocation_True()
        {
            this._locationRepository.Setup(x => x.IsLocationExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);

            LocationModel model = new LocationModel()
            {
                Id = 3,
                RegionId = 2,
                Latitude = 35.255785466556,
                Longitude = 55.854525211455,
                Radius = 1,
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
            };

            var result = _locationService.UpdateLocationById(model.Id, model, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.True(result);
        }

        [Fact]
        public void RemoveLocation_False()
        {
            this._locationRepository.Setup(x => x.IsLocationExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(false);

            LocationModel model = new LocationModel()
            {
                Id = 3,
                RegionId = 2,
                Latitude = 35.255785466556,
                Longitude = 55.854525211455,
                Radius = 1,
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
            };

            var result = _locationService.RemoveLocationById(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.False(result);
        }

        [Fact]
        public void RemoveLocation_True()
        {
            this._locationRepository.Setup(x => x.IsLocationExists(It.IsAny<int>(), It.IsAny<Guid>())).Returns(true);

            LocationModel model = new LocationModel()
            {
                Id = 3,
                RegionId = 2,
                Latitude = 35.255785466556,
                Longitude = 55.854525211455,
                Radius = 1,
                UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
            };

            var result = _locationService.RemoveLocationById(model.Id, Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"));

            Assert.True(result);
        }
    }
}
