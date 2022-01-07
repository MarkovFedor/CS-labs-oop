using Microsoft.EntityFrameworkCore;
using Reports.API.Domain.Models;

namespace Reports.API.Persistence.Contexts
{
    public class ReportAppContext : DbContext
    {
        public DbSet<TaskModel> TaskModels { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskChange> TaskChanges { get; set; }
        
        public ReportAppContext()
        {
        }

        public ReportAppContext(DbContextOptions<ReportAppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}