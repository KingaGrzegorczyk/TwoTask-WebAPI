using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using TwoTaskLibrary.Services;
using TwoTaskWebAPI.Extensions;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILogger<LocationController> logger, ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        [NonAction]
        public Guid GetCurrentUserId()
        {
            return HttpContext.GetUserId();
        }

        [HttpPost]
        public IActionResult Post([FromBody] LocationModel location)
        {
            var result = _locationService.SaveLocation(location);

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_locationService.GetAllLocations(GetCurrentUserId()));
        }

        [HttpGet("{locationId}")]
        public IActionResult Get(int locationId)
        {
            return Ok(_locationService.GetLocationById(locationId, GetCurrentUserId()));
        }

        [HttpPut("{locationId}")]
        public IActionResult Put(int locationId, [FromBody] LocationModel location)
        {
            var result = _locationService.UpdateLocationById(locationId, location, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpDelete("{locationId}")]
        public IActionResult Delete(int locationId)
        {
            var result = _locationService.RemoveLocationById(locationId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
