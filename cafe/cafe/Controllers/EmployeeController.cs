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
        public async Task<ActionResult<ReadEmployeeDTO>> GetAllEmployees()
        {
            return Ok(await _service.GetAllEmployees());
        }
        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<ReadEmployeeDTO>> CreateEmployee([FromBody] CreateEmployeeDTO dto)
        {
            return Ok(await _service.CreateEmployee(dto));
        }
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<ReadEmployeeDTO>> UpdateEmployee([FromBody] UpdateEmployeeDTO dto)
        {
            return Ok(await _service.UpdateEmployee(dto));
        }
        [HttpDelete("DeleteEmployee")]
        public async Task<ActionResult> DeleteEmployee([FromBody] ReadEmployeeDTO dto)
        {
            await _service.DeleteEmployee(dto);
            return Ok();
        }
        [HttpPost("PaySalary")]
        public async Task<ActionResult<ReadEmployeeDTO>> PaySalary([FromBody] UpdateEmployeeDTO dto)
        {
            return Ok(await _service.PaySalary(dto));
        }
    }
}

