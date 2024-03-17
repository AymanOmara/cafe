
using cafe.Application.Features.Meal.DTO;
using cafe.Application.Features.Meal.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class MealController : Controller
    {
        private readonly IMealService _service;
        public MealController(IMealService service)
        {
            _service = service;
        }

        [HttpGet("Meals")]
        public ActionResult<IQueryable> GetAllMeals()
        {
            return Ok(_service.GetAllMeals());
        }

        [HttpPost("AddMeal")]
        public ActionResult<ReadOnlyMealDto> AddMeal([FromBody]  WriteOnlyMealDto dto)
        {
            return Ok(_service.AddMeal(dto));
        }
        [HttpPut("UpdateMeal")]
        public ActionResult<ReadOnlyMealDto> UpdateMeal([FromBody]UpdateOnlyMealDto dto)
        {
            return Ok(_service.UpdateMeal(dto));
        }

        [HttpDelete("DeleteMeal")]
        public ActionResult<ReadOnlyMealDto> DeleteMeal([FromBody]  UpdateOnlyMealDto dto)
        {
            _service.DeleteMeal(dto);
            return Ok();
        }
    }
}

