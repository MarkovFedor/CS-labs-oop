using AutoMapper;
using Reports.API.DTO;
using Reports.API.Domain.Models;

namespace Reports.API.Mapping
{
    public class TaskChangeMappingProfile : Profile
    {
        public TaskChangeMappingProfile()
        {
            CreateMap<TaskChange, TaskChangeDto>();
            CreateMap<TaskChangeDto, TaskChange>();
        }
    }
}