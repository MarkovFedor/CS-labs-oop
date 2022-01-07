using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Reports.API.DTO;
using Reports.API.Domain.Models;

namespace Reports.API.Mapping
{
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<TaskModel, TaskDto>();
            CreateMap<TaskDto, TaskModel>();
        }
    }
}
