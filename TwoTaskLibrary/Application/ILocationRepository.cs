using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public interface ILocationRepository
    {
        void SaveLocation(LocationModel location);
        List<LocationModel> GetAllLocations(Guid userId);
        LocationModel GetLocationById(int locationId, Guid userId);
        void UpdateLocationById(int locationId, LocationModel location, Guid userId);
        bool DeleteLocationById(int locationId, Guid userId);
    }
}
