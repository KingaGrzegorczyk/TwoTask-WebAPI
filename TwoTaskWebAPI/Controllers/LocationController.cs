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
    public class LocationController : ControllerBase
    {
        private readonly SqlDataAccess _sql;
        private readonly LocationRepository _data;

        public LocationController()
        {
            _sql = new SqlDataAccess();
            _data = new LocationRepository(_sql);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LocationModel location)
        {
            try
            {
                _data.SaveLocation(location);

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
            return Ok(_data.GetAllLocations());
        }

        [HttpGet("{locationId}")]
        public IActionResult Get(int locationId)
        {
            return Ok(_data.GetLocationById(locationId));
        }

        [HttpPut("{locationId}")]
        public IActionResult Put(int locationId, [FromBody] LocationModel location)
        {
            try
            {
                _data.UpdateLocationById(locationId, location);
                return Ok();
            }
            catch (Exception)
            {
                return NoContent();
            }

        }

        [HttpDelete("{locationId}")]
        public IActionResult Delete(int locationId)
        {
            var result = _data.DeleteLocationById(locationId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
