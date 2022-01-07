using System;
using System.Threading.Tasks;
using Reports.API.Domain.Models;

namespace Reports.API.Domain.Repositories
{
    public interface IReportRepository : IGenericRepository<Report>
    {
        Task<Boolean> HasSprintReportAsync();
    }
}