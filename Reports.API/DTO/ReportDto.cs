﻿using System;
using AutoMapper;
using Reports.API.Domain.Models;

namespace Reports.API.DTO
{
    public class ReportDto
    {
        public Int32 Id { get; set; }
        public String Body { get; set; }
        public ReportType Type { get; set; }
        public Int32 TaskId { get; set; }
        public Int32 EmployeeId { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public DateTime? LastChangeDate { get; set; } = DateTime.Now;
    }
}