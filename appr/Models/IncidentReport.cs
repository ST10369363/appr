using System;
using System.ComponentModel.DataAnnotations;

namespace appr.Models
{
    public class IncidentReport
    {
        [Key]
        public int IncidentID { get; set; }

        [Required]
        public string Severity { get; set; } = string.Empty;

        [Required]
        public string IncidentLevel { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        public DateTime ReportedDate { get; set; } = DateTime.Now;
    }
}
