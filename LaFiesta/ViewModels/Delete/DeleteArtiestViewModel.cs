using System;
using System.ComponentModel.DataAnnotations;

namespace LaFiesta.ViewModels.Delete
{
    public class DeleteArtiestViewModel
    {
        public int Id { get; set; }
        
        public string Voornaam { get; set; }
        
        public string Achternaam { get; set; }

        public string Geslacht { get; set; }
        
        public DateTime Geboortedatum { get; set; }

        public string Afbeelding { get; set; }

        public string Genre { get; set; }
    }
}
