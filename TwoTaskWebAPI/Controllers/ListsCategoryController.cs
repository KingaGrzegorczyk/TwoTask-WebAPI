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

        public ListsCategoryController()
        {
            _sql = new SqlDataAccess();
            Data = new ListsCategoryRepository(_sql);
        }

        [NonAction]
        public virtual Guid GetCurrentUserId()
        {
            return Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ListsCategoryModel category)
        {
            try
            {
                category.UserId = GetCurrentUserId();
                Data.SaveListsCategory(category);

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
            try
            {
                category.UserId = GetCurrentUserId();

                Data.UpdateListsCategoryById(categoryId, category, GetCurrentUserId());
                return Ok();
            }
            catch (Exception)
            {
                return NoContent();
            }

        }

        [HttpDelete("{categoryId}")]
        public IActionResult Delete(int categoryId)
        {
            var result = Data.DeleteListsCategoryById(categoryId, GetCurrentUserId());

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
