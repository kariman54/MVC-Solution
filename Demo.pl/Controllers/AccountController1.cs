using Demo.DAL.Models;
using Demo.pl.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.pl.Controllers
{
    public class AccountController1 : Controller
    {
        private readonly UserManager<Applicationuser> _userManager;
        private readonly SignInManager<Applicationuser> _signInManager;

        public AccountController1(UserManager<Applicationuser> userManager , 
            SignInManager<Applicationuser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)// server side validation 
            {
                var user = new Applicationuser()
                {
                    UserName = model.Email.Split('@')[0],
                    Email = model.Email,
                    Gender = model.Gender,
                    IsActive = model.IsActive,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(Loginmodelview model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
              var result = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (result)
                    {
                    var logresult =    await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if(logresult.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    
                     ModelState.AddModelError(string.Empty, "password incorrect");
                    
                }
                else
                
                    ModelState.AddModelError(string.Empty, "Email is not exist");
               
            }
            return View(model);
        }








        //public IActionResult Login()
        //{
        //    return View();
        //}
    }
}


