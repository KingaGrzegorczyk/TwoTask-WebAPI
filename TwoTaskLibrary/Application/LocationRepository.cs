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
    public class LocationRepository : ILocationRepository
    {
        private readonly SqlDataAccess _sql;
        private readonly LocationService _service;
        private readonly ILogger<LocationRepository> _logger;
        public LocationRepository(SqlDataAccess sql, ILogger<LocationRepository> logger)
        {
            _sql = sql;
            _service = new LocationService(_sql);
            _logger = logger;
        }
        public bool SaveLocation(LocationModel location)
        {
            try
            {
                _sql.SaveData("dbo.spLocation_Insert", location, "ConnectionStrings:TwoTaskData");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<LocationModel> GetAllLocations(Guid userId)
        {
            var output = _sql.LoadData<LocationModel, object>("dbo.spLocation_GetAll", new { UserId = userId }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public LocationModel GetLocationById(int locationId, Guid userId)
        {
            var output = _sql.LoadData<LocationModel, object>("dbo.spLocation_GetById", new { Id = locationId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();

            return output;
        }
        public bool UpdateLocationById(int locationId, LocationModel location, Guid userId)
        {
            if (!_service.IsLocationExists(locationId, userId))
            {
                _logger.LogWarning("Location not found");
                return false;
            }
            else
            {
                _sql.UpdateData("dbo.spLocation_UpdateById", location, "ConnectionStrings:TwoTaskData");
                return true;
            }          
        }
        public bool RemoveLocationById(int locationId, Guid userId)
        {
            if (!_service.IsLocationExists(locationId, userId))
            {
                _logger.LogWarning("Location not found");
                return false;
            }
            else
            {
                _sql.DeleteData("dbo.spLocation_DeleteById", new { Id = locationId, UserId = userId }, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
    }
}
