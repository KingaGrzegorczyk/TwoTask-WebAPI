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
        protected ILocationRepository Data { get; set; }
        private readonly ILogger<LocationRepository> _logger;

        public LocationController(ILogger<LocationRepository> logger)
        {
            _sql = new SqlDataAccess();
            _logger = logger;
            Data = new LocationRepository(_sql, _logger);
        }

        [NonAction]
        public virtual Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LocationModel location)
        {
            location.UserId = GetCurrentUserId();
            var result = Data.SaveLocation(location);

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Data.GetAllLocations(GetCurrentUserId()));
        }

        [HttpGet("{locationId}")]
        public IActionResult Get(int locationId)
        {
            return Ok(Data.GetLocationById(locationId, GetCurrentUserId()));
        }

        [HttpPut("{locationId}")]
        public IActionResult Put(int locationId, [FromBody] LocationModel location)
        {
            location.UserId = GetCurrentUserId();
            var result = Data.UpdateLocationById(locationId, location, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpDelete("{locationId}")]
        public IActionResult Delete(int locationId)
        {
            var result = Data.RemoveLocationById(locationId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
