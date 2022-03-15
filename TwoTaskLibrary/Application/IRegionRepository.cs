using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public interface IRegionRepository
    {
        bool IsRegionExists(int regionId, Guid userId);
        bool SaveRegion(RegionModel region);
        IEnumerable<RegionModel> GetAllRegions(Guid userId);
        RegionModel GetRegionById(int regionId, Guid userId);
        bool UpdateRegionById(int regionId, RegionModel region, Guid userId);
        bool RemoveRegionById(int regionId, Guid userId);
    }
}
