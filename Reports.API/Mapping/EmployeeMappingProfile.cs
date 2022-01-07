using AutoMapper;
using Reports.API.DTO;
using Reports.API.Domain.Models;

namespace Reports.API.Mapping
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
        }
    }
}