using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VP_LifeStyle_V2.Data;
using VP_LifeStyle_V2.Models;
using VP_LifeStyle_V2.Models.Viewmodels;

namespace VP_LifeStyle_V2.Controllers
{
    [Authorize]//attribute that enforces authorazation, should be at the top.
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;//Important 
        private readonly RoleManager<IdentityRole> _userRole;

        //Const - Role
        private readonly string DefaultRole = "Customer";

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> userRole)
        {
            _userManager = userManager;
            _signInManager = signInManager;
             _userRole = userRole;
        }

        [AllowAnonymous]//Non Registered/logged indivinduals can view/access
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {

            return View(new LoginView
            {
                ReturnUrl = returnUrl
            } );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//attribute in ASP.NET Core and MVC is a security feature that helps protect web applications from Cross-Site Request Forgery (CSRF) attacks.
        [AllowAnonymous]
        //Task - represent asynchronous operation, that can return value
        public async Task<IActionResult> Login(LoginView loginViewModel)
        {

            if (ModelState.IsValid)
            {
                AppUser user = 
                await _userManager.FindByNameAsync(loginViewModel.Username);
                
                if(user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user,
                        loginViewModel.Password, isPersistent: loginViewModel.RemeberMe, false);

                    if (result.Succeeded)
                    {
                        return Redirect(loginViewModel?.ReturnUrl ?? "/RoleAdmin/Index"); 
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(loginViewModel);
        }

        //Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Restoran");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Register user)
        {
            if (ModelState.IsValid)
            {
                if (await _userRole.FindByNameAsync(DefaultRole) == null)
                {
                    await _userRole.CreateAsync(new IdentityRole(DefaultRole));
                }

                var identityUser = new AppUser
                {
                    UserName = user.Username,
                    Email = user.EmailAddress
                };

                var result = await _userManager.CreateAsync(identityUser,user.Password);

                //New code for avatar image (memoery stream)
                using (var memoryStream = new MemoryStream())
                {
                    await user.AvatarImage.CopyToAsync(memoryStream);
                    identityUser.AvatarImageData = memoryStream.ToArray();
                }

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, DefaultRole);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to register new user");
                }
            }
            return View(user);
        }


        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
