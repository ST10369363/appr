using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appr.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
