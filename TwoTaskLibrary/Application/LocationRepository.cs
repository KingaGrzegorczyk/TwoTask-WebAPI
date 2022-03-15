using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Models;
using TwoTaskLibrary.Services;

namespace TwoTaskLibrary.Application
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ISqlDataFactory _sqlDataFactory;

        public LocationRepository(ISqlDataFactory sqlDataFactory)
        {
            _sqlDataFactory = sqlDataFactory;
        }
        public bool IsLocationExists(int locationId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, RegionId, Latitude, Longitude, Radius, UserId FROM[dbo].[Location] WHERE Id = @Id AND UserID = @UserId; ";

            var location = connection.Query<GroupModel>(sql, new { Id = locationId, UserId = userId });

            return location != null;
        }
        public bool SaveLocation(LocationModel location)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	INSERT INTO dbo.[Location](RegionId, Latitude, Longitude, Radius, UserId) VALUES(@RegionId, @Latitude, @Longitude, @Radius, @UserId); ";

            connection.Execute(sql, new { RegionId = location.RegionId, Latitude = location.Latitude, Longitude = location.Longitude, Radius = location.Radius, UserId = location.UserId });

            return true;
        }
        public IEnumerable<LocationModel> GetAllLocations(Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, RegionId, Latitude, Longitude, Radius, UserId FROM[dbo].[Location] WHERE UserId = @UserId ORDER BY Id; ";

            var locations = connection.Query<LocationModel>(sql, new { UserId = userId });

            return locations;
        }
        public LocationModel GetLocationById(int locationId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, RegionId, Latitude, Longitude, Radius, UserId FROM[dbo].[Location] WHERE Id = @Id AND UserID = @UserId; ";

            var location = connection.Query<LocationModel>(sql, new { Id = locationId, UserId = userId }).Single();

            return location;
        }
        public bool UpdateLocationById(int locationId, LocationModel location, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	UPDATE dbo.[Location] SET RegionId = @RegionId, Latitude = @Latitude, Longitude = @Longitude, Radius = @Radius, UserId = @UserId WHERE Id = @Id AND UserId = @UserId; ";

            connection.Execute(sql, new { Id = locationId, RegionId = location.RegionId, Latitude = location.Latitude, Longitude = location.Longitude, Radius = location.Radius, UserId = location.UserId });

            return true;
        }
        public bool RemoveLocationById(int locationId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	DELETE FROM dbo.[Location] WHERE Id = @Id AND UserId = @UserId; ";

            connection.Execute(sql, new { Id = locationId, UserId = userId });

            return true;
        }
    }
}
