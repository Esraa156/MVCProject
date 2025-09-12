using System.ComponentModel.DataAnnotations;

namespace MVCProject.pl.ViewModels
{
    public class DoctorViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9]).+$",
            ErrorMessage = "Passwords must have at least one non alphanumeric character, one digit ('0'-'9'), and one lowercase ('a'-'z').")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "UserName")]
        [StringLength(50, ErrorMessage = "UserName cannot exceed 50 characters.")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Specialization")]
        [StringLength(100, ErrorMessage = "Specialization cannot exceed 100 characters.")]
        public string Specialization { get; set; }
    }
}

