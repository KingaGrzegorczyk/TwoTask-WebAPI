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
        private readonly ListsCategoryRepository _data;

        public ListsCategoryController()
        {
            _sql = new SqlDataAccess();
            _data = new ListsCategoryRepository(_sql);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ListsCategoryModel category)
        {
            try
            {
                var currentUser = HttpContext.User;

                category.UserId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                _data.SaveListsCategory(category);

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

            return Ok(_data.GetAllListsCategories(userId));
        }

        [HttpGet("{categoryId}")]
        public IActionResult Get(int categoryId)
        {
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            return Ok(_data.GetListsCategoryById(categoryId, userId));
        }

        [HttpPut("{categoryId}")]
        public IActionResult Put(int categoryId, [FromBody] ListsCategoryModel category)
        {
            try
            {
                var currentUser = HttpContext.User;
                var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                category.UserId = userId;

                _data.UpdateListsCategoryById(categoryId, category, userId);
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
            var currentUser = HttpContext.User;
            var userId = Guid.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var result = _data.DeleteListsCategoryById(categoryId, userId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
