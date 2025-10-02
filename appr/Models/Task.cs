using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appr.Models // Adjust namespace if necessary
{
    public class Task
    {
        [Key] // Denotes the primary key
        public int TaskID { get; set; }

        [Required(ErrorMessage = "Task Name is required.")]
        [StringLength(100)]
        public string TaskName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Location { get; set; }

        [StringLength(255)]
        public string? SkillsNeeded { get; set; }

        // Automatically set by the database using GETDATE() or in the C# code
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}