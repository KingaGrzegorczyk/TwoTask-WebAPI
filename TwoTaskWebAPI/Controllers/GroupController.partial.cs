using Microsoft.AspNetCore.Mvc;

namespace TwoTaskWebAPI.Controllers
{
    public partial class GroupController
    {
        [NonAction]
        public virtual Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
        }
    }
}
