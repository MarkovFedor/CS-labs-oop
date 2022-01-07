using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.API.DTO;
using Reports.API.Domain.Services;

namespace Reports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<TaskDto>>> GetAllTasksAsync()
        {
            var result = await _taskService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("/byid/{id}")]
        public async Task<ActionResult<TaskDto>> GetTaskByIdAsync(Int32 id)
        {
            var result = await _taskService.GetTaskAsync(id);
            return Ok(result);
        }

        [HttpGet("/bydate/{date}")]
        public async Task<ActionResult<TaskDto>> GetTaskByDateAsync(DateTime date)
        {
            var tasks = await _taskService.GetAllAsync();
            var result = tasks.Where(t => t.StartDate == date);
            return Ok(result);
        }

        [HttpGet("/byemployeeId/{employeeId}")]
        public async Task<ActionResult<List<TaskDto>>> GetTasksByEmployeeIdAsync(Int32 employeeId)
        {
            var tasks = await _taskService.GetAllAsync();
            var result = tasks.Where(t => t.EmployeeId == employeeId);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult> CreateTaskAsync(TaskDto task)
        {
            await _taskService.CreateTaskAsync(task);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateTaskAsync(TaskDto task)
        {
            await _taskService.UpdateTaskAsync(task);
            return Ok();
        }

        [HttpPost("delete/{id}")]
        public async Task<ActionResult> DeleteTaskAsync(Int32 id)
        {
            await _taskService.DeleteTaskAsync(id);
            return Ok();
        }
    }
}
