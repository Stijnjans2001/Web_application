using LaFiesta.Areas.Identity.Data;
using LaFiesta.ViewModels.Create;
using LaFiesta.ViewModels.Detail;
using LaFiesta.ViewModels.Lists;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace LaFiesta.Controllers
{
    public class UserController : Controller
    {
        private UserManager<CustomUser> _userManager;
        public UserController(UserManager<CustomUser> userManager) 
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ListUserViewModel viewModel = new ListUserViewModel()
            {
                Users = _userManager.Users.ToList()
            };
            return View(viewModel);
        }

        public IActionResult Details(string id)
        {
            CustomUser user = _userManager.Users.Where(u => u.Id == id).FirstOrDefault();
            if(user != null)
            {
                DetailUserViewModel viewModel = new DetailUserViewModel()
                {
                    Id = user.Id,
                    Voornaam = user.Voornaam,
                    Achternaam = user.Achternaam,
                    Geboortedatum = user.Geboortedatum,
                    Geslacht = user.Geslacht,
                };
                return View(viewModel);
            }
            else
            {
                ListUserViewModel viewModel = new ListUserViewModel()
                {
                    Users = _userManager.Users.ToList()
                };
                return View("Index", viewModel);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                CustomUser user = new CustomUser() 
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email,
                    Voornaam = viewModel.Voornaam,
                    Achternaam = viewModel.Achternaam,
                    Geboortedatum = viewModel.Geboortedatum,
                    Geslacht = viewModel.Geslacht,
                };

                IdentityResult result = await _userManager.CreateAsync(user, viewModel.Password);
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
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            CustomUser user = await _userManager.FindByIdAsync(id);
            if (user != null) 
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found!");
            }
            return View("Index", _userManager.Users.ToList());
        }

    }

}
