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
        List<RegionModel> GetAllRegions();
        RegionModel GetRegionById(int regionId);
        void UpdateRegionById(int regionId, RegionModel region);
        bool DeletegionById(int regionId);
    }
}
