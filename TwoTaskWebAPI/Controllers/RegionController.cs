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
            return Ok(_data.GetAllRegions());
        }

        [HttpGet("{regionId}")]
        public IActionResult Get(int regionId)
        {
            return Ok(_data.GetRegionById(regionId));
        }

        [HttpPut("{regionId}")]
        public IActionResult Put(int regionId, [FromBody] RegionModel region)
        {
            try
            {
                _data.UpdateRegionById(regionId, region);
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
            var result = _data.DeletegionById(regionId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
