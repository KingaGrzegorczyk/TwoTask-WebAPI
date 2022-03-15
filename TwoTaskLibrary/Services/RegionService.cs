using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Services
{
    public interface IRegionService
    {
        bool SaveRegion(RegionModel region);
        IEnumerable<RegionModel> GetAllRegions(Guid userId);
        RegionModel GetRegionById(int regionId, Guid userId);
        bool UpdateRegionById(int regionId, RegionModel region, Guid userId);
        bool RemoveRegionById(int regionId, Guid userId);
    }
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }
        public bool SaveRegion(RegionModel region)
        {
            return _regionRepository.SaveRegion(region);
        }
        public IEnumerable<RegionModel> GetAllRegions(Guid userId)
        {
            return _regionRepository.GetAllRegions(userId);
        }
        public RegionModel GetRegionById(int regionId, Guid userId)
        {
            return _regionRepository.GetRegionById(regionId, userId);
        }
        public bool UpdateRegionById(int regionId, RegionModel region, Guid userId)
        {
            if (_regionRepository.IsRegionExists(regionId, userId))
                return _regionRepository.UpdateRegionById(regionId, region, userId);
            else
                return false;
        }
        public bool RemoveRegionById(int regionId, Guid userId)
        {
            if (_regionRepository.IsRegionExists(regionId, userId))
                return _regionRepository.RemoveRegionById(regionId, userId);
            else
                return false;
        }

    }
}
