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
    public interface IRegionRepository
    {
        bool IsRegionExists(int regionId, Guid userId);
        bool SaveRegion(RegionModel region);
        IEnumerable<RegionModel> GetAllRegions(Guid userId);
        RegionModel GetRegionById(int regionId, Guid userId);
        bool UpdateRegionById(int regionId, RegionModel region, Guid userId);
        bool RemoveRegionById(int regionId, Guid userId);
    }
    public class RegionRepository : IRegionRepository
    {
        private readonly ISqlDataFactory _sqlDataFactory;

        public RegionRepository(ISqlDataFactory sqlDataFactory)
        {
            _sqlDataFactory = sqlDataFactory;
        }
        public bool IsRegionExists(int regionId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, [Name], UserId FROM [dbo].[Region] WHERE Id = @Id AND UserId = @UserId; ";

            var region = connection.Query<RegionModel>(sql, new { Id = regionId, UserId = userId }).Single();

            return region != null;
        }
        public bool SaveRegion(RegionModel region)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	INSERT INTO [dbo].[Region]([Name], UserId) VALUES(@Name, @UserId); ";

            connection.Execute(sql, new { Name = region.Name, UserId = region.UserId });

            return true;
        }
        public IEnumerable<RegionModel> GetAllRegions(Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, [Name], UserId FROM [dbo].[Region] WHERE UserId = @UserId ORDER BY Id; ";

            var regions = connection.Query<RegionModel>(sql, new { UserId = userId });

            return regions;
        }
        public RegionModel GetRegionById(int regionId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, [Name], UserId FROM [dbo].[Region] WHERE Id = @Id AND UserId = @UserId; ";

            var region = connection.Query<RegionModel>(sql, new { Id = regionId, UserId = userId }).Single();

            return region;
        }
        public bool UpdateRegionById(int regionId, RegionModel region, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	UPDATE [dbo].[Region] SET[Name] = @Name, UserId = @UserId WHERE Id = @Id AND UserId = @UserId; ";

            connection.Execute(sql, new { Id = regionId, Name = region.Name, UserId = userId });

            return true;
        }
        public bool RemoveRegionById(int regionId, Guid userId)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	DELETE FROM [dbo].[Region] WHERE Id = @Id AND UserId = @UserId; ";

            connection.Execute(sql, new { Id = regionId, UserId = userId });

            return true;
        }
    }
}
