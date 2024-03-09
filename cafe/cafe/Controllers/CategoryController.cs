using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        public CategoryController()
        {
        }
        [HttpGet("Categories")]
        public ActionResult GetCategories()
        {
            return Ok();
        }
    }
}

