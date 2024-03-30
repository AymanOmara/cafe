using cafe.Application.Features.Meal.DTO;
using cafe.Domain.Features.Meal.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class MealController : ControllerBase
    {
        private readonly IMealService _service;
        public MealController(IMealService service)
        {
            _service = service;
        }

        [HttpGet("Meals")]
        public async Task<ActionResult> GetAllMeals()
        {
            return Ok(await _service.GetAllMeals());
        }

        [HttpPost("AddMeal")]
        public async Task<ActionResult<ReadOnlyMealDto>> AddMeal([FromBody] WriteOnlyMealDto dto)
        {
            return Ok(await _service.AddMeal(dto));
        }
        [HttpPut("UpdateMeal")]
        public async Task<ActionResult<ReadOnlyMealDto>> UpdateMeal([FromBody] UpdateOnlyMealDto dto)
        {
            return Ok(await _service.UpdateMeal(dto));
        }

        [HttpDelete("DeleteMeal")]
        public async Task<ActionResult<ReadOnlyMealDto>> DeleteMeal([FromBody] UpdateOnlyMealDto dto)
        {
            await _service.DeleteMeal(dto);
            return Ok();
        }
    }
}

