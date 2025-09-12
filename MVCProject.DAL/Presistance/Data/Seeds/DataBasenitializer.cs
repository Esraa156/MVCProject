using Microsoft.AspNetCore.Identity;
using MVCProject.Models.Identity;

namespace MVCProject.Data.Seeds
{
	public class DataBaseInitializer
	{
		public static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			// Seed Roles
			if (!await roleManager.RoleExistsAsync("Admin"))
			{
				await roleManager.CreateAsync(new IdentityRole("Admin"));
			}

			if (!await roleManager.RoleExistsAsync("Secretary"))
			{
				await roleManager.CreateAsync(new IdentityRole("Secretary"));
			}

			// Seed Admin User
			if (!userManager.Users.Any())
			{
				var adminToCreate = new ApplicationUser
				{
					FirstName = "Admin",
					LastName = "User",
					UserName = "admin.admin",
					Email = "Admin1@gmail.com",
					EmailConfirmed = true
				};

				var result = await userManager.CreateAsync(adminToCreate, "Pa$$w0rd");

				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(adminToCreate, "Admin");
				}
			}
		}
	}
}
