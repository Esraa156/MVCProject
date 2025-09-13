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
            string role,
            Func<TDto, string, Task<IdentityResult>> createFunc,
            string successMessage,
            string redirectController = "Home",
            string redirectAction = "Index")
        {
            var result = await createFunc(dto, role);

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
                model.Specialization,
                ""

            );

            return await HandleCreationAsync(dto, "Doctor", _adminService.CreateUserAsync, "Doctor created successfully!", "Admin", "IndexDoctors");
        }


        [HttpGet]

        public IActionResult AddSecertary() { return View("AddSecertary"); }

        [HttpPost]

        public async Task<IActionResult> AddSecertary(SecrtaryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            

            var dto = new UserDto(
                model.Email,
                model.Password,
                model.UserName,

                model.FirstName,
                model.LastName,
                "",
                model.OfficeNumber
            );

            return await HandleCreationAsync(dto, "Secretary", _adminService.CreateUserAsync, "Secertary created successfully!", "Admin", "IndexDoctors");
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
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _adminService.GetuserByIdAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(IndexDoctorDto model)
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
