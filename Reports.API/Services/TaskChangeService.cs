﻿using System;
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
    public class TaskChangeService : ITaskChangeService
    {
        private readonly IMapper _mapper;
        private readonly ITaskChangeRepository _taskChangeRepository;

        public TaskChangeService(ReportAppContext context, IMapper mapper)
        {
            _taskChangeRepository = new TaskChangeRepository(context);
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskChangeDto>> GetAllAsync()
        {
            var taskChangeEntities = await _taskChangeRepository.GetAllAsync();
            return taskChangeEntities
                .Select(taskChangeEntity => _mapper.Map<TaskChangeDto>(taskChangeEntity))
                .ToList(); ;
        }

        public async Task<IEnumerable<TaskChangeDto>> GetAllForTaskByIdAsync(Int32 taskId)
        {
            var taskChangeEntities = await _taskChangeRepository.GetAllAsync();
            return taskChangeEntities
                .Where(t => t.TaskId == taskId)
                .Select(taskChangeEntity => _mapper.Map<TaskChangeDto>(taskChangeEntity))
                .ToList(); ;
        }

        public async Task CreateTaskChangeAsync(TaskChangeDto taskChange)
        {
            var taskChangeEntity = _mapper.Map<TaskChange>(taskChange);
            await _taskChangeRepository.InsertAsync(taskChangeEntity);
            await _taskChangeRepository.SaveAsync();
        }
    }
}