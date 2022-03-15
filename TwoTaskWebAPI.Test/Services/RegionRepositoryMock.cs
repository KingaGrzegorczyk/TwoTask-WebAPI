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
//    public class RegionRepositoryMock : IRegionRepository
//    {
//        public bool DeletegionById(int regionId, Guid userId)
//        {
//            var regionToDelete = DataHelper.GetAllRegions().FirstOrDefault(c => c.UserId == userId && c.Id == regionId);
//            if (regionToDelete != null)
//            {
//                List<RegionModel> regions = DataHelper.GetAllRegions().Where(c => c.UserId == userId).ToList();
//                regions.Remove(regionToDelete);
//                return true;
//            }
//            else
//                return false;
//        }

//        public List<RegionModel> GetAllRegions(Guid userId)
//        {
//            return DataHelper.GetAllRegions().Where(c => c.UserId == userId).ToList();
//        }

//        public RegionModel GetRegionById(int regionId, Guid userId)
//        {
//            return DataHelper.GetAllRegions().FirstOrDefault(c => c.UserId == userId && c.Id == regionId);
//        }

//        public void SaveRegion(RegionModel region)
//        {
//            List<RegionModel> regions = DataHelper.GetAllRegions().ToList();
//            regions.Add(region);
//        }

//        public void UpdateRegionById(int regionId, RegionModel region, Guid userId)
//        {
//            var regionToUpdate = DataHelper.GetAllRegions().FirstOrDefault(c => c.UserId == userId && c.Id == regionId);
//            if (regionToUpdate != null)
//            {
//                List<RegionModel> regions = DataHelper.GetAllRegions().Where(c => c.UserId == userId).ToList();
//                int index = regions.FindIndex(s => s.Id == regionId);
//                regions[index] = region;
//            }
//            else
//            {
//                throw new Exception("Region not found");
//            }
//        }
//    }
//}
