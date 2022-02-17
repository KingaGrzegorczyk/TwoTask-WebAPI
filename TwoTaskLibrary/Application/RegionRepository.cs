using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public class RegionRepository : IRegionRepository
    {
        private readonly SqlDataAccess _sql;

        public RegionRepository(SqlDataAccess sql)
        {
            _sql = sql;
        }
        public void SaveRegion(RegionModel region)
        {
            _sql.SaveData("dbo.spRegion_Insert", region, "ConnectionStrings:TwoTaskData");
        }
        public List<RegionModel> GetAllRegions()
        {
            var output = _sql.LoadData<RegionModel, dynamic>("dbo.spRegion_GetAll", new { }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public RegionModel GetRegionById(int regionId)
        {
            var output = _sql.LoadData<RegionModel, dynamic>("dbo.spRegion_GetById", new { Id = regionId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();

            return output;
        }
        public void UpdateRegionById(int regionId, RegionModel region)
        {
            var regionToUpdate = _sql.LoadData<RegionModel, dynamic>("dbo.spRegion_GetById", new { Id = regionId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (regionToUpdate != null)
            {
                _sql.UpdateData("dbo.spRegion_UpdateById", region, "ConnectionStrings:TwoTaskData");
            }
            else
            {
                throw new Exception("Region not found");
            }
        }
        public bool DeletegionById(int regionId)
        {
            var regionToDelete = _sql.LoadData<RegionModel, dynamic>("dbo.spRegion_GetById", new { Id = regionId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (regionToDelete == null)
                return false;
            else
            {
                _sql.DeleteData("dbo.spRegion_DeleteById", new { Id = regionId }, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
    }
}
