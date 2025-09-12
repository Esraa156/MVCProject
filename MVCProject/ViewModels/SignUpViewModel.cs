using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModels
{
    public class SignUpViewModel
	{
		[Required(ErrorMessage = "FirstName Is Required")]

		public required string FirstName { get; set; }
		[Required(ErrorMessage = "LastName Is Required")]

		public required string LastName { get; set; }

		[Required]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Required(ErrorMessage = "UserName Is Required")]

        public required string UserName { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password Is Required")]
        public required string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }

    }
}
