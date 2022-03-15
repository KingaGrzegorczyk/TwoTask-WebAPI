using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Services
{
    public interface ILocationService
    {
        bool SaveLocation(LocationModel location);
        IEnumerable<LocationModel> GetAllLocations(Guid userId);
        LocationModel GetLocationById(int locationId, Guid userId);
        bool UpdateLocationById(int locationId, LocationModel location, Guid userId);
        bool RemoveLocationById(int locationId, Guid userId);
    }
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public bool SaveLocation(LocationModel location)
        {
           return _locationRepository.SaveLocation(location);
        }
        public IEnumerable<LocationModel> GetAllLocations(Guid userId)
        {
            return _locationRepository.GetAllLocations(userId);
        }
        public LocationModel GetLocationById(int locationId, Guid userId)
        {
            return _locationRepository.GetLocationById(locationId, userId);
        }
        public bool UpdateLocationById(int locationId, LocationModel location, Guid userId)
        {
            if (_locationRepository.IsLocationExists(locationId, userId))
                return _locationRepository.UpdateLocationById(locationId, location, userId);
            else
                return false;
        }
        public bool RemoveLocationById(int locationId, Guid userId)
        {
            if (_locationRepository.IsLocationExists(locationId, userId))
                return _locationRepository.RemoveLocationById(locationId, userId);
            else
                return false;
        }
    }
}
