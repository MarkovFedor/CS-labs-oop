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
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ReportDto>>> GetAllReportsAsync()
        {
            var result = await _reportService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDto>> GetReportByIdAsync(Int32 id)
        {
            var result = await _reportService.GetReportAsync(id);
            return Ok(result);
        }

        [HttpGet("sprint")]
        public async Task<ActionResult<ReportDto>> GetSprintReportAsync(Int32 id)
        {
            var result = await _reportService.GetSprintReportAsync();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult> CreateReportAsync(ReportDto report)
        {
            await _reportService.CreateReportAsync(report);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateReportAsync(ReportDto report)
        {
            await _reportService.UpdateReportAsync(report);
            return Ok();
        }

        [HttpGet("has-sprint")]
        public async Task<ActionResult<Boolean>> HasSprintReportAsync()
        {
            var result = await _reportService.HasSprintReportAsync();
            return Ok(result);
        }
    }
}
