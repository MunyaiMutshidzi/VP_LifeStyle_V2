using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using VP_LifeStyle_V2.Models;
using VP_LifeStyle_V2.Models.ProductMenuViewModel;

namespace VP_LifeStyle_V2.Controllers
{
    public class RoleAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public class AdminController : Controller
        {
            private readonly UserManager<AppUser> _userManager;//Creating User (Add User)/Delete the User)
            private readonly IUserValidator<AppUser> _userValidator; //Edit User

            public AdminController(UserManager<AppUser> userManager,
                IUserValidator<AppUser> userValidator)
            {
                _userManager = userManager;
                _userValidator = userValidator;
            }
            [HttpGet]
            public IActionResult Index()
            {
                return View(_userManager.Users);
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(CreateUserViewModel model)
            {
                if (ModelState.IsValid)
                {
                    AppUser user = new()
                    {
                        UserName = model.Name,
                        Email = model.Email
                    };

                    IdentityResult result
                        = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Delete(string id)
            {
                AppUser user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    IdentityResult result = await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Not Found");
                }
                return View("Index");
            }

            private void AddErrorsFromResult(IdentityResult result)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            [HttpGet]
            public async Task<IActionResult> Edit(string id)
            {
                AppUser user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    return View(user);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            [HttpPost]
            public async Task<IActionResult> Edit(string id, string email, string password)
            {
                AppUser user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    user.Email = email;
                    IdentityResult validEmail
                        = await _userValidator.ValidateAsync(_userManager, user);

                    if (!validEmail.Succeeded)
                    {
                        AddErrorsFromResult(validEmail);
                    }

                    IdentityResult validPass = null;
                    if (!string.IsNullOrEmpty(password))
                    {
                        if (await _userManager.HasPasswordAsync(user))
                        {
                            await _userManager.RemovePasswordAsync(user);
                        }

                        validPass = await _userManager.AddPasswordAsync(user, password);

                        if (!validPass.Succeeded)
                        {
                            AddErrorsFromResult(validPass);
                        }
                    }

                    if ((validEmail.Succeeded && validPass == null)
                        || (validEmail.Succeeded && password != string.Empty && validPass.Succeeded))
                    {
                        IdentityResult result = await _userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            AddErrorsFromResult(result);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Not Found");
                }
                return View(user);
            }

        }
    }
}
