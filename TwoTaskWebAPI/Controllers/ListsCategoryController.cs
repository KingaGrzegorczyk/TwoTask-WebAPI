using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using TwoTaskLibrary.Services;
using TwoTaskWebAPI.Extensions;

namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class ListsCategoryController : ControllerBase
    {
        private readonly IListsCategoryService _listsCategoryService;
        private readonly ILogger<ListsCategoryController> _logger;

        public ListsCategoryController(ILogger<ListsCategoryController> logger, IListsCategoryService listsCategoryService)
        {
            _listsCategoryService = listsCategoryService;
            _logger = logger;
        }

        [NonAction]
        public Guid GetCurrentUserId()
        {
            return HttpContext.GetUserId();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ListsCategoryModel category)
        {
            var result = _listsCategoryService.SaveListsCategory(category);

            return !result ? (IActionResult)NoContent() : Ok();           
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_listsCategoryService.GetAllListsCategories(GetCurrentUserId()));
        }

        [HttpGet("{categoryId}")]
        public IActionResult Get(int categoryId)
        {
            return Ok(_listsCategoryService.GetListsCategoryById(categoryId, GetCurrentUserId()));
        }

        [HttpPut("{categoryId}")]
        public IActionResult Put(int categoryId, [FromBody] ListsCategoryModel category)
        {
            var result = _listsCategoryService.UpdateListsCategoryById(categoryId, category, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();           
        }

        [HttpDelete("{categoryId}")]
        public IActionResult Delete(int categoryId)
        {
            var result = _listsCategoryService.RemoveListsCategoryById(categoryId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
