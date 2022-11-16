using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaFiesta.Models
{
    [Table("Artiesten")]
    public class Artiest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Voornaam { get; set; }

        [Required]
        public string Achternaam { get; set; }

        [Required]
        public string Geslacht { get; set; }

        [Required]
        public DateTime Geboortedatum { get; set; }

        [Required]
        public string Afbeelding { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public ICollection<Artiest> Artiesten { get; set; }
    }
}
