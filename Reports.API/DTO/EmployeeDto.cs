using System;
using System.Collections.Generic;
using AutoMapper;
using Reports.API.Mapping;
using Reports.API.Domain.Models;
namespace Reports.API.DTO
{
    public class EmployeeDto
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32? LeaderId { get; set; }
    }

    public static class EmployeeMapper
    {
        private static Mapper _toDtoMapper;
        private static Mapper _fromDtoMapper;
        public static Mapper GetToDtoMapper() => _toDtoMapper ??= new Mapper
        (new MapperConfiguration(cfg =>
            cfg.CreateMap<Employee, EmployeeDto>()));

        public static Mapper GetFromDtoMapper() => _fromDtoMapper ??= new Mapper
        (new MapperConfiguration(cfg =>
            cfg.CreateMap<EmployeeDto, Employee>()));
    }
}