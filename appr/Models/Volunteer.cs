using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appr.Models // Adjust namespace if necessary
{
    public class Volunteer
    {
        [Key]
        public int VolunteerID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(50)]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        public int? Age { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        public string? Reason { get; set; }

        [Display(Name = "Criminal Record")]
        public bool CriminalRecord { get; set; }

        [Display(Name = "Accept to Volunteer")]
        public bool Accept { get; set; }

        // Foreign Key
        public int? TaskID { get; set; }

        [ForeignKey(nameof(TaskID))]
        public appr.Models.Task? Task { get; set; } // Navigation property

        public DateTime DateApplied { get; set; } = DateTime.Now;
    }
}