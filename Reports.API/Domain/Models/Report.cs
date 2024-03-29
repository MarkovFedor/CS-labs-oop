﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reports.API.Domain.Models
{
    public class Report
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public String Body { get; set; }
        public ReportType Type { get; set; }
        public Int32 TaskId { get; set; }
        public Int32 EmployeeId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChangeDate { get; set; }
    }
}