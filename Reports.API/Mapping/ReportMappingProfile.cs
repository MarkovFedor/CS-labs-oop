using AutoMapper;
using Reports.API.DTO;
using Reports.API.Domain.Models;

namespace Reports.API.Mapping
{
    public class ReportMappingProfile : Profile
    {
        public ReportMappingProfile()
        {
            CreateMap<Report, ReportDto>();
            CreateMap<ReportDto, Report>();
        }
    }
}