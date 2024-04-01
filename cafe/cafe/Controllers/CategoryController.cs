using cafe.Domain.Category.DTO;
using cafe.Domain.Category.Service;
using cafe.Domain.Common;
using cafe.Utils;
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
        public async Task<IActionResult> GetCategories()
        {
            var result = await _service.GetCategories();
            return result.ToResultResponse();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO categoryDto)
        {
            var result = await _service.CreateCategory(categoryDto);
            return result.ToResultResponse();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDTO updateCategoryDto)
        {
            var result = await _service.UpdateCategory(updateCategoryDto);
            return result.ToResultResponse();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCategory([FromBody] UpdateCategoryDTO updateCategoryDto)
        {
            var result = await _service.DeleteCategory(updateCategoryDto);
            return result.ToResultResponse();
        }
    }
}

