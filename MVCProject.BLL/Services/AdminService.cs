using Microsoft.AspNetCore.Identity;
using MVCProject.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using MVCProject.BLL.Dtos;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCProject.BLL.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MVCProject.BLL.Services
{
	public class AdminService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IdProtector _idProtector;

        public AdminService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IdProtector idProtector)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_idProtector = idProtector;

        }
		//public async Task<IdentityResult> CreateSecretaryAsync(SecrtaryViewModel model)
		//{
		//	var user = new ApplicationUser
		//	{
		//		UserName = email,
		//		Email = email,
		//		FirstName = firstName,
		//		LastName = lastName
		//	};

		//	var result = await _userManager.CreateAsync(user, password);
		//	if (result.Succeeded)
		//		await _userManager.AddToRoleAsync(user, "Secretary");

		//	return result;
		//}

		public async Task<IdentityResult> CreateDoctorAsync(DoctorDTO model)
		{

			var user = new ApplicationUser
			{
				UserName = model.UserName,
				Email = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
				Specialization = model.Specialization
			};

			var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
				await _userManager.AddToRoleAsync(user, "Doctor");

			return result;
		}
		public async Task<List<IndexDoctorDto>> GetAllDoctorsAsync()
		{
			{
				var doctors = await _userManager.GetUsersInRoleAsync("Doctor");

                return doctors.Select(d => new IndexDoctorDto(
            _idProtector.Protect(d.Id),
               d.Email,
			   d.PasswordHash,
               d.FirstName,
               d.LastName,
               d.Specialization,
               d.UserName
           )).ToList();
            }


		}
        public async Task<IndexDoctorDto?> GetDoctorByIdAsync(string id)
        {
            var decryptedId = _idProtector.Unprotect(id);

            var doctor = await _userManager.FindByIdAsync(decryptedId);
            if (doctor == null) return null;

            return new IndexDoctorDto(
               _idProtector.Protect(doctor.Id),
                doctor.Email,
                                doctor.PasswordHash,

                doctor.FirstName,
                doctor.LastName,
                doctor.Specialization,
                doctor.UserName
            );
        }
        public async Task<bool> UpdateDoctorAsync(IndexDoctorDto model)
        {
            var decryptedId = _idProtector.Unprotect(model.Id);

            var doctor = await _userManager.FindByIdAsync(decryptedId);
            if (doctor == null) return false;

            doctor.FirstName = model.FirstName;
            doctor.LastName = model.LastName;
            doctor.Specialization = model.Specialization;
            doctor.UserName = model.UserName;
            doctor.Email = model.Email;

            var result = await _userManager.UpdateAsync(doctor);
            return result.Succeeded;
        }

        public async Task<bool> DeleteDoctorAsync(string id)
        {
			var decryptedId= _idProtector.Unprotect(id);
            var doctor = await _userManager.FindByIdAsync(decryptedId);
            if (doctor == null) return false;

            var result = await _userManager.DeleteAsync(doctor);
            return result.Succeeded;
        }
    }
}