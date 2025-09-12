using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModels
{
	public class SignInViewModel
	{
		[Required]
		public required string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public required string Password { get; set; }

		public bool RememberMe { get; set; }	
	}
}
