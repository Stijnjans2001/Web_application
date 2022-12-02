using System;
using System.ComponentModel.DataAnnotations;

namespace LaFiesta.ViewModels.Create
{
	public class CreateUserViewModel
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Voornaam { get; set; }
		[Required]
		public string Achternaam { get; set;}
		[Required]
        [Display(Name = "Wachtwoord")]
        [DataType(DataType.Password)]
		public string Password { get; set; }
        [Required]
        [Display(Name = "Verifiëer wachtwoord")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
		public string Geslacht { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime Geboortedatum { get; set;}
	}
}
