using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.API.DTO;
using Reports.API.Domain.Services;

namespace Reports.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployeesAsync()
        {
            var result = await _employeeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeByIdAsync(Int32 id)
        {
            var result = await _employeeService.GetEmployeeAsync(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult> CreateEmployeeAsync(EmployeeDto employee)
        {
            await _employeeService.CreateEmployeeAsync(employee);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateEmployeeAsync(EmployeeDto employee)
        {
            await _employeeService.UpdateEmployeeAsync(employee);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> DeleteEmployeeAsync(Int32 id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}
