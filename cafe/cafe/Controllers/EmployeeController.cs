using cafe.Domain.Employee.Dto;
using cafe.Domain.Employee.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        [HttpGet("Employees")]
        public ActionResult<ReadEmployeeDTO> GetAllEmployees()
        {
            return Ok(_service.GetAllEmployees());
        }
        [HttpPost("CreateEmployee")]
        public ActionResult<ReadEmployeeDTO> CreateEmployee([FromBody] CreateEmployeeDTO dto)
        {
            return Ok(_service.CreateEmployee(dto));
        }
        [HttpPut("UpdateEmployee")]
        public ActionResult<ReadEmployeeDTO> UpdateEmployee([FromBody] UpdateEmployeeDTO dto)
        {
            return Ok(_service.UpdateEmployee(dto));
        }
        [HttpDelete("DeleteEmployee")]
        public ActionResult DeleteEmployee([FromBody] ReadEmployeeDTO dto)
        {
            _service.DeleteEmployee(dto);
            return Ok();
        }
        [HttpPost("PaySalary")]
        public ActionResult<ReadEmployeeDTO> PaySalary([FromBody] UpdateEmployeeDTO dto)
        {
            return Ok(_service.PaySalary(dto));
        }
    }
}

