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
        void SaveRegion(RegionModel region);
        List<RegionModel> GetAllRegions(Guid userId);
        RegionModel GetRegionById(int regionId, Guid userId);
        void UpdateRegionById(int regionId, RegionModel region, Guid userId);
        bool DeletegionById(int regionId, Guid userId);
    }
}
