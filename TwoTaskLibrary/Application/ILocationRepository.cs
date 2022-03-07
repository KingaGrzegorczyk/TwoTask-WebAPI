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
        bool SaveLocation(LocationModel location);
        IEnumerable<LocationModel> GetAllLocations(Guid userId);
        LocationModel GetLocationById(int locationId, Guid userId);
        bool UpdateLocationById(int locationId, LocationModel location, Guid userId);
        bool RemoveLocationById(int locationId, Guid userId);
    }
}
