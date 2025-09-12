using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models.Identity;
using MVCProject.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVCProject.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signinManager;


		

		public AccountController(UserManager<ApplicationUser>userManager, SignInManager<ApplicationUser>signinManager)
        {
			_userManager = userManager;
			_signinManager = signinManager;
		}
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
		public async Task<ActionResult> SignUp(SignUpViewModel model)
		{
            if (ModelState.IsValid)
            {


            }

           var user= await _userManager.FindByNameAsync(model.UserName);
            if (user is not null)
            {
                ModelState.AddModelError("UserName", "This username is already token");
            }
            user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                IsAgree = model.IsAgree,
            };
            var res= await _userManager.CreateAsync(user,model.Password);
            if (res.Succeeded) {

                return RedirectToAction(nameof(SignIn));

            }

            foreach(var error in res.Errors)

            {
                ModelState.AddModelError("",error.Description);
            }
            return View(model);
		}
        [HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}
		public async Task<ActionResult> SignIn(SignInViewModel model)
		{
			if (!ModelState.IsValid)
			{

				return View(model);
			}

			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user is not null)
			{

				var check = await _userManager.CheckPasswordAsync(user, model.Password);

				if (check)
				{
					var result = await _signinManager.PasswordSignInAsync(user, model.Password, model.RememberMe,true);

                    if(result.IsNotAllowed)
                        ModelState.AddModelError("", "Your Account is not confirmed yet!");

                    if(result.IsLockedOut)
                        ModelState.AddModelError("", "Your Account is locked out!");

                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index","Home");

                    }

                }
            }
			ModelState.AddModelError("", "Invalid Login attempet");

			return View(model);

		}
  
	}
}
