using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Services
{
    public class RegionService
    {
        private readonly SqlDataAccess _sql;

        public RegionService(SqlDataAccess sql)
        {
            _sql = sql;
        }

        public bool IsRegionExists(int regionId, Guid userId)
        {
            var region = _sql.LoadData<RegionModel, object>("dbo.spRegion_GetById", new { Id = regionId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (region != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
