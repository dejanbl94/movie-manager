using DataLayer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager { get; set; }
        private SignInManager<AppUser> signInManager { get; set; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Login()
        {
            var result = await signInManager.PasswordSignInAsync("TestUser", "Test123!", false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "result is:" + result.ToString();
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "User already registered";

                AppUser user = await userManager.FindByNameAsync("TestUser");
                if (user == null)
                {
                    user = new AppUser();
                    user.UserName = "TestUser";
                    user.Email = "Testuser@gmail.com";
                    user.FirstName = "John";
                    user.LastName = "Doe";

                    IdentityResult result = await userManager.CreateAsync(user, "Test123!");
                    ViewBag.Message = "User was created!";

                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();

        }
    }
}
