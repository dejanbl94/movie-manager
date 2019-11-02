using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieManager.ViewModels;
using MovieManager.ViewModels.Attributes;

namespace MovieManager.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<AppUser> userManager { get; set; }
        private SignInManager<AppUser> signInManager { get; set; }

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // TODO: Try to implement return url per this example https://github.com/ra1han/aspnet-core-identity/blob/master/Demo%202/ASPNetCoreIdentityDemo/ASPNetCoreIdentityDemo/Controllers/AccountController.cs
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.LoginEmail);

                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user.UserName, model.LoginPassword, isPersistent: true, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        TempData["Login"] = "Invalid username or password.";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    TempData["Login"] = "Invalid username or password.";
                    return RedirectToAction("Index");
                }
            }
            TempData["Login"] = "Invalid username or password.";
            return View("~/Views/Home/Index.cshtml");
        }

        // All methods related to Registration or Login have [AlllowAnonymous] attribute so that only logged in users can access them.
        [HttpGet]
        [AllowAnonymous]
        [ViewLayout("_Layout")]
        public async Task<IActionResult> Index(string returnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData["Layout"] = "~/Views/Shared/DashboardLayout.cshtml";
                return View();
            }
            return View("~/Views/Home/Index.cshtml");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /* private IActionResult RedirectToLocal(string returnUrl)
         {
             if (Url.IsLocalUrl(returnUrl))
             {
                 return Redirect(returnUrl);
             }
             else
             {
                 return RedirectToAction(nameof(HomeController.Index), "Home");
             }
         }*/
    }
}
