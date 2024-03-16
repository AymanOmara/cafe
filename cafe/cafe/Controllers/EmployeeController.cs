using cafe.Domain.Employee.Dto;
using cafe.Domain.Employee.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        [HttpGet("Employees")]
        public ActionResult<ReadEmployeeDTO> GetAllEmployees() {
            return Ok(_service.GetAllEmployees());
        }
        [HttpPost("CreateEmployee")]
        public ActionResult<ReadEmployeeDTO> CreateEmployee([FromBody] CreateEmployeeDTO dto)
        {
            return Ok(_service.CreateEmployee(dto));
        }
    }
}

