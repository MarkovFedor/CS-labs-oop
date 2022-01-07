using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reports.API.Domain.Models
{
    public class TaskChange
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public Int32 TaskId { get; set; }
        public DateTime Date { get; set; }
        public String Comment { get; set; }
    }
}