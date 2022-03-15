using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using TwoTaskLibrary.Services;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        private readonly ILogger<RegionController> _logger;

        public RegionController(ILogger<RegionController> logger, IRegionService regionService)
        {
            _regionService = regionService;
            _logger = logger;
        }

        [NonAction]
        public virtual Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RegionModel region)
        {
            var result = _regionService.SaveRegion(region);

            return !result ? (IActionResult)NoContent() : Ok();         
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_regionService.GetAllRegions(GetCurrentUserId()));
        }

        [HttpGet("{regionId}")]
        public IActionResult Get(int regionId)
        {
            return Ok(_regionService.GetRegionById(regionId, GetCurrentUserId()));
        }

        [HttpPut("{regionId}")]
        public IActionResult Put(int regionId, [FromBody] RegionModel region)
        {
            var result = _regionService.UpdateRegionById(regionId, region, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }

        [HttpDelete("{regionId}")]
        public IActionResult Delete(int regionId)
        {
            var result = _regionService.RemoveRegionById(regionId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
