using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Services
{
    public class LocationService
    {
        private readonly SqlDataAccess _sql;

        public LocationService(SqlDataAccess sql)
        {
            _sql = sql;
        }

        public bool IsLocationExists(int locationId, Guid userId)
        {
            var location = _sql.LoadData<LocationModel, object>("dbo.spLocation_GetById", new { Id = locationId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (location != null)
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
