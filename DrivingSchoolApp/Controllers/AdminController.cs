using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DrivingSchoolApp.Models.Admin;
using Microsoft.AspNetCore.Identity;

namespace DrivingSchoolApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private string GeneratePassword()
        {
            return $"Qw1!{Guid.NewGuid().ToString("N").Substring(0,8)}";
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            string password = GeneratePassword();

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                } 

                return View(model);
            }
            
            if(!await _roleManager.RoleExistsAsync(model.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole(model.Role));
            }

            await _userManager.AddToRoleAsync(user, model.Role);

            TempData["GeneratedPassword"] = password;
            TempData["CreatedUserEmail"] = model.Email;
            return RedirectToAction("Index");
        }
    }
}
