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
    [ApiController]
    [Route("api/[controller]")]
    public class TaskChangeController : ControllerBase
    {
        private readonly ITaskChangeService _taskChangeService;

        public TaskChangeController(ITaskChangeService taskChangeService)
        {
            _taskChangeService = taskChangeService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<TaskChangeDto>>> GetAllTasksChangesAsync()
        {
            var result = await _taskChangeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{taskId}")]
        public async Task<ActionResult<List<TaskChangeDto>>> GetTaskByIdAsync(Int32 taskId)
        {
            var result = await _taskChangeService.GetAllForTaskByIdAsync(taskId);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult> CreateTaskChangeAsync(TaskChangeDto taskChange)
        {
            await _taskChangeService.CreateTaskChangeAsync(taskChange);
            return Ok();
        }
    }
}
