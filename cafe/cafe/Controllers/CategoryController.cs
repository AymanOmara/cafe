using cafe.Domain.Category.DTO;
using cafe.Domain.Category.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        //api token name 
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("Categories")]
        public async Task<ActionResult> GetCategories()
        {
            return Ok(await _service.GetCategories());
        }
        [HttpPost("Create")]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryDTO categoryDto)
        {
            return Ok(await _service.CreateCategory(categoryDto));
        }
        [HttpPut("Update")]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryDTO updateCategoryDto)
        {
            return Ok(await _service.UpdateCategory(updateCategoryDto));
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteCategory([FromBody] UpdateCategoryDTO updateCategoryDto)
        {
            await _service.DeleteCategory(updateCategoryDto);
            return Ok();
        }
    }
}

