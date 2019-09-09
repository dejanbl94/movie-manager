using DataLayer.Data;
using DataLayer.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Controllers
{
    public class RegisterController : Controller
    {
        private UserManager<AppUser> userManager { get; set; }
        private SignInManager<AppUser> signInManager { get; set; }
        private readonly FilmManagerDbContext context;

        public RegisterController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, FilmManagerDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }
        // Methods related to Registration [AlllowAnonymous] attribute so that only logged in users can access them.

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Username, Email = model.Email };

                if (!DuplicatesCheck(model).Any())
                {
                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        TempData["Success"] = "You successfully registered!";
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    else
                    {
                        TempData["Error"] = "Registration failed, please try again.";
                        AddErrors(result);
                        return RedirectToLocal(returnUrl);
                    }
                }
                else
                {
                    TempData["DuplicateUsername"] = $"Username {model.Username} is already used, please try another one.";
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            return View("~/Views/Home/Index.cshtml");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        private IEnumerable<AppUser> DuplicatesCheck(RegisterViewModel model)
        {
            var username = model.Username;
            var usernames = (from x in context.Users where x.UserName == username select x).ToList();

            return usernames;
        }
    }
}
