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
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public TaskService(ReportAppContext context, IMapper mapper)
        {
            _taskRepository = new TaskRepository(context);
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            var taskEntities = await _taskRepository.GetAllAsync();
            return taskEntities
                .Select(taskEntity => _mapper.Map<TaskDto>(taskEntity))
                .ToList();
        }

        public async Task<TaskDto> GetTaskAsync(Int32 id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            return _mapper.Map<TaskDto>(task);
        }

        public async System.Threading.Tasks.Task CreateTaskAsync(TaskDto task)
        {
            var taskEntity = _mapper.Map<Domain.Models.TaskModel>(task);
            await _taskRepository.InsertAsync(taskEntity);
            await _taskRepository.SaveAsync();
        }

        public async System.Threading.Tasks.Task UpdateTaskAsync(TaskDto task)
        {
            var taskEntity = _mapper.Map<Domain.Models.TaskModel>(task);
            await _taskRepository.UpdateAsync(taskEntity);
            await _taskRepository.SaveAsync();
        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(Int32 id)
        {
            await _taskRepository.DeleteAsync(id);
            await _taskRepository.SaveAsync();
        }
    }
}