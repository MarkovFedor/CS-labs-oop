using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.API.DTO;

namespace Reports.API.Domain.Services
{
    public interface ITaskChangeService
    {
        Task CreateTaskChangeAsync(TaskChangeDto taskChange);
        Task<IEnumerable<TaskChangeDto>> GetAllAsync();
        Task<IEnumerable<TaskChangeDto>> GetAllForTaskByIdAsync(Int32 taskId);
    }
}