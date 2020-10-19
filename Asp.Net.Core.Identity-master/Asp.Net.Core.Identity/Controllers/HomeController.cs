using System;
using System.Threading.Tasks;
using Asp.Net.Core.Identity.Context;
using Asp.Net.Core.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net.Core.Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _singInManager;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _singInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View(new UserSignInViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> GirisYap(UserSignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await _singInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, true);
                var accessFailedCount = await _singInManager.UserManager.FindByNameAsync(model.Username);
                int kalanGirisHakki = 3 - accessFailedCount.AccessFailedCount;

                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Index", "Panel");
                }
                if (identityResult.IsLockedOut)
                {
                    var kilitlenmeTarihi = await _singInManager.UserManager.FindByNameAsync(model.Username);
                    int kalanZaman = (int)(kilitlenmeTarihi.LockoutEnd - DateTime.Now).Value.TotalMinutes;
                    ModelState.AddModelError("", $"Şifreyi 3 Defa Yanlış Girmeniz Nedeniyle Hesabınız 10 Dakika Süre İle Kilitlenmiştir. Hesabınız {kalanZaman.ToString()} Dakika Sonra Açılacaktır.");
                    return View("Index", model);
                }

                ModelState.AddModelError("", $"Kullanıcı adınız yada Şifreniz Hatalıdır. Kalan hakkınız {kalanGirisHakki.ToString()}");
            }
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KayitOl(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.Username,
                    Gender = model.Gender

                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }
    }
}