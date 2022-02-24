using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Application
{
    public class LocationRepository : ILocationRepository
    {
        private readonly SqlDataAccess _sql;

        public LocationRepository(SqlDataAccess sql)
        {
            _sql = sql;
        }
        public void SaveLocation(LocationModel location)
        {
            _sql.SaveData("dbo.spLocation_Insert", location, "ConnectionStrings:TwoTaskData");
        }
        public List<LocationModel> GetAllLocations(Guid userId)
        {
            var output = _sql.LoadData<LocationModel, dynamic>("dbo.spLocation_GetAll", new { UserId = userId }, "ConnectionStrings:TwoTaskData");

            return output;
        }
        public LocationModel GetLocationById(int locationId, Guid userId)
        {
            var output = _sql.LoadData<LocationModel, dynamic>("dbo.spLocation_GetById", new { Id = locationId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();

            return output;
        }
        public void UpdateLocationById(int locationId, LocationModel location, Guid userId)
        {
            var locationToUpdate = _sql.LoadData<LocationModel, dynamic>("dbo.spLocation_GetById", new { Id = locationId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (locationToUpdate != null)
            {
                _sql.UpdateData("dbo.spLocation_UpdateById", location, "ConnectionStrings:TwoTaskData");
            }
            else
            {
                throw new Exception("Location not found");
            }
        }
        public bool DeleteLocationById(int locationId, Guid userId)
        {
            var locationToDelete = _sql.LoadData<LocationModel, dynamic>("dbo.spLocation_GetById", new { Id = locationId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (locationToDelete == null)
                return false;
            else
            {
                _sql.DeleteData("dbo.spLocation_DeleteById", new { Id = locationId, UserId = userId }, "ConnectionStrings:TwoTaskData");
                return true;
            }
        }
    }
}
