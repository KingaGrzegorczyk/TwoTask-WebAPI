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
    public class ListsCategoryController : ControllerBase
    {
        private readonly SqlDataAccess _sql;
        protected IListsCategoryRepository Data { get; set; }
        private readonly ILogger<ListsCategoryRepository> _logger;

        public ListsCategoryController(ILogger<ListsCategoryRepository> logger)
        {
            _sql = new SqlDataAccess();
            _logger = logger;
            Data = new ListsCategoryRepository(_sql, _logger);
        }

        [NonAction]
        public virtual Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ListsCategoryModel category)
        {
            category.UserId = GetCurrentUserId();
            var result = Data.SaveListsCategory(category);

            return !result ? (IActionResult)NoContent() : Ok();           
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Data.GetAllListsCategories(GetCurrentUserId()));
        }

        [HttpGet("{categoryId}")]
        public IActionResult Get(int categoryId)
        {
            return Ok(Data.GetListsCategoryById(categoryId, GetCurrentUserId()));
        }

        [HttpPut("{categoryId}")]
        public IActionResult Put(int categoryId, [FromBody] ListsCategoryModel category)
        {
            category.UserId = GetCurrentUserId();
            var result = Data.UpdateListsCategoryById(categoryId, category, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();           
        }

        [HttpDelete("{categoryId}")]
        public IActionResult Delete(int categoryId)
        {
            var result = Data.RemoveListsCategoryById(categoryId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
