using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCProject.BLL.Dtos;
using MVCProject.BLL.Helpers;
using MVCProject.BLL.Services;
using MVCProject.Migrations;
using MVCProject.pl.ViewModels;

namespace MVCProject.pl.Controllers
{
	public class AdminController : Controller
	{
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
		{
			return View();
		}
        [HttpGet]
        public IActionResult AddDoctor() => View();
        public async Task<IActionResult> IndexDoctors()
        {
            var doctors = await _adminService.GetAllDoctorsAsync();
            return View(doctors);
        }

        private async Task<IActionResult> HandleCreationAsync<TDto>(
            TDto dto,
            Func<TDto, Task<IdentityResult>> createFunc,
            string successMessage,
            string redirectController = "Home",
            string redirectAction = "Index")
        {
            var result = await createFunc(dto);

            if (result.Succeeded)
            {
                TempData["Success"] = successMessage;
                return RedirectToAction(redirectAction, redirectController);
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var dto = new UserDto(
                model.Email,
                model.Password,
                model.FirstName,
                model.UserName,
                model.LastName,
                model.Specialization
            );

            return await HandleCreationAsync(dto, _adminService.CreateDoctorAsync, "Doctor created successfully!", "Admin", "IndexDoctors");
        }


        //[HttpPost]
        //public async Task<IActionResult> AddDoctor(DoctorViewModel model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    var dto = new DoctorDTO(
        //        model.Email,
        //        model.Password,
        //        model.FirstName,
        //        model.UserName,
        //        model.LastName,
        //        model.Specialization
        //    );

        //    var result = await _adminService.CreateDoctorAsync(dto);
        //    if (result.Succeeded)
        //    {
        //        TempData["Success"] = "Doctor created successfully!";
        //        return RedirectToAction("Index", "Home");
        //    }

        //    foreach (var error in result.Errors)
        //        ModelState.AddModelError("", error.Description);

        //    return View(model);
        //}
        // GET: Edit Doctor
        public async Task<IActionResult> EditDoctor(string id)
        {
            var doctor = await _adminService.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();

            return View(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> EditDoctor(IndexDoctorDto model)
        {
            if (!ModelState.IsValid) return View(model);

            var success = await _adminService.UpdateDoctorAsync(model);
            if (success)
                return RedirectToAction("IndexDoctors");

            ModelState.AddModelError("", "Error updating doctor");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            var success = await _adminService.DeleteDoctorAsync(id);
            if (!success)
            {
                TempData["Error"] = "Doctor not found or could not be deleted.";
            }
            else
            {
                TempData["Success"] = "Doctor deleted successfully.";
            }

            return RedirectToAction("IndexDoctors");
        }
    }
}
