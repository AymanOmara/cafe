using cafe.Domain.Meal.DTO;
using cafe.Domain.Meal.Service;
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
            try
            {
                return Ok(_service.UpdateMeal(dto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("DeleteMeal")]
        public ActionResult<ReadOnlyMealDto> DeleteMeal([FromBody]  UpdateOnlyMealDto dto)
        {
            try
            {
                _service.DeleteMeal(dto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

