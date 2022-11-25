using LaFiesta.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace LaFiesta.Areas.Identity.Data
{
    public class CustomUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string Voornaam { get; set; }

        [Required]
        [PersonalData]
        public string Achternaam { get; set; }

        [Required]
        [PersonalData]
        public string Geslacht { get; set; }

        [Required]
        [PersonalData]
        public DateTime Geboortedatum { get; set; }

        [Required]
        public ICollection<Ticket> Ticket { get; set; }
    }
}
