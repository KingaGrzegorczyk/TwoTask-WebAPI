//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TwoTaskLibrary.Application;
//using TwoTaskLibrary.Models;
//using TwoTaskWebAPI.Test.Helpers;

//namespace TwoTaskWebAPI.Test.Services
//{
//    public class LocationRepositoryMock : ILocationRepository
//    {
//        public bool DeleteLocationById(int locationId, Guid userId)
//        {
//            var locationToDelete = DataHelper.GetAllLocations().FirstOrDefault(c => c.UserId == userId && c.Id == locationId);
//            if (locationToDelete != null)
//            {
//                List<LocationModel> regions = DataHelper.GetAllLocations().Where(c => c.UserId == userId).ToList();
//                regions.Remove(locationToDelete);
//                return true;
//            }
//            else
//                return false;
//        }

//        public List<LocationModel> GetAllLocations(Guid userId)
//        {
//            return DataHelper.GetAllLocations().Where(c => c.UserId == userId).ToList();
//        }

//        public LocationModel GetLocationById(int locationId, Guid userId)
//        {
//            return DataHelper.GetAllLocations().FirstOrDefault(c => c.UserId == userId && c.Id == locationId);
//        }

//        public void SaveLocation(LocationModel location)
//        {
//            List<LocationModel> locations = DataHelper.GetAllLocations().ToList();
//            locations.Add(location);
//        }

//        public void UpdateLocationById(int locationId, LocationModel location, Guid userId)
//        {
//            var locationToUpdate = DataHelper.GetAllLocations().FirstOrDefault(c => c.UserId == userId && c.Id == locationId);
//            if (locationToUpdate != null)
//            {
//                List<LocationModel> locations = DataHelper.GetAllLocations().Where(c => c.UserId == userId).ToList();
//                int index = locations.FindIndex(s => s.Id == locationId);
//                locations[index] = location;
//            }
//            else
//            {
//                throw new Exception("Location not found");
//            }
//        }
//    }
//}
