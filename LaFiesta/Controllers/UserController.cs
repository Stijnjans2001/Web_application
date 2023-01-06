using LaFiesta.Areas.Identity.Data;
using LaFiesta.ViewModels;
using LaFiesta.ViewModels.Create;
using LaFiesta.ViewModels.Delete;
using LaFiesta.ViewModels.Detail;
using LaFiesta.ViewModels.Lists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace LaFiesta.Controllers
{
    //Admin role cannot be given => authorize does not work
    //[Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        #region Initialisatie en index
        private UserManager<CustomUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            ListUserViewModel viewModel = new ListUserViewModel()
            {
                Users = _userManager.Users.ToList()
            };
			return View(viewModel);
        } 
        #endregion

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

        #region Create
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
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            DeleteUserViewModel viewModel = new DeleteUserViewModel()
            {
                Id = user.Id,
                Voornaam = user.Voornaam,
                Achternaam = user.Achternaam
            };
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
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
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Index", _userManager.Users.ToList());
        }
        #endregion

        #region GrantPermissions
        public IActionResult GrantPermissions()
        {
            GrantPermissionsViewModel vm = new GrantPermissionsViewModel()
            {
                Users = new SelectList(_userManager.Users.ToList(), "Id", "UserName"),
                Roles = new SelectList(_roleManager.Roles.ToList(), "Id", "Name")
            };
            return View(vm);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> GrantPermissions(GrantPermissionsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                CustomUser user = await _userManager.FindByIdAsync(vm.UserId);
                IdentityRole role = await _roleManager.FindByIdAsync(vm.RoleId);
                if (user != null && role != null)
                {
                    IdentityResult result = await _userManager.AddToRoleAsync(user, role.Name);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                            ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User or role Not Found!");
                }
            }
            return View(vm);
        } 
        #endregion
    }

}
