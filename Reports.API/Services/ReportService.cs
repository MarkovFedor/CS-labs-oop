using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Reports.API.DTO;
using Reports.API.Domain.Services;
using Reports.API.Domain.Models;
using Reports.API.Domain.Repositories;
using Reports.API.Persistence.Contexts;
using Reports.API.Persistence.Repositories;

namespace Reports.API.Services
{
    public class ReportService : IReportService
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _repository;

        public ReportService(ReportAppContext context, IMapper mapper)
        {
            _repository = new ReportRepository(context);
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReportDto>> GetAllAsync()
        {
            var reportEntities = await _repository.GetAllAsync();
            return reportEntities
                .Select(reportEntity => _mapper.Map<ReportDto>(reportEntity))
                .ToList();
        }

        public async Task<ReportDto> GetReportAsync(Int32 id)
        {
            var report = await _repository.GetByIdAsync(id);
            return _mapper.Map<ReportDto>(report);
        }

        public async Task CreateReportAsync(ReportDto report)
        {
            var reportEntity = _mapper.Map<Report>(report);
            if (await _repository.HasSprintReportAsync()) return;
            await _repository.InsertAsync(reportEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateReportAsync(ReportDto report)
        {
            var reportEntity = _mapper.Map<Report>(report);
            await _repository.UpdateAsync(reportEntity);
            await _repository.SaveAsync();
        }

        public async Task DeleteReportAsync(Int32 id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }

        public async Task<Boolean> HasSprintReportAsync()
        {
            return await _repository.HasSprintReportAsync();
        }

        public async Task<ReportDto> GetSprintReportAsync()
        {
            var reports = await _repository.GetAllAsync();
            return _mapper.Map<ReportDto>(reports
                .ToList()
                .FirstOrDefault(r => r.Type == ReportType.Sprint)
            );
        }
    }
}