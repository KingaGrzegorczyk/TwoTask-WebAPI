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
                var currentUser = HttpContext.User;

                location.UserId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
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
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            return Ok(_data.GetAllLocations(userId));
        }

        [HttpGet("{locationId}")]
        public IActionResult Get(int locationId)
        {
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            return Ok(_data.GetLocationById(locationId, userId));
        }

        [HttpPut("{locationId}")]
        public IActionResult Put(int locationId, [FromBody] LocationModel location)
        {
            try
            {
                var currentUser = HttpContext.User;
                var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                location.UserId = userId;

                _data.UpdateLocationById(locationId, location, userId);
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
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var result = _data.DeleteLocationById(locationId, userId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
