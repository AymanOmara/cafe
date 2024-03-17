﻿using cafe.Domain.Category.DTO;
using cafe.Domain.Category.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("Categories")]
        public ActionResult GetCategories()
        {
            return Ok(_service.GetCategories());
        }
        [HttpPost("Create")]
        public ActionResult CreateCategory([FromBody] CreateCategoryDTO categoryDto)
        {
            return Ok(_service.CreateCategory(categoryDto));
        }
        [HttpPut("Update")]
        public ActionResult UpdateCategory([FromBody] UpdateCategoryDTO updateCategoryDto)
        {
            return Ok(_service.UpdateCategory(updateCategoryDto));
        }
        [HttpDelete("Delete")]
        public ActionResult DeleteCategory([FromBody] UpdateCategoryDTO updateCategoryDto)
        {
            _service.DeleteCategory(updateCategoryDto);
            return Ok();
        }
    }
}

