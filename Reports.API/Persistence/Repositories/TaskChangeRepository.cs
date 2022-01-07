using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.API.Domain.Repositories;
using Reports.API.Domain.Models;
using Reports.API.Domain.Services;
using Reports.API.Persistence.Contexts;

namespace Reports.API.Persistence.Repositories
{
    public class TaskChangeRepository : ITaskChangeRepository
    {
        private readonly ReportAppContext _context;

        public TaskChangeRepository(ReportAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskChange>> GetAllAsync()
        {
            return await _context.TaskChanges.ToListAsync();
        }

        public async Task<TaskChange> GetByIdAsync(Int32 id)
        {
            return await _context.TaskChanges.FindAsync(id);
        }

        public async Task InsertAsync(TaskChange taskChange)
        {
            await _context.AddAsync(taskChange);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskChange taskChange)
        {
            _context.Entry(taskChange).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Int32 id)
        {
            await _context.TaskChanges.DeleteTaskAsync(id);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }

    public static class TaskChangeRepositoryExtensions
    {
        public static async Task DeleteTaskAsync(this DbSet<TaskChange> taskChanges, Int32 id)
        {
            var taskChange = await taskChanges.FindAsync(id);
            await Task.Run(() => taskChanges.Remove(taskChange));
        }
    }
}