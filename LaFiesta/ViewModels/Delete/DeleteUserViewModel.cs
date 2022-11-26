using System.ComponentModel.DataAnnotations;
using System;

namespace LaFiesta.ViewModels.Delete
{
    public class DeleteUserViewModel
    {
        public string UserId { get; set; }
        public string Achternaam { get; set; }
        public string Voornaam { get; set; }
    }
}
