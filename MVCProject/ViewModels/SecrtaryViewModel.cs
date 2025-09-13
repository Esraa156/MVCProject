using System.ComponentModel.DataAnnotations;

namespace MVCProject.pl.ViewModels
{
	public class SecrtaryViewModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public string UserName { get; set; }

        public string? OfficeNumber { get; set; }
	}
}
