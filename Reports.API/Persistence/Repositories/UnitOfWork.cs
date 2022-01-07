using System;
using System.Threading.Tasks;
using Reports.API.Persistence.Contexts;
using Reports.API.Domain.Services;
using Reports.API.Domain.Repositories;

namespace Reports.API.Persistence.Repositories
{
    public class UnitOfWork : ReportAppContext
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public UnitOfWork()
        {
            _taskRepository = new TaskRepository(this);
            _reportRepository = new ReportRepository(this);
            _employeeRepository = new EmployeeRepository(this);
        }

        public ITaskRepository TaskRepository => _taskRepository;
        public IReportRepository ReportRepository => _reportRepository;
        public IEmployeeRepository EmployeeRepository => _employeeRepository;
        
        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }
}