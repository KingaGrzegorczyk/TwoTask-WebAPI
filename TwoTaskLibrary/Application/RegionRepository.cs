using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;
using TwoTaskLibrary.Services;

namespace TwoTaskLibrary.Application
{
    public class RegionRepository : IRegionRepository
    {
        private readonly SqlDataAccess _sql;
        private readonly RegionService _service;
        private readonly ILogger<RegionRepository> _logger;

        public RegionRepository(SqlDataAccess sql, ILogger<RegionRepository> logger)
        {
            _sql = sql;
            _service = new RegionService(_sql);
            _logger = logger;
        }
        public bool SaveRegion(RegionModel region)
        {
            try
            {
                _sql.SaveData("dbo.spRegion_Insert", region, "ConnectionStrings:TwoTaskData");
                return true;
            }
            catch (Exception)
            {
                return false;
            }           
        }
        public IEnumerable<RegionModel> GetAllRegions(Guid userId)
        {
            var output = _sql.LoadData<RegionModel, object>("dbo.spRegion_GetAll", new { UserId = userId }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public RegionModel GetRegionById(int regionId, Guid userId)
        {
            var output = _sql.LoadData<RegionModel, object>("dbo.spRegion_GetById", new { Id = regionId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();

            return output;
        }
        public bool UpdateRegionById(int regionId, RegionModel region, Guid userId)
        {
            if (!_service.IsRegionExists(regionId, userId))
            {
                _logger.LogWarning("Region not found");
                return false;
            }
            else
            {
                _sql.UpdateData("dbo.spRegion_UpdateById", region, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
        public bool RemoveRegionById(int regionId, Guid userId)
        {
            if (!_service.IsRegionExists(regionId, userId))
            {
                _logger.LogWarning("Region not found");
                return false;
            }
            else
            {
                _sql.DeleteData("dbo.spRegion_DeleteById", new { Id = regionId, UserId = userId }, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
    }
}
