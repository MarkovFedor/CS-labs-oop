using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.API.Persistence.Contexts;
using Reports.API.Domain.Models;
using Reports.API.Domain.Services;
using Reports.API.Domain.Repositories;

namespace Reports.API.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ReportAppContext _context;

        public TaskRepository(ReportAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskModel>> GetAllAsync()
        {
            return await _context.TaskModels.ToListAsync();
        }

        public async Task<TaskModel> GetByIdAsync(Int32 id)
        {
            return await _context.TaskModels.FindAsync(id);
        }

        public async System.Threading.Tasks.Task InsertAsync(Domain.Models.TaskModel task)
        {
            await _context.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(Domain.Models.TaskModel task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(Int32 id)
        {
            await _context.TaskModels.DeleteTaskAsync(id);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }

    public static class TaskRepositoryExtensions
    {
        public static async System.Threading.Tasks.Task DeleteTaskAsync(this DbSet<Domain.Models.TaskModel> tasks, Int32 id)
        {
            var task = await tasks.FindAsync(id);
            await Task.Run(() => tasks.Remove(task));
        }
    }
}