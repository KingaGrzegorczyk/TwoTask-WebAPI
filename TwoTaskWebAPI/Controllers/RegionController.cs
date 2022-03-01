using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;
using Microsoft.AspNetCore.Authorization;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class RegionController : ControllerBase
    {
        private readonly SqlDataAccess _sql;
        protected IRegionRepository Data { get; set; }

        public RegionController()
        {
            _sql = new SqlDataAccess();
            Data = new RegionRepository(_sql);
        }

        [NonAction]
        public virtual Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RegionModel region)
        {
            try
            {
                region.UserId = GetCurrentUserId();
                Data.SaveRegion(region);

                return Ok();
            }
            catch (Exception)
            {

                return NoContent();
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Data.GetAllRegions(GetCurrentUserId()));
        }

        [HttpGet("{regionId}")]
        public IActionResult Get(int regionId)
        {
            return Ok(Data.GetRegionById(regionId, GetCurrentUserId()));
        }

        [HttpPut("{regionId}")]
        public IActionResult Put(int regionId, [FromBody] RegionModel region)
        {
            try
            {
                region.UserId = GetCurrentUserId();

                Data.UpdateRegionById(regionId, region, GetCurrentUserId());
                return Ok();
            }
            catch (Exception)
            {
                return NoContent();
            }

        }

        [HttpDelete("{regionId}")]
        public IActionResult Delete(int regionId)
        {
            var result = Data.DeletegionById(regionId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
