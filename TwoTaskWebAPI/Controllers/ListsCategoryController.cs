using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Internal.DataAccess;
using TwoTaskLibrary.Models;


namespace TwoTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(_data.GetAllListsCategories());
        }

        [HttpGet("{categoryId}")]
        public IActionResult Get(int categoryId)
        {
            return Ok(_data.GetListsCategoryById(categoryId));
        }

        [HttpPut("{categoryId}")]
        public IActionResult Put(int categoryId, [FromBody] ListsCategoryModel category)
        {
            try
            {
                _data.UpdateListsCategoryById(categoryId, category);
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
            var result = _data.DeleteListsCategoryById(categoryId);

            return !result ? (IActionResult)NoContent() : Ok();
        }
    }
}
