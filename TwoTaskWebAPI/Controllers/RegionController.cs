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
        private readonly RegionRepository _data;

        public RegionController()
        {
            _sql = new SqlDataAccess();
            _data = new RegionRepository(_sql);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RegionModel region)
        {
            try
            {
                var currentUser = HttpContext.User;

                region.UserId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                _data.SaveRegion(region);

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
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            return Ok(_data.GetAllRegions(userId));
        }

        [HttpGet("{regionId}")]
        public IActionResult Get(int regionId)
        {
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            return Ok(_data.GetRegionById(regionId, userId));
        }

        [HttpPut("{regionId}")]
        public IActionResult Put(int regionId, [FromBody] RegionModel region)
        {
            try
            {
                var currentUser = HttpContext.User;
                var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                region.UserId = userId;

                _data.UpdateRegionById(regionId, region, userId);
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
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var result = _data.DeletegionById(regionId, userId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
