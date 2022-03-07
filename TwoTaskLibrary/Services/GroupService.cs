using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;

namespace TwoTaskLibrary.Services
{
    public class GroupService
    {
        private readonly SqlDataAccess _sql;

        public GroupService(SqlDataAccess sql)
        {
            _sql = sql;
        }
        public bool IsGroupExists(int groupId)
        {
            var group = _sql.LoadData<GroupModel, object>("dbo.spGroup_GetById", new { Id = groupId }, "ConnectionStrings:TwoTaskData").FirstOrDefault();
            if (group != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int? GetUserInGroupId(int groupId, Guid userId)
        {
            var userInGroup = _sql.LoadData<GroupModel, object>("dbo.spUsersInGroup_GetById", new { GroupId = groupId, UserId = userId }, "ConnectionStrings:TwoTaskData").FirstOrDefault(); 
            if (userInGroup != null)
            {
                return userInGroup.Id;
            }
            else
            {
                return null;
            }
        }
    }
}
