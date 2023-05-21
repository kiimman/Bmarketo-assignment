using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using webbmvcapp.Contexts;
using webbmvcapp.Models.Identity;
using webbmvcapp.Services;
using webbmvcapp.ViewModels;

namespace webbmvcapp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly SignInManager<CustomIdentityUser> _signManager;
        private readonly IdentityContext context;

        public RegisterController(UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, IdentityContext identityContext)
        {
            _userManager = userManager;
            context = identityContext;
            _signManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {


                if (await _userManager.FindByEmailAsync(viewModel.Email) == null)
                {
                    var result = await _userManager.CreateAsync(viewModel, viewModel.Password);
                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByEmailAsync(viewModel.Email);
                        int count = context.Users.Count();
                        if (count == 1)
                        {
                            await _userManager.AddToRoleAsync(user, "Admin");
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, "User");
                        }

                        await _signManager.PasswordSignInAsync(viewModel, viewModel.Password, false, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        string errors = string.Join("\n", result.Errors.Select(x => x.Description));
                        ModelState.AddModelError("", errors);
                    }
                }


            }
            return View(viewModel);
        }
    }
}
