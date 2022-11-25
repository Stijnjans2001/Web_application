using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LaFiesta.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LaFiesta.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;

        public IndexModel(
            UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "E-mailadres")]
            public string Email { get; set; }
            [Required]
            public string Voornaam { get; set; }
            [Required]
            public string Achternaam { get; set; }
            [Required]
            public string Geslacht { get; set; }
            [Required]
            public DateTime Geboortedatum { get; set; }
        }

        private async Task LoadAsync(CustomUser user)
        {
            var emailadres = await Task.FromResult(user.Email);
            var voornaam = await Task.FromResult(user.Voornaam);
            var achternaam = await Task.FromResult(user.Achternaam);
            var geslacht = await Task.FromResult(user.Geslacht);
            var geboortedatum = await Task.FromResult(user.Geboortedatum);
            var datum = DateTime.Now;

            int res = DateTime.Compare(geboortedatum, datum);
            if (res < 0)
            {
                geboortedatum = datum;
            }
            Input = new InputModel
            {
                Email = emailadres,
                Voornaam = voornaam,
                Achternaam = achternaam,
                Geslacht = geslacht,
                Geboortedatum = geboortedatum
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            user.Email = Input.Email;
            user.Voornaam = Input.Voornaam;
            user.Achternaam = Input.Achternaam;
            user.Geslacht = Input.Geslacht;
            user.Geboortedatum = Input.Geboortedatum;

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
