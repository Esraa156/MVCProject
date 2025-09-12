using Microsoft.AspNetCore.Identity;

namespace MVCProject.Models.Identity
{
	public class ApplicationUser:IdentityUser
	{
		public  required string FirstName {  get; set; }
		public required string	LastName { get; set; }

		public bool IsAgree { get; set; }
		// Doctor-specific fields
		public string? Specialization { get; set; }

		public string? LicenseNo { get; set; }

		// Secretary-specific fields
		public string? OfficeNumber { get; set; }

	}
}
