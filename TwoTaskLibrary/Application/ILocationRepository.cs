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
        List<LocationModel> GetAllLocations();
        LocationModel GetLocationById(int locationId);
        void UpdateLocationById(int locationId, LocationModel location);
        bool DeleteLocationById(int locationId);
    }
}
